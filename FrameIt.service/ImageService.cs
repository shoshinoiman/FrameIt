using FrameIt.Core.Dto;
using FrameIt.Core.Repositories;
using FrameIt.Core.Services;
using FrameIt.Data;
using FrameIt.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameIt.service
{
    public class ImageService : IImageService
    {
        private readonly IImageItemRepository _imageItemRepository;
        private readonly ICollageRepository _collageRepository;
        public ImageService(IImageItemRepository imageItemRepository, ICollageRepository collageRepository)
        {
            _imageItemRepository = imageItemRepository;
            _collageRepository = collageRepository;
        }

        //הוספת תמונה לקולאז'
        public async Task<ImageItem> AddImageToCollageAsync(int collageId, ImageItemDto imageItemDto)
        {
            var collage = await _collageRepository.GetCollageByIdAsync(collageId);
            if (collage == null)
                return null;

            var imageItem = new ImageItem
            {
                CollageId = collageId,
                ImageUrl = imageItemDto.ImageUrl,
                X = imageItemDto.X,
                Y = imageItemDto.Y,
                Width = imageItemDto.Width,
                Height = imageItemDto.Height,
                Rotation = imageItemDto.Rotation
            };

            await _imageItemRepository.AddImageItemAsync(imageItem);
            return imageItem;
        }

        // עדכון תמונה
        public async Task<ImageItem> UpdateImageAsync(int imageId, ImageItemDto imageItemDto)
        {
            var imageItem = await _imageItemRepository.GetImageItemByIdAsync(imageId);
            if (imageItem == null) return null;

            imageItem.X = imageItemDto.X;
            imageItem.Y = imageItemDto.Y;
            imageItem.Width = imageItemDto.Width;
            imageItem.Height = imageItemDto.Height;
            imageItem.Rotation = imageItemDto.Rotation;

            await _imageItemRepository.UpdateImageItemAsync(imageItem);
            return imageItem;
        }

        // מחיקת תמונה
        public async Task DeleteImageAsync(int imageId)
        {
            var imageItem = await _imageItemRepository.GetImageItemByIdAsync(imageId);
            if (imageItem == null) return;

            await _imageItemRepository.DeleteImageItemAsync(imageItem);
        }
    }
}
