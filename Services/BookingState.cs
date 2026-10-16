using Midterm.Models;

namespace Midterm.Services;

public class BookingState
{
    private readonly List<Booking> bookings = new();

    public IReadOnlyList<Booking> Bookings => bookings.AsReadOnly();

    public event Action? Changed;

    public void Add(Booking booking)
    {
        bookings.Add(booking);
        Changed?.Invoke();
    }

    public bool Cancel(Guid id)
    {
        var booking = bookings.FirstOrDefault(b => b.Id == id);
        if (booking is null)
        {
            return false;
        }

        bookings.Remove(booking);
        Changed?.Invoke();
        return true;
    }

    public decimal TotalSpent(Func<string, decimal> priceFor)
    {
        return bookings.Sum(b => priceFor(b.PackageSlug) * b.Guests);
    }
}
