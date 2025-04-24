using FrameIt.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameIt.Core.Repositories
{
    public interface IImageItemRepository
    {
        Task AddImageItemAsync(ImageItem imageItem);
        Task<ImageItem> GetImageItemByIdAsync(int imageId);
        Task UpdateImageItemAsync(ImageItem imageItem);
        Task DeleteImageItemAsync(ImageItem imageItem);
    }

}
