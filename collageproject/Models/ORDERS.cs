using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using MyApi.Models;

namespace collageproject.Models
{
    public class ORDERS
    {
        [JsonIgnore]
        [Key]
        public Guid ORDERID { get; set; }

        [JsonIgnore]
        public Guid CARTITEMID { get; set; }

        [JsonIgnore]
        public Guid PRODUCTID { get; set; }

        [JsonIgnore]
        public Guid USERIDID { get; set; }

        public string IMAGEURL { get; set; }

        //[Required(ErrorMessage = "CATAGORY is required")]
        public string CATAGORY { get; set; }

        [Required(ErrorMessage = "PRODUCTNAME is required")]
        public string PRODUCTNAME { get; set; }

      //  [Range(1, 100000, ErrorMessage = "Price must be between 1 to 10000")]
        public decimal PRICE { get; set; }

      //  [Range(1, 15, ErrorMessage = "QUANTITY must be between 1 to 15")]
        public int QUANTITY { get; set; }

        public string DISCRIPTION { get; set; }

        [Required(ErrorMessage = "PAYMENTMETHOD is required")]
        public string PAYMENTMETHOD { get; set; }

        public string ORDERINFO { get; set; }

        [Required(ErrorMessage = "ADDRESS is required")]
        public string ADDRESS { get; set; }

        // Correct navigation property
        public cartitem CartItem { get; set; }
    }
}
