using FrameIt.Core.Dto;
using FrameIt.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameIt.Core.Services
{
    public interface IImageService
    {
        Task<ImageItem> AddImageToCollageAsync(int collageId, ImageItemDto imageItemDto);
        Task<ImageItem> UpdateImageAsync(int imageId, ImageItemDto imageItemDto);
        Task DeleteImageAsync(int imageId);
    }
}
