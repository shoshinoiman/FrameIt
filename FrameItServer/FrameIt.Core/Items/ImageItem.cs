using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameIt.Data.Items
{
    public class ImageItem
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int CollageId { get; set; }
        public Collage Collage { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Rotation { get; set; } // סיבוב תמונה
    }

}
