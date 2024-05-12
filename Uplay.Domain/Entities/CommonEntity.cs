namespace Uplay.Domain.Entities
{
    public abstract class CommonEntity : BaseEntity,
      ISoftDeletedEntity,
      ICreatedDateEntity,
      IUpdatedDateEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool Deleted { get; set; }
    }
}
