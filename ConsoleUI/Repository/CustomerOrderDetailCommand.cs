using ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleUI.Repository
{
    class CustomerOrderDetailCommand
    {
        private string _connectionString;

        public CustomerOrderDetailCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<CustomerOrderDetailModel> GetList()
        {
            List<CustomerOrderDetailModel> customerOrderDetailModels = new List<CustomerOrderDetailModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("select CustomerOrderId, CustomerId, ItemId, FirstName, LastName, [Description], Price from CustomerOrderDetail", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                CustomerOrderDetailModel customerOrderDetailModel = new CustomerOrderDetailModel()
                                {
                                    CustomerOrderId = Convert.ToInt32(reader["CustomerOrderId"]),
                                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                    ItemId = Convert.ToInt32(reader["ItemId"]),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"])
                                };

                                customerOrderDetailModels.Add(customerOrderDetailModel);
                            }
                        }
                    }
                }
            }
            return customerOrderDetailModels;
        }
    }
}
