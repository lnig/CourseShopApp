using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Model
{
    public class Photo
    {
        [Key]
        public int photoID { get; set;  }
        public byte[] Base64 { get; set; }
        public string Extension { get; set; }
        public Photo()
        {

        }
    }
}
