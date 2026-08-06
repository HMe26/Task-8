using System.ComponentModel.DataAnnotations;

namespace P02_SalesDatabase.Models;

public class Sale
{
    [Key]
    public int SaleId { get; set; }

    public DateTime Date { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public int StoreId { get; set; }
    public Store Store { get; set; } = null!;
}