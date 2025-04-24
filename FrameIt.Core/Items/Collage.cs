
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameIt.Data.Items
{
    public class Collage
    {
        public int Id { get; set; }
        public string CollageUrl { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<ImageItem> Images { get; set; }
    }
}
