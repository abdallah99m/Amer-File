using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmerPay.Models.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ValidateNever]
        public string FileForward { get; set; }
        [ValidateNever]
        public string FileExtension { get; set; }
        [ValidateNever]
        public string FileName { get; set; }


        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime UpDateTime { get; set; } = DateTime.Now;
        [ValidateNever]
        [Display(Name = "User")]
        public int UserId { get; set; }
        
    }
}
