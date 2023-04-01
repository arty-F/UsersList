namespace UsersList.Contracts.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public decimal Salary { get; set; }
        public virtual List<Department> Departments { get; set; } = new();
    }
}
