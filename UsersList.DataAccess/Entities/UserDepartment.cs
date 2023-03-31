namespace UsersList.DataAccess.Entities
{
    public class UserDepartment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;
    }
}
