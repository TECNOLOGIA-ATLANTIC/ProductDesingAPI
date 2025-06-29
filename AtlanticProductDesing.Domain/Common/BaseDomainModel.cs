namespace AtlanticProductDesing.Domain.Common
{
    public abstract class BaseDomainModel
    {
        public long Id { get; set; }

        public DateTime? CreateDate { get; set; }

        public string? CreateBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public string? LastModifiedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

    }
}
