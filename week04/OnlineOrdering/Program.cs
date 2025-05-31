using System;

class Program
{
    static void Main(string[] args)
    {
        // First order
        Address address1 = new Address("123 Maple St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Widget", "W001", 10.5, 2));
        order1.AddProduct(new Product("Gadget", "G002", 5.75, 4));

        // Second order
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Thingamajig", "T003", 7.99, 3));
        order2.AddProduct(new Product("Doodad", "D004", 2.5, 5));

        // Display order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}\n");

        // Display order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}\n");
    }
}
