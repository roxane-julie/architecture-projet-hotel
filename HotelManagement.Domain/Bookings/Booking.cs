using HotelManagement.Domain.Bookings.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Domain.Bookings;

public class Booking : IEntity
{
    public Guid Id { get; set; }
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
    public bool IsCancel { get; set; }
    public bool HasCome { get; set; }
    public bool HasLeave { get; set; }
}
