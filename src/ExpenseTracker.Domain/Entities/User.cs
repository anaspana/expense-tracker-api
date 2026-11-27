namespace ExpenseTracker.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public ICollection<Category> Categories { get; set; } = new List<Category>();
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}