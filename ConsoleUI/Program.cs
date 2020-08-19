using ConsoleUI.Models;
using ConsoleUI.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CustomerOrderDetailCommand customerOrderDetailCommand = new CustomerOrderDetailCommand(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CustomerOrderViewer;Integrated Security=True");
                IList<CustomerOrderDetailModel> customerOrderDetailModels = customerOrderDetailCommand.GetList();

                if (customerOrderDetailModels.Any())
                {
                    foreach (var item in customerOrderDetailModels)
                    {
                        Console.WriteLine($"{item.CustomerOrderId}: Fullname: {item.FirstName} {item.LastName} (Id: {item.CustomerId}) - purchased {item.Description} for {item.Price} (Id: {item.ItemId})");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong {0}", ex.Message);
            }

            Console.ReadLine();
        }
    }
}
