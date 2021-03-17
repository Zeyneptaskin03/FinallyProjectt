using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    class Program

    {

        static void Main(string[] args)
        {
            ProductTest();

            //CategoryTest();
            //UserManager userManager = new UserManager(new EfUserDal());
            //var result = userManager.GetAll();
            //foreach (var item in result.Data)
            //{
            //    Console.WriteLine(item.FirstName + " " + item.LastName);
            //}
            //Console.ReadLine();
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
            var result = productManager.GetProductDetails();

            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }
    }
}
