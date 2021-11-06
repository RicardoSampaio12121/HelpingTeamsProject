using System;
using System.Collections.Generic;
using Logic;
using Logic.Entities;
using Logic.Repositories;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize api connector
            ApiConnector.Connect();


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

                    Console.WriteLine($"Estou aqui, decisão é {menuDecision}");
                    Console.ReadKey();

                    //TODO: fix this crap
                    if (menuDecision == 1) // create team 
                    {
                        TeamMemberModel m1 = new()
                        {
                            Name = "Ricardo",
                            Surname = "Sampaio",
                            Organization = "PSP"
                        };

                        TeamMemberModel m2 = new()
                        {
                            Name = "Claudio",
                            Surname = "Silva",
                            Organization = "GNR"
                        };

                        TeamMemberModel m3 = new()
                        {
                            Name = "Dário",
                            Surname = "Guerreiro",
                            Organization = "ANEPC"
                        };

                        List<TeamMemberModel> members = new();
                        members.Add(m1);
                        members.Add(m2);
                        members.Add(m3);


                        TeamModel team = new()
                        {
                            Location = "Braga",
                            TeamMembers = members
                        };

                        TeamsManagement.CreateTeam(team);

                    
                    }
                    else if (menuDecision == 4) //Gets all the available products
                    { 
                        try
                        {
                            var coisas = ProductsManagement.GetProducts();
                            foreach (var coisa in coisas.Result)
                            {
                                Console.WriteLine($"{coisa.Name}");
                                Console.WriteLine($"{coisa.Quantity}");

                            }
                        }
                        catch (Exception exe)
                        {
                            Console.ReadKey();
                            Console.WriteLine(exe.Message);
                        }
                    }
                    break;
                case 2: 
                   

                   

                    break;
                default:
                    Console.WriteLine("Estou no case default");
                    Console.ReadKey();
                    break;
                
            }
            
            
        }
    }
}