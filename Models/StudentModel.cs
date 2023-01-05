using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPostgres.Models
{
    public class StudentModel
    {
        [Key]
        public int studid { get; set; }
        public string studname { get; set; }
        public string emailid { get; set; }
    }
}