namespace Uplay.Domain.Entities
{
    public interface ISoftDeletedEntity
    {
        public bool Deleted { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
