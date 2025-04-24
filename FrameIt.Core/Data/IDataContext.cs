using FrameIt.Data.Items;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameIt.Core.Data
{
    public interface IDataContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Collage> Collages { get; set; }
        DbSet<ImageItem> ImageItems { get; set; }
    }

}
