using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string userName { get; set; }
        public string name { get; set; }
        [JsonIgnore]
        public byte[] salted { get; set; }
        [JsonIgnore]
        public string hashed { get; set; }
        [NotMapped]
        public string password { get; set; }


    }
}
