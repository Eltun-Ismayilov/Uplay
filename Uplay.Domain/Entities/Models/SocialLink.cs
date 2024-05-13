namespace Uplay.Domain.Entities.Models
{
    public class SocialLink: CommonEntity
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string YoutubeUrl { get; set; }
    }
}
