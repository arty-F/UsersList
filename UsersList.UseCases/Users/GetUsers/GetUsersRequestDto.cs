namespace UsersList.UseCases.Users.GetUsers
{
    public record GetUsersRequestDto(
        string KeyWords,
        IList<Guid> DepartmentIds,
        decimal MinSalary,
        decimal MaxSalary,
        int PageSize,
        int PageNumber);
}
