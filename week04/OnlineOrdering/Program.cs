namespace OnlineOrdering;

using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 2: Customer in EUA (Shipping of $5)

        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Wireless Mouse", "P1001", 25.50, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "P1002", 75.00, 1));
        order1.AddProduct(new Product("USB-C Cable", "P1003", 12.00, 3));

        // Order 2: Customer out of EUA (Shipping of $35)

        Address address2 = new Address("Av. Providencia 1234", "Santiago", "RM", "Chile");
        Customer customer2 = new Customer("Maria Silva", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("HD Monitor 27\"", "P2001", 210.00, 1));
        order2.AddProduct(new Product("Ergonomic Chair", "P2002", 180.00, 1));

        // Show the results of order 1

        Console.WriteLine("========================================");
        Console.WriteLine("ORDER 1 DETAILS");
        Console.WriteLine("========================================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():F2}");
        Console.WriteLine();

        // Show results of order 2

        Console.WriteLine("========================================");
        Console.WriteLine("ORDER 2 DETAILS");
        Console.WriteLine("========================================");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():F2}");
        Console.WriteLine("========================================");
    }
}