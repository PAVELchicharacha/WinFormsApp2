using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinFormsApp1
{
    public class DataBaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public double CardCode { get; set; }
        public string? LastName { get; set; } 
        public string? FirstName { get; set; } 
        public string? SurName { get; set; }
        public string? PhoneMobile { get; set; }
        public string? Email { get; set; } 
        public string? GenderId { get; set; } 
        public string? Birthday { get; set; } 
        public string? City { get; set; } 
        public double? Pincode { get; set; }
        public double? Bonus { get; set; }
        public double? Turnover { get; set; }
    }
}
