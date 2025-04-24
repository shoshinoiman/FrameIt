using FrameIt.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameIt.Core.Repositories
{
    public interface ICollageRepository
    {
        Task<Collage> AddCollageAsync(Collage collage);
        Task<Collage> GetCollageByIdAsync(int collageId); 
        Task<List<Collage>> GetCollagesByUserIdAsync(int userId);
        Task<bool> DeleteCollageAsync(int collageID);

    }
}
