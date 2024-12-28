using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uplay.Application.Extensions;
using Uplay.Application.Models;
using Uplay.Application.Models.Categories;
using Uplay.Application.Models.Partners;
using Uplay.Application.Services.AppFiles;
using Uplay.Application.Services.Branches;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Repository;
using Uplay.Persistence.Repository.Concrete;

namespace Uplay.Application.Services.Categories
{
    public class CategoryManager : BaseManager, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFileService _fileService;

        public CategoryManager(
            IMapper mapper,
            IHttpContextAccessor contextAccessor,
            IFileService fileService,
            ICategoryRepository categoryRepository)
            : base(mapper, contextAccessor)
        {
            _fileService = fileService;
            _categoryRepository = categoryRepository;
        }

        public async Task<ActionResult<int>> Create(SaveCategoryRequest command)
        {
            var category = await _categoryRepository.InsertAsync(Mapper.Map<Category>(command));

            return category;
        }

        public async Task<CategoryGetAllResponse> GetAll()
        {
            CategoryGetAllResponse response = new();

            var partnerQuery = _categoryRepository.GetQuery()
                                                  .Include(x => x.File)
                                                  .OrderBy(X=>X.Id)
                                                  .ToList();

            foreach (var category in partnerQuery)
            {
                response.CategoryDtos.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    File = HttpContextAccessor.GeneratePhotoUrl(category.FileId),
                });
            }

            return response;
        }
    }
}
