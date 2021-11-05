using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            bool parser = false;
            int menuDecision;
            
            Menus.MainMenu();
            parser = int.TryParse(Console.ReadLine(), out menuDecision);
            if (!parser)
            {
                Errors.WrongInputFormat(ExpectedInput.Integer);
            }

            switch (menuDecision)
            {
                case 1:
                    Console.Clear();
                    Menus.ManagementMenu();
                    parser = int.TryParse(Console.ReadLine(), out menuDecision);
                    if (!parser)
                    {
                        Errors.WrongInputFormat(ExpectedInput.Integer);
                    }

                    if (menuDecision == 1) // create team
                    {
                        
                    }
                    break;
                case 2:
                    break;
                default:
                    break;
                
            }
            
            
        }
    }
}