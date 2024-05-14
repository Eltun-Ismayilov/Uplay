namespace Uplay.Domain.Entities.Models
{
    public class AppFile : CommonEntity
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
    }
}
