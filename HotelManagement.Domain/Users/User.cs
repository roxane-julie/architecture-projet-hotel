using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Domain.Users;

public class User : IEntity
{
    public Guid Id { get; set; }

    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
    public string EmailAddress { get; set; } = "";

    [MaxLength(256)]
    public string HashedPassword { get; set; } = "";

    [MaxLength(128)]
    public string FirstName { get; set; } = "";

    [MaxLength(128)]
    public string LastName { get; set; } = "";

    public RoleType Role { get; set; }
}
