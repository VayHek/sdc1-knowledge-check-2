using System;
using System.Collections.Generic;

public class Product
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

public class CatFood : Product
{
    public bool KittenFood { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Price: {Price}, Quantity: {Quantity}, Description: {Description}, Kitten Food: {KittenFood}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("How many records do you want to add?");
        int numberOfRecords = int.Parse(GetNonNullInput("Enter the number of records:"));

        var recordList = new List<CatFood>();

        for (int i = 0; i < numberOfRecords; i++)
        {
            Console.WriteLine($"Record {i + 1}:");
            var catFood = new CatFood
            {
                Name = GetNonNullInput("Enter the name:"),
                Description = GetNonNullInput("Enter the description:"),
                Price = decimal.Parse(GetNonNullInput("Enter the price:")),
                Quantity = int.Parse(GetNonNullInput("Enter the quantity:")),
                KittenFood = bool.Parse(GetNonNullInput("Is it kitten food? (true/false):"))
            };
            recordList.Add(catFood);
        }

        Console.WriteLine("\nRecords Entered:");
        foreach (var record in recordList)
        {
            Console.WriteLine(record);
        }
    }

    private static string GetNonNullInput(string prompt)
    {
        Console.WriteLine(prompt);
        var input = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Input cannot be null or empty. Please try again:");
            input = Console.ReadLine();
        }
        return input;
    }
}
