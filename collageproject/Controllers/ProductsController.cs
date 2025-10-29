using collageproject.DAL;
//using collageproject.Filters;
using collageproject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;
using System.Net.Mime;

namespace collageproject.Controllers
{
    [TypeFilter(typeof(LogActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase

    {

        private readonly stutentdbcontext _context;

        //private static List<Product> products = new();


        public ProductsController(stutentdbcontext context)
        {

            _context = context;
        }
        //[Authorize]
       
        [LoginFilter]

        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            return Ok("Welcome, authorized user !");
        }


        //[HttpPost]
        //public async Task<IActionResult> sentdata(LOGIN log)
        //{
        //    if (log == null) return BadRequest("user in valid");

        //    _context.MAIN.Add(log);
        //    await _context.SaveChangesAsync();

        //    return Ok("data inserted");
        //}
        //[Authorize]
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(products);
        //}

        //[HttpPost("UploadProductImages/{productId}")]
        //public async Task<IActionResult> Upload_Product_Images(int productId, List<IFormFile> images)
        //{
        //    var product = await _context.Products.FindAsync(productId);
        //    if (product == null)
        //        return NotFound("Product not found.");

        //    foreach (var image in images)
        //    {
        //        if (image.Length > 0)
        //        {
        //            using var ms = new MemoryStream();
        //            await image.CopyToAsync(ms);

        //            var productImage = new ProductImage
        //            {
        //                ProductId = productId,
        //                ImageData = ms.ToArray(),
        //                ImageName = image.FileName,
        //                ContentType = image.ContentType
        //            };

        //            _context.ProductImages.Add(productImage);
        //        }
        //    }

        //    await _context.SaveChangesAsync();
        //    return Ok("Images uploaded successfully");
        //}
        [LoginFilter]

        [HttpPost("CR7")]
        public async Task<IActionResult> CR7PRODUCTS([FromBody] ORDERS CR7)
        {
            if (CR7 == null)
                return BadRequest("Invalid data.");
            _context.Orders.Add(CR7);
            await _context.SaveChangesAsync();
            return Ok("SHUUUU");
        }


        [HttpPost("save-cart-items-in-db")]
        public async Task<IActionResult> savecartitems([FromBody] cartitem cte)
        {
            var cartitem = await _context.cartitem.FirstOrDefaultAsync();
            if (cte == null)
            {
                return BadRequest("invalid id ");

            }

            await _context.SaveChangesAsync();

            return Ok("Item uploaded successfully");
            //}
            //[HttpGet("{productid}")]
            //public IActionResult getdetails(int productid,int appuserid)
            //{

            //    if (productid <= 0 ||appuserid<-0)
            //    {
            //        return BadRequest("invalid data ");
            //    }
            //    var main = _context..Where(x => x.Productid == productid && x.Appuserid==appuserid).Select(x => new
            //    {
            //       x.ImageUrl,
            //       x.Description,
            //       x.Price,
            //       x.Category,
            //       x.InStock
            //    })
            //       .ToList();
            //    if (!main.Any())
            //     {
            //        return BadRequest("the data not found");

            //    }
            //    return Ok(main);
            //}



        }


    }
}