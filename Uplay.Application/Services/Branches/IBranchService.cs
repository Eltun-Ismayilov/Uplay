using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Branches;

namespace Uplay.Application.Services.Branches;

public interface IBranchService: IBaseService
{
    Task<ActionResult<int>> CreateBranchAsync(SaveBranchRequest command);
    Task<BranchGetAllResponse> GetAll(PaginationFilter paginationFilter);
    
    Task<int> DeleteBranch(int id);
    Task<string> GetByBranchIdAsync(int id);
    Task<int> DisableBranch(int id);
}