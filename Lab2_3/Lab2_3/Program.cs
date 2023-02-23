// Seeusing System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace GroupByLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(local);Initial Catalog=MyDatabase;Integrated Security=True";
            string query = "SELECT * FROM Products";

            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string name = reader["Name"].ToString();
                    string category = reader["Category"].ToString();
                    decimal price = (decimal)reader["Price"];

                    Product product = new Product(id, name, category, price);
                    products.Add(product);
                }
            }

            // Группировка по категориям
            var productsByCategory = products.GroupBy(p => p.Category);

            foreach (var group in productsByCategory)
            {
                Console.WriteLine("Category: " + group.Key);

                foreach (var product in group)
                {
                    Console.WriteLine("\t" + product.Name + " - " + product.Price.ToString("C"));
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, string category, decimal price)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
        }
    }
}
