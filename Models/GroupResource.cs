namespace DocumentServer.Models
{
    public class GroupResource
    {
        public int Id { get; set; }
        public int UserGroupId { get; set; }
        public int ResourceId { get; set; }

        public virtual Resource Resource { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}