using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //loosely coupling 
        //Productservisi newleyerek ona değer vermeliyiz  ama onun yerine
        //biz constallera erişm desenei yaparız  fealt yaparız somut referans içn 
        //IOc  değişim kontrolü bellekteki yere newleme yaparız referanslar iiiiiiçin 
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
         
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Dependency chain bağımlılık ilkesi
          // refaktör ett  IProductService productService = new ProductManager(new EfProductDal());
          //naming convention yazıım kuralı 

            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);

            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {

            var result = _productService.Add(product); 
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        
         [HttpGet("getbyid")]
           public IActionResult GetById(int id)
           {
               var result = _productService.GetById(id);
               if (result.Success)
               {
                   return Ok(result.Data);

               }
               return BadRequest(result.Message);
           }
    }

}