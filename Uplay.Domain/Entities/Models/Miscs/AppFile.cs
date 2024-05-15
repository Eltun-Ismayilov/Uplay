namespace Uplay.Domain.Entities.Models.Miscs
{
    public class AppFile : CommonEntity
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
    }
}
