using System;
using System.Text;

namespace MilkTeaShop
{
    enum Flavors
    {
        Classic,
        Taro,
        Matcha,
        Strawberry,
        RedVelvet
    }

    class Program
    {
        const decimal REGULAR_SIZE_PRICE = 80m;
        const decimal LARGE_SIZE_PRICE = 100m;

        const decimal PEARLS_PRICE = 20m;
        const decimal JELLY_PRICE = 10m;
        const decimal POPPING_BOBA_PRICE = 15m;
        const decimal CREAM_CHEESE_PRICE = 30m;
        const decimal OREO_PRICE = 25m;

        static void Main(string[] args)
        {
            Console.Write("Enter the number of orders: ");
            int numberOfOrders;
            if (!int.TryParse(Console.ReadLine(), out numberOfOrders) || numberOfOrders < 1)
            {
                Console.WriteLine("Invalid number of orders. Exiting the program.");
                return;
            }

            decimal totalPrice = 0;

            for (int i = 0; i < numberOfOrders; i++)
            {
                Console.WriteLine($"\nOrder #{i + 1}");

                bool placeAnotherOrder = true;

                while (placeAnotherOrder)
                {
                    Console.WriteLine("\nWelcome to the Milk Tea Shop!");
                    Console.WriteLine("Available Flavors:");
                    foreach (Flavors flavor in Enum.GetValues(typeof(Flavors)))
                    {
                        Console.WriteLine($"{(int)flavor + 1}. {flavor}");
                    }

                    Console.WriteLine("Available Sizes:");
                    Console.WriteLine($"1. Regular: ₱{REGULAR_SIZE_PRICE}");
                    Console.WriteLine($"2. Large: ₱{LARGE_SIZE_PRICE}");

                    Console.WriteLine("Available Add-ons:");
                    Console.WriteLine($"1. Pearls: ₱{PEARLS_PRICE}");
                    Console.WriteLine($"2. Jelly: ₱{JELLY_PRICE}");
                    Console.WriteLine($"3. Popping Boba: ₱{POPPING_BOBA_PRICE}");
                    Console.WriteLine($"4. Cream Cheese: ₱{CREAM_CHEESE_PRICE}");
                    Console.WriteLine($"5. Oreo: ₱{OREO_PRICE}");

                    int flavorIndex;
                    Console.Write("Enter the number corresponding to the flavor: ");
                    if (!int.TryParse(Console.ReadLine(), out flavorIndex) || flavorIndex < 1 || flavorIndex > Enum.GetNames(typeof(Flavors)).Length)
                    {
                        Console.WriteLine("Invalid selection. Please try again.");
                        continue;
                    }
                    Flavors selectedFlavor = (Flavors)(flavorIndex - 1);

                    int sizeIndex;
                    Console.Write("Enter the number corresponding to the size: ");
                    if (!int.TryParse(Console.ReadLine(), out sizeIndex) || sizeIndex < 1 || sizeIndex > 2)
                    {
                        Console.WriteLine("Invalid selection. Please try again.");
                        continue;
                    }
                    bool isLargeSize = sizeIndex == 2;

                    int addonIndex;
                    Console.Write("Enter the number corresponding to the add-on (0 for none): ");
                    if (!int.TryParse(Console.ReadLine(), out addonIndex) || addonIndex < 0 || addonIndex > 5)
                    {
                        Console.WriteLine("Invalid selection. Please try again.");
                        continue;
                    }

                    string selectedSize = isLargeSize ? "Large" : "Regular";
                    string selectedAddon = addonIndex == 0 ? "None" : ((Flavors)(addonIndex - 1)).ToString();

                    decimal price = isLargeSize ? LARGE_SIZE_PRICE : REGULAR_SIZE_PRICE;

                    if (addonIndex != 0)
                    {
                        switch (addonIndex)
                        {
                            case 1:
                                price += PEARLS_PRICE;
                                break;
                            case 2:
                                price += JELLY_PRICE;
                                break;
                            case 3:
                                price += POPPING_BOBA_PRICE;
                                break;
                            case 4:
                                price += CREAM_CHEESE_PRICE;
                                break;
                            case 5:
                                price += OREO_PRICE;
                                break;
                        }
                    }

                    totalPrice += price;

                    StringBuilder summaryBuilder = new StringBuilder();
                    summaryBuilder.AppendLine("\nOrder Summary:");
                    summaryBuilder.AppendLine("---------------");
                    summaryBuilder.AppendLine($"Flavor: ₱{selectedFlavor}");
                    summaryBuilder.AppendLine($"Size: ₱{selectedSize}");
                    summaryBuilder.AppendLine($"Add-on: ₱{selectedAddon}");
                    summaryBuilder.AppendLine($"Price: ₱{price:F2}");
                    Console.WriteLine(summaryBuilder.ToString());

                    Console.Write("\nPlace another order? (yes/no) ");
                    string userInput = Console.ReadLine();

                    if (userInput.ToLower() != "yes")
                    {
                        placeAnotherOrder = false;
                    }
                }
            }

            Console.WriteLine($"\nTotal price for all orders: ₱{totalPrice:F2}");

            Console.WriteLine("\nPayment Options:");
            Console.WriteLine("Cash");

            decimal cashAmount;
            Console.Write("Enter the amount in cash: ");
            if (!decimal.TryParse(Console.ReadLine(), out cashAmount) || cashAmount < totalPrice)
            {
                Console.WriteLine("Invalid cash amount or insufficient funds. Exiting the program.");
                return;
            }

            decimal change = cashAmount - totalPrice;

            Console.WriteLine($"Payment successful! Change: ₱{change:F2}. Your order has been placed.");

            Console.WriteLine("\nThank you for shopping with us!");
        }
    }
}