
using FrameIt.Core.Dto;
using FrameIt.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameIt.Core.Services
{
    public interface ICollageService
    {
        Task<Collage> CreateCollageAsync(int userId, string title,string url);
        Task<Collage> GetCollageByIdAsync(int collageId); 
        Task<List<CollageDto>> GetCollagesByUserAsync(int userId);
        //Task<ImageItem> AddImageToCollageAsync(int collageId, ImageItemDto imageItemDto);
        Task<bool> DeleteCollageAsync(int collageID);

    }

}
