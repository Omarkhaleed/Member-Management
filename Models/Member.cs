using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstTask.Models
{
    public class Member
    {

        [Key]
        [Display(Name = "ID")]
        public int MemberId { set; get; }

        [Required]
        [StringLength(15, ErrorMessage = "The  Name must be below 15 characters")]
        [Display(Name = "Member")]
        public string FirstName { set; get; }

        [Required]
        [Display(Name = "Social ID")]
        //[Range(14, 14, ErrorMessage = "Age must be older than 7 years old")]
        [StringLength(14,MinimumLength =14, ErrorMessage = "The SocialID must be only 14 numbers")]
        public string SocilID { set; get; }


        [DataType(DataType.Upload)]
        [Display(Name = "Social Photo")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string File { get; set; }
       
      
    }
}