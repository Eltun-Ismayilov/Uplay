using AutoMapper;
using Microsoft.AspNetCore.Http;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.PlayLists;

namespace Uplay.Application.Models.Playlists;

public class SavePlaylistRequest: IMapFrom<PlayList>
{
    public string Title { get; set; }
    public IFormFile File { get; set; }
    public string Duration { get; set; }
    public int BranchId { get; set; }
    public long YoutubeId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<SavePlaylistRequest, PlayList>();
    }
}