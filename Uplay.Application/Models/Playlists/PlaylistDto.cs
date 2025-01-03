using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.PlayLists;
using Uplay.Domain.Enums;

namespace Uplay.Application.Models.Playlists;

public class PlaylistDto :BaseDto, IMapFrom<PlayList>
{
    public string Title { get; set; }
    public string Duration { get; set; }
    public int BranchId { get; set; }
    public PlayListEnum Status { get; set; }
    public string CreatedDate { get; set; }
    public string YoutubeId { get; set; }
    public string File { get; set; }
}