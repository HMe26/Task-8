using Microsoft.EntityFrameworkCore;
using P02_SalesDatabase.Data;
using P02_SalesDatabase.Models;

using SalesContext db = new SalesContext();

db.Database.Migrate();

Console.WriteLine("Sales Database Started Successfully!");

if (!db.Customers.Any())
{
    db.Customers.AddRange(
        new Customer
        {
            Name = "Ahmed Mohamed",
            Email = "ahmedmohamed478@gmail.com",
            CreditCardNumber = "1234567890123456"
        },
        new Customer
        {
            Name = "Haitham Mohamed",
            Email = "haithammohamed478@gmail.com",
            CreditCardNumber = "9876543210987654"
        });

    db.SaveChanges();
}

if (!db.Products.Any())
{
    db.Products.AddRange(
        new Product
        {
            Name = "Laptop",
            Quantity = 10,
            Price = 30000
        },
        new Product
        {
            Name = "Mouse",
            Quantity = 50,
            Price = 350
        });

    db.SaveChanges();
}

if (!db.Stores.Any())
{
    db.Stores.AddRange(
        new Store
        {
            Name = "Cairo Store"
        },
        new Store
        {
            Name = "Alex Store"
        });

    db.SaveChanges();
}

if (!db.Sales.Any())
{
    db.Sales.AddRange(
        new Sale
        {
            CustomerId = 1,
            ProductId = 1,
            StoreId = 1
        },
new Sale
{
    CustomerId = 2,
    ProductId = 2,
    StoreId = 2
});

    db.SaveChanges();
}

Console.WriteLine();
Console.WriteLine("Customers");

foreach (Customer customer in db.Customers)
{
    Console.WriteLine($"{customer.CustomerId} - {customer.Name} - {customer.Email}");
}

Console.WriteLine();
Console.WriteLine("Products");

foreach (Product product in db.Products)
{
    Console.WriteLine($"{product.ProductId} - {product.Name} - {product.Price}");
}

Console.WriteLine();
Console.WriteLine("Stores");

foreach (Store store in db.Stores)
{
    Console.WriteLine($"{store.StoreId} - {store.Name}");
}

Console.WriteLine();
Console.WriteLine("Sales");

List<Sale> sales = db.Sales
    .Include(s => s.Customer)
    .Include(s => s.Product)
    .Include(s => s.Store)
    .ToList();

foreach (Sale sale in sales)
{
    Console.WriteLine($"{sale.Customer.Name} bought {sale.Product.Name} from {sale.Store.Name}");
}