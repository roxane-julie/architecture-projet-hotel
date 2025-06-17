using HotelManagement.Domain.Bookings.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Application.Bookings.Dtos;

public class BookingDto : IValidatableObject
{
    public Guid? Id { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid RoomId { get; set; }
    [Required]
    public DateTime From { get; set; }

    [Required]
    public DateTime To { get; set; }
    public float Price { get; set; }
    public bool Payed { get; set; } = false;
    public PaymentMode? PaymentMode { get; set; }
    public DateTime CreatedOn { get; set; }


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
        if (RoomId == Guid.Empty)
        {
            yield return new ValidationResult("Room required", new[] { "To" });
        }
    }
}
