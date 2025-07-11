﻿using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uplay.Application.Exceptions;
using Uplay.Application.Extensions;
using Uplay.Application.Helpers;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Reviews;
using Uplay.Application.Models.Playlists;
using Uplay.Domain.Entities.Models.PlayLists;
using Uplay.Domain.Enums;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.Playlists;

public class PlaylistManager : BaseManager, IPlaylistService
{
    private readonly IPlaylistRepository _playlistRepository;

    public PlaylistManager(IPlaylistRepository playlistRepository,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor)
    {
        _playlistRepository = playlistRepository;
    }

    public async Task<ActionResult<int>> Create(SavePlaylistRequest command)
    {
        var mapping = Mapper.Map<PlayList>(command);
        mapping.Status = PlayListEnum.Requested;
        mapping.PlayListStatusHistories = new List<PlayListStatusHistory>()
            { new() { StatusId = PlayListEnum.Requested } };
        var data = await _playlistRepository.InsertAsync(mapping);
        return data;
    }

    public async Task Update(int id, PlayListEnum statusId)
    {
        var playlist = await _playlistRepository.GetById(id) ??
                       throw new NotFoundException("Playlist not found");
        playlist.Status = statusId;
        playlist.PlayListStatusHistories.Add(new PlayListStatusHistory { StatusId = statusId });
        await _playlistRepository.UpdateAsync(playlist);
    }

    public async Task<GetAllPlaylistResponse> getAllByStatuses(
        ReviewFilter filter,
        List<PlayListEnum> statuses,
        PaginationFilter paginationFilter)
    {
        var response = new GetAllPlaylistResponse();
        var playlistQuery = _playlistRepository.GetPlaylistsInStatuses(filter.BranchId, statuses);

        var a = await playlistQuery.ToListAsync();
        var predicate = PredicateBuilder.New<PlayList>();
        var predicateDto = CreatePlaylistFilterQuery(predicate, filter, paginationFilter);

        if (predicateDto.Predicate != null) 
            playlistQuery = playlistQuery.Where(predicate);
        var list = await playlistQuery.PaginatedMappedListAsync<PlaylistDto, PlayList>(Mapper,
            paginationFilter.PageNumber, paginationFilter.PageSize);
        response.PlaylistDtos = list;

        foreach (var playList in playlistQuery.Skip(predicateDto.Skip)
                     .Take(predicateDto.Take))
        {
            var fileUrl = HttpContextAccessor.GeneratePhotoUrl(playList.FileId);
            var datas = list.Items.FirstOrDefault(x => x.Id == playList.Id);
            datas.File = fileUrl;
        }

        return response;
    }

    public async Task<GetAllPlaylistResponse> getTopThreeMusic(int branchId)
    {
        var response = new GetAllPlaylistResponse();
        var playlistQuery = await _playlistRepository.GetTop3PlaylistsByPlays(branchId);
        var list = await playlistQuery.PaginatedMappedListAsync<PlaylistDto, PlayList>(Mapper, 1, 3);
        response.PlaylistDtos = list;
        
        foreach (var playList in playlistQuery)
        {
            var fileUrl = HttpContextAccessor.GeneratePhotoUrl(playList.FileId);
            var datas = list.Items.FirstOrDefault(x => x.Id == playList.Id);
            datas.File = fileUrl;
        }

        return response;
    }
    
    public static PlaylistPredicateDto CreatePlaylistFilterQuery(
        Expression<Func<PlayList, bool>>? predicate,
        ReviewFilter? filterQuery,
        PaginationFilter paginationFilter)
    {
        if (filterQuery is null || predicate is null)
        {
            return new PlaylistPredicateDto
            {
                Predicate = predicate,
                Skip = 0,
                Take = 0
            };;
        }

        predicate = filterQuery.StartDate is not null && filterQuery.EndDate is not null ? predicate.And(
                x =>
                    x.CreatedDate.Date >= filterQuery.StartDate.Value.Date &&
                    x.CreatedDate.Date <= filterQuery.EndDate.Value.Date)
            : filterQuery.StartDate is not null ? predicate.And(x =>
                x.CreatedDate == filterQuery.StartDate.Value)
            : predicate;
        
        int skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
        int take = paginationFilter.PageSize;

        return new PlaylistPredicateDto
        {
            Predicate = predicate,
            Skip = skip,
            Take = take
        };
    }
}

public class PlaylistPredicateDto
{
    public  Expression<Func<PlayList, bool>>? Predicate { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
}