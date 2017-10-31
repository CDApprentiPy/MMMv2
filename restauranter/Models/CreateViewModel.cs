using System.ComponentModel.DataAnnotations;
using System;

namespace restauranter.Models
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class MyDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d < DateTime.Now;

        }
    }
    public class CreateViewModel : BaseEntity
    {
        [Display(Name = "Reviewer Name")]
        [Required]
        [MinLength(3)]
        public string reviewer { get; set; }

        [Display(Name = "Restaurant Name")]
        [Required]
        [MinLength(3)]
        public string restaurant { get; set; }

        [Display(Name = "Review")]
        [Required]
        [MinLength(10, ErrorMessage = "Review length insufficient")]
        public string review { get; set; }

        [Display(Name = "Stars")]
        [Required]
        public int stars { get; set; }

        [Display(Name = "Date Visited")]
        [DataType(DataType.Date)]
        [MyDate(ErrorMessage ="Invalid date")]
        [Required]
        public DateTime visited { get; set; }
    }
}