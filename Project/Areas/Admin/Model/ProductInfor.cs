using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Project.Areas.Admin.Model
{
    public class ProductInfor
    {
        public string id { get; set; }

        [Required]
        [DisplayName("Tên")]
        public string name { get; set; }

        [Required]
        [DisplayName( "Slug")]
        public string slug { get; set; }

        [Required]
        [DisplayName( "Ảnh sản phẩm")]

        public string thumbnail { get; set; }

        [Required]
        [DisplayName("Gía")]
        public int price { get; set; }

       
        [DisplayName( "Category")]
        public string category { get; set; }

        [Required]
        [DisplayName( "Subcategory")]
        public string sub_category { get; set; }

        [Required]
        [DisplayName( "Số Lượng")]
        public int quantity { get; set; }

        [Required]
        [DisplayName( "Mô Tả")]
        public string description { get; set; }

        [Required]
        [Column(TypeName = "Ngày tạo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? createAt { get; set; }

        [Required]
        [Column(TypeName = "Ngày chỉnh sửa")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? modifyAt { get ; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpLoad { get; set; }
    }
}   