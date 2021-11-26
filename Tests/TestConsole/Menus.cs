using System;

namespace TestConsole
{
    public static class Menus
    {
        public static void MainMenu()
        {
            Console.WriteLine("(1) Management application.");
            Console.WriteLine("(2) Teams application.");
            Console.Write("Decision: ");
        }

        public static void ManagementMenu()
        {
            Console.WriteLine("(1) Create team");
            Console.WriteLine("(2) Create product");
            Console.WriteLine("(3) Add more stock to a product");
            Console.WriteLine("(4) List all products");
            Console.WriteLine("(5) List a single product");
            Console.WriteLine("(6) List all pending requests");
            Console.WriteLine("(7) List pending requests by team");
            Console.WriteLine("(8) List all accepted requests");
            Console.WriteLine("(9) List accepted requests by team");
            Console.WriteLine("(10) List all rejected requests");
            Console.WriteLine("(11) List rejected by team requests");

        }
    }
}