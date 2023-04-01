namespace UsersList.Contracts.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid? ParentId { get; set; }
        public virtual Department? Parent { get; set; }
        public virtual List<Department> SubDepartments { get; set; } = new();
        public virtual List<User> Users { get; set; } = new();
    }
}
