using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Application.Rooms.Dtos;

public class GetAvailableRoomsDto : IValidatableObject
{
    [Required]
    public DateTime From { get; set; }

    [Required]
    public DateTime To { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (From <= DateTime.Now)
        {
            yield return new ValidationResult("Start date must be greater than Today.", new[] { "From" });
        }
        if (To <= From)
        {
            yield return new ValidationResult("End date must be greater than the start date.", new[] { "To" });
        }
    }
}
