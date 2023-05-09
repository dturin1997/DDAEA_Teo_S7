﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2023
{
        public class Program
        {
        static List<Product> products = new List<Product>();
        static void Main(string[] args)
        {
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            var pares = (from c in numbers
                        where c % 2 == 0
                        select c).ToList();

            ShowPares(numbers);
            ShowParesLambda(numbers);

            InsertProducts();
            var productsExpensive = products.Where(x => x.Price > 50).ToList();
            //Un listado de productos precio <50 y contenga la letra m el nombre
            var productsFiltro = products.Where(x => x.Price < 50 && (x.Name.Contains("m"))).ToList();

            //Tipado débil
            var productsNew = products.Where(x => x.Price < 50 && x.Name.Contains("m"))
                                      .Select(x => new {
                                          Nombre = x.Name,
                                          PrecioIGV = x.Price * 1.18
                                      }).ToList();

            foreach (var item in productsNew)
            {
                Console.Write(item.Nombre);
                Console.Write(item.PrecioIGV);
                Console.WriteLine();
            }
            

            


            foreach (var par in pares) { Console.Write(par); }
            
            
            Console.ReadLine();

        }

        private static void ShowPares(int[] numbers)
        {
            Console.WriteLine("ShowPares");
            var pares = (from c in numbers
                         where c % 2 == 0
                         select c).ToList();
            foreach (var par in pares) { Console.WriteLine(par); }
        }

        private static void ShowParesLambda(int[] numbers)
        {
            Console.WriteLine("ShowParesLambda");
            var pares = numbers.Where(x=>x % 2 == 0).ToList();
            foreach (var par in pares) { Console.WriteLine(par); }
        }

        private static void InsertProducts()
        {
            string[] basicNeeds = { "Leche", "Pan", "Arroz", "Huevos", "Azúcar", "Aceite", "Sal", "Harina", "Pasta", "Jabón", "Papel higiénico", "Detergente", "Cepillo de dientes", "Shampoo", "Cebolla", "Zanahoria", "Papa", "Tomate", "Atún", "Pollo" };

            Random random = new Random();
            for (int i = 1; i <= 100; i++)
            {
                int productId = i;
                string name = basicNeeds[random.Next(0, basicNeeds.Length)];
                int price = random.Next(10, 100); // Genera un precio aleatorio entre 10 y 100
                products.Add(new Product { ProductId = productId, Name = name, Price = price });
            }
        }


    }
}
