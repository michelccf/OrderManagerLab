namespace Resouces.DTOs
{
    public record UserDto ( 
        long Id,
        string Alias,
        string Password,
        string Name,
        string Address,
        string Email,
        string Telephone );
}
