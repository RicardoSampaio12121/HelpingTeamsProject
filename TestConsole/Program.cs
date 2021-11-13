using System;
using System.Collections.Generic;
using Logic;
using Logic.Entities;
using Logic.Repositories;
using System.Text.Json;

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

                 

                    //TODO: fix this crap
                    if (menuDecision == 1) // create team 
                    {
                        //TeamMemberModel m1 = new()
                        //{
                        //    Name = "Ricardo",
                        //    Surname = "Sampaio",
                        //    Organization = "PSP"
                        //};

                        //TeamMemberModel m2 = new()
                        //{
                        //    Name = "Claudio",
                        //    Surname = "Silva",
                        //    Organization = "GNR"
                        //};

                        //TeamMemberModel m3 = new()
                        //{
                        //    Name = "Dário",
                        //    Surname = "Guerreiro",
                        //    Organization = "ANEPC"
                        //};

                        //List<TeamMemberModel> members = new();
                        //members.Add(m1);
                        //members.Add(m2);
                        //members.Add(m3);


                        //TeamModel team = new()
                        //{
                        //    Location = "Braga",
                        //    TeamMembers = members
                        //};

                        //TeamsManagement.CreateTeam(team);

                    
                    }
                    else if(menuDecision == 2) //Create product
                    {
                        ProductModel createProductVar = new()
                        {
                            Name = "abcd",
                            Quantity = 13
                        };

                        Logic.Repositories.ProductsManagement.CreateProduct(createProductVar);
                        
                    }
                    else if (menuDecision == 3) //Add stock
                    {
                        ProductModel createProductVar = new()
                        {
                            Id = 2,
                            Name = "abcd",
                            Quantity = 20
                        };
                       
                        Logic.Repositories.ProductsManagement.AddStock(createProductVar);
                        
                   

                    }
                    else if (menuDecision == 4) //Gets all the available products
                    {
                       
                        try
                        {
                            var products = ProductsManagement.GetProducts().Result;

                            foreach(var product in products)
                            {
                                Console.WriteLine(product.Name);
                                Console.WriteLine(product.Quantity.ToString());
                            }

                        }
                        catch (Exception exe)
                        {
                            Console.WriteLine("Dentro da exceção");
                            Console.WriteLine(exe.Message);
                        }
                    }
                    else if(menuDecision == 5)
                    {
                        var product = ProductsManagement.GetProduct("leite").Result;

                        Console.WriteLine(product.Name);
                        Console.WriteLine(product.Quantity.ToString());

                    }
                    else if(menuDecision == 6)
                    {
                        var teams = Logic.Repositories.TeamsManagement.GetTeamsAsync().Result;

                        foreach(var t in teams)
                        {
                            Console.WriteLine($"Id: {t.Id}\nLocation: {t.Location}");
                        }
                    }
                    break;
                case 2: 
                   
                    ProductModel p1 = new()
                    {
                       Name = "Computador",
                       Quantity = 432
                    };

                    ProductsManagement.CreateProduct(p1);
                   

                    break;
                default:
                    Console.WriteLine("Estou no case default");
                    Console.ReadKey();
                    break;
                
            }
            Console.ReadKey();
            
            
        }
    }
}