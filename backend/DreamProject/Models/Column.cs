using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamProject.Models
{
    public class Column
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
