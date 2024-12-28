using System.Text.Json.Serialization;

namespace Uplay.Application.Models.Categories
{
    public class CategoryGetAllResponse
    {
        [JsonPropertyName("categories")]
        public List<CategoryDto> CategoryDtos { get; set; }=new List<CategoryDto>();

    }
}
