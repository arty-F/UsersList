namespace UsersList.UseCases.Users.UpdateUser
{
    public record UpdateUserRequestDto(
        Guid Id,
        string FirstName, 
        string LastName, 
        string Patronymic, 
        decimal Salary,
        IList<Guid> DepartmentIds);
}
