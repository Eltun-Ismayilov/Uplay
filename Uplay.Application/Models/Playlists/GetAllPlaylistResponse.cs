using System.Text.Json.Serialization;
using Uplay.Domain.Entities.Models.PlayLists;

namespace Uplay.Application.Models.Playlists;

public class GetAllPlaylistResponse
{
    [JsonPropertyName("playlists")] public PaginatedMappedList<PlaylistDto, PlayList> PlaylistDtos { get; set; }
}