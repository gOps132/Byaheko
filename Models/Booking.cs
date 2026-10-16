using System.ComponentModel.DataAnnotations;

namespace Midterm.Models;

public class Booking
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string PackageSlug { get; set; } = "";

    [Required(ErrorMessage = "Tell us your name so the guide knows who to wait for.")]
    [StringLength(80, ErrorMessage = "Keep it under 80 characters.")]
    public string FullName { get; set; } = "";

    [Required(ErrorMessage = "We send the confirmation here.")]
    [EmailAddress(ErrorMessage = "That email doesn't look right.")]
    public string Email { get; set; } = "";

    [Required]
    [FutureOrToday(ErrorMessage = "Travel date can't be in the past.")]
    public DateTime TravelDate { get; set; } = DateTime.Today.AddDays(7);

    [Range(1, 20, ErrorMessage = "Between 1 and 20 travelers per booking.")]
    public int Guests { get; set; } = 2;

    [StringLength(500, ErrorMessage = "Keep notes under 500 characters.")]
    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public string Reference => "BKO-" + Id.ToString("N")[..6].ToUpperInvariant();
}

public sealed class FutureOrTodayAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if (value is DateTime date && date.Date >= DateTime.Today)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "Date can't be in the past.");
    }
}
