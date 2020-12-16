using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AZH_Tankai_Server.Models
{
    public class ImageProxy  : IImager
    {
        private bool done;
        private Timer timer;
        private string Source;

        public ImageProxy(string source)
        {
            Source = source;
            timer = new Timer(new TimerCallback(timerCall), this, 2000, 0);
        }

        private void timerCall(object obj)
        {
            done = true;
            timer.Dispose();
        }
        public string getImage()
        {
            IImager img;
            if (done)
            {
                img = new BigImage(this.Source);          
            }
            else
            {
                img = new SmallImage();              
            }
            return img.getImage();
        }
    }
}
