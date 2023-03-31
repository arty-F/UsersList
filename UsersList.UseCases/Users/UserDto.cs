namespace UsersList.UseCases.Users
{
    public record UserDto(
        Guid Id,
        string FirstName,
        string LastName,
        string Patronymic,
        decimal Salary,
        int DepartmentsCount);
}
