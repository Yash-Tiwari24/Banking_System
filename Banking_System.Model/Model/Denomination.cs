using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Model.Model
{
    [Table("Denomination")]
    public class Denomination
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "2000")]
        public decimal Note2000 { get; set; }
        [Display(Name = "500")]
        public decimal Note500 { get; set; }
        [Display(Name = "200")]
        public decimal Note200 { get; set; }
        [Display(Name = "100")]
        public decimal Note100 { get; set; }
        [Display(Name = "50")]
        public decimal Note50 { get; set; }
        [Display(Name = "20")]
        public decimal Note20 { get; set; }
        [Display(Name = "10")]
        public decimal Note10 { get; set; }
       


    }
}
