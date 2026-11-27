namespace ExpenseTracker.Domain.Entities;

public class Expense
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateOnly Date { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public int UserId { get; set; }
    public User User { get; set; } = null!;
}