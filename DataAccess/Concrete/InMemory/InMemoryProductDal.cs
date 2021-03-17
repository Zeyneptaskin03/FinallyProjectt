using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal(List<Product> products)
        {
            _products = products;
        }

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
               new Product{ProductId=1, CategoryId=1, ProductName="bardak", UnitPrice=15, UnitsInStock=5 },
               new Product {ProductId=2, CategoryId=2, ProductName="çatal", UnitPrice=25, UnitsInStock=15 },
               new Product{ProductId=3, CategoryId=1, ProductName="bara", UnitPrice=105, UnitsInStock=105 },
               new Product {ProductId=4, CategoryId=2, ProductName="çat", UnitPrice=55, UnitsInStock=205 }

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // product productToDelete = new product();//201. nolu ref alırız eşit ref nosu ararrız atarız boşyere bellek yorulur.
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            // null; //silinecek ürün
            /* foreach (var p in _products) //p allias
             {
                 if (product.ProductId==p.ProductId) //tek tek ürünleri dolaşıyoruz 
                 {
                     productToDelete = p; //ref değerini kendi gönderdiğimiz ıd ye eşleşirse siler
                 }

             }
            */ //bunlar yerine bu yazılır  productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(product);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)  //ürünleri kategory göre filtrelemek demek eksik vardı burda implemente ettik interface'i
        {
            return _products.Where(p=>p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetailDtos()
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        { //gönderdiğim ürün ıdsine sahip olan listedeki ürünü bul ve güncelleyelim
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;


        }
    }
}
