using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyApi.Models
{
    //public class Product
    //{
    //    [Key]
    //    public int ProductId { get; set; }
    //    public string ProductName { get; set; }
    //    public string Description { get; set; }
    //    public decimal Price { get; set; }
    //    [NotMapped]
    //    public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
    //}
         
    //public class User
    //{
    //    public int  Userid { get; set; }
      
    //}
    public class LOGIN
    {
        [JsonIgnore]
        public Guid id { get; set; }
        public  string USERNAME { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public bool ISADMIN { get; set; }
    }
    [Table("cartitem")]
    public class cartitem {
        [Key]
        [JsonIgnore]
        public Guid CARTITEMID { get; set; }
        //public int Appuserid { get; set; }
        public string DISCRIPTION { get; set; }
        public string PRODUCTNAME { get; set; }
        public string CATAGORY { get; set; }
        public decimal PRICE { get; set; }
        public int QUANTITY { get; set; }
        public string IMAGEURL { get; set; }
        //public byte[] ImageUrl { get; set; }
        //public bool InStock { get; set; }
        //public int cartitemid { get; set; }
            

        //public User User { get; set; }
        //public Product Product { get; set; }
        //[NotMapped]
        //public IEnumerable<object> Images { get; set; }
    }

    //public class ProductImage
    //{
    //    [Key] // This is required
    //    public int Id { get; set; }
    //    public int ImageId { get; set; }
    //    public int ProductId { get; set; }
    //    public byte[] ImageData { get; set; }
    //    public string ImageName { get; set; }
    //    public string ContentType { get; set; }
    //    public DateTime UploadedAt { get; set; } = DateTime.Now;
    //    [NotMapped] // EF will ignore this property
    //    public ICollection<ProductImage> Images { get; set; }
    //    public Product Product { get; set; }
    //}
}
