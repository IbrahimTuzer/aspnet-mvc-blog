namespace Blog.Data.Entity.Abstract
{
	public abstract class AuditEntity
	{
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public DateTime? UpdatedAt { get; set; }
		public DateTime? DeletedAt { get; set; }
	}
}
