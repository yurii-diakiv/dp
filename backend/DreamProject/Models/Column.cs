using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DreamProject.Models
{
    public class Column
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Card> ColumnCards { get; set; }
        [ForeignKey("Board")]
        public int BoardId { get; set; }
        public Board Board { get; set; }
    }
}
