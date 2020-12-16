using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZH_Tankai_Server.Models
{
    public class BigImage : IImager
    {
        private string Image;
        public BigImage(string image) {
            Image = image;
        }
        public string getImage()
        {
            return this.Image;
        }
    }
}
