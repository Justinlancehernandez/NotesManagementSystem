using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Note
    {
        [Key]
        public int noteId { get; set; }
        public string header { get; set; }

        public string description { get; set; }

        [ForeignKey("user")]

        public int userId { get; set; }

        public User user { get; set; }


    }
}
