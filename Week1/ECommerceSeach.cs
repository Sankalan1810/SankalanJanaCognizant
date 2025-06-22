using System;

public class Program
{
    public static void Main(string[] args)
    {
        Product[] products = new Product[] {
            new Product(1, "Redmi Note 7 pro", "Electronics"),
            new Product(2, "ClassMate 160 pages Notebook", "Stationary"),
            new Product(3, "One Plus Ear Buds", "Electronics"),
            new Product(4, "Red Silk Curtain", "Home Decorations"),
            new Product(5, "Boat Rockerz 255 Pro+", "Electronics"),
            new Product(6, "Faber-Castell Color Pencils", "Stationary"),
            new Product(7, "Samsung Galaxy S22", "Electronics"),
            new Product(8, "Ikea Wooden Study Table", "Furniture"),
            new Product(9, "Usha Mist Air Fan", "Home Appliances"),
            new Product(10, "Raymond Men’s Formal Shirt", "Clothing"),
            new Product(11, "Dell Inspiron 15 Laptop", "Electronics"),
            new Product(12, "Havells LED Bulb 9W", "Home Appliances"),
            new Product(13, "Parker Ink Pen", "Stationary"),
            new Product(14, "Bombay Dyeing Bedsheet - King Size", "Home Decorations"),
            new Product(15, "Nike Revolution 6 Shoes", "Footwear"),
            new Product(16, "Wildcraft Backpack 35L", "Accessories"),
            new Product(17, "Canon Pixma Inkjet Printer", "Electronics"),
            new Product(18, "Prestige Pressure Cooker 5L", "Kitchen Appliances"),
            new Product(19, "Adidas Sports T-shirt", "Clothing"),
            new Product(20, "Philips Beard Trimmer", "Personal Care"),
            new Product(21, "Redmi Note 8 pro", "Electronics"),
            new Product(22, "Redmi Note 9 pro", "Electronics"),
        };

        Console.WriteLine("Welcome to E-Commerce Shopping Platform");
        Console.WriteLine("1. Search By Product Name (partial match)");
        Console.WriteLine("2. Search for Product ID");
        Console.WriteLine("3. Search for Products in a Category (partial match)");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            if (choice == 1)
            {
                Console.WriteLine("Enter name of the product:");
                string input = Console.ReadLine();
                SearchByNamePartial(products, input);
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter the ID of the product:");
                string idInput = Console.ReadLine();
                int id;
                if (int.TryParse(idInput, out id))
                {
                    BinarySearchByID(products, id);
                }
                else
                {
                    Console.WriteLine("Invalid product ID entered.");
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("Enter the name of the Category:");
                string categoryName = Console.ReadLine();
                SearchByCategoryPartial(products, categoryName);
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }

    public static void SearchByNamePartial(Product[] products, string namePart)
    {
        bool found = false;
        foreach (var product in products)
        {
            if (product.productName.IndexOf(namePart, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Console.WriteLine($"Product: {product.productName} (ID: {product.productID}, Category: {product.Category}) is Available");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("No matching products found.");
        }
    }

    public static void SearchByCategoryPartial(Product[] products, string categoryPart)
    {
        bool found = false;
        foreach (var product in products)
        {
            if (product.Category.IndexOf(categoryPart, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Console.WriteLine($"Product: {product.productName} (ID: {product.productID}, Category: {product.Category}) is Available");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("No products found in this category.");
        }
    }

    public static void BinarySearchByID(Product[] products, int id)
    {
        Array.Sort(products, (a, b) => a.productID.CompareTo(b.productID));
        int left = 0;
        int right = products.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (products[mid].productID == id)
            {
                Console.WriteLine($"Product: {products[mid].productName} (ID: {products[mid].productID}, Category: {products[mid].Category}) is Available");
                return;
            }
            else if (products[mid].productID < id)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        Console.WriteLine("Product Not Available");
    }
}

public class Product
{
    public int productID { get; set; }
    public string productName { get; set; }
    public string Category { get; set; }

    public Product(int productID, string productName, string category)
    {
        this.productID = productID;
        this.productName = productName;
        this.Category = category;
    }
}
