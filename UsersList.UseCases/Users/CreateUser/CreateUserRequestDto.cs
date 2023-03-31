namespace UsersList.UseCases.Users.CreateUser
{
    public record CreateUserRequestDto(
        string FirstName, 
        string LastName, 
        string Patronymic, 
        decimal Salary,
        IList<Guid> DepartmentIds);
}
