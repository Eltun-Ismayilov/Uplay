using System.Text.Json.Serialization;
using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Application.Models.Core.Branches;

public class BranchGetAllResponse
{
    [JsonPropertyName("branches")] public PaginatedMappedList<BranchDto, Branch> BranchDtos { get; set; }
}