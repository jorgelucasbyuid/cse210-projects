namespace OnlineOrdering;

using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double totalProducts = 0;
        foreach (Product product in _products)
        {
            totalProducts += product.GetTotalCost();
        }

        double shippingCost = _customer.LivesInUSA() ? 5.00 : 35.00;
        return totalProducts + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("Packing Label:");
        foreach (Product product in _products)
        {
            label.AppendLine($"  - {product.GetName()} (ID: {product.GetProductId()})");
        }
        return label.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        string formattedAddress = _customer.GetAddress().GetFullAddress().Replace("\n", "\n  ");
        return $"Shipping Label:\n  {_customer.GetName()}\n  {formattedAddress}";
    }
}