using FrameIt.Core.Dto;
using FrameIt.Core.Repositories;
using FrameIt.Core.Services;
using FrameIt.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameIt.service
{
    public class CollageService : ICollageService
    {
        private readonly ICollageRepository _collageRepository;
        private readonly IImageItemRepository _imageItemRepository;
        private readonly IUserRepository _userRepository;

        public CollageService(ICollageRepository collageRepository, IImageItemRepository imageItemRepository, IUserRepository userRepository)
        {
            _collageRepository = collageRepository;
            _imageItemRepository = imageItemRepository;
            _userRepository = userRepository;
        }

        //create new collage
        public async Task<Collage> CreateCollageAsync(int userId, string title,string url)
        {
            var user =await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                return null;
            var collage = new Collage
            {
                Title = title,
                UserId = userId,
                CollageUrl = url
            };

            return await _collageRepository.AddCollageAsync(collage);
        }

 
        public async Task<Collage> GetCollageByIdAsync(int collageId)
        {
            return await _collageRepository.GetCollageByIdAsync(collageId);
        }

        // get all collage by user id
        //public async Task<List<Collage>> GetCollagesByUserAsync(int userId)
        //{
        //    var user =await _userRepository.GetUserByIdAsync(userId);
        //    if (user == null)
        //        return null;
        //    return await _collageRepository.GetCollagesByUserIdAsync(userId);
        //}

        public async Task<List<CollageDto>> GetCollagesByUserAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                return null;

            var collages = await _collageRepository.GetCollagesByUserIdAsync(userId);

            // ממירים את ה-Entities ל-DTOs
            var collageDtos = collages.Select(c => new CollageDto
            {
                UserId = c.UserId,
                Title = c.Title,
                CollageUrl = c.CollageUrl
            }).ToList();

            return collageDtos;
        }


        //public async Task<ImageItem> AddImageToCollageAsync(int collageId, ImageItemDto imageItemDto)
        //{
        //    var collage = await _collageRepository.GetCollageByIdAsync(collageId);
        //    if (collage == null)
        //    {
        //        throw new ArgumentException("הקולאז' לא קיים.");
        //    }

        //    var imageItem = new ImageItem
        //    {
        //        ImageUrl = imageItemDto.ImageUrl,
        //        CollageId = collageId,
        //        X = imageItemDto.X,
        //        Y = imageItemDto.Y,
        //        Width = imageItemDto.Width,
        //        Height = imageItemDto.Height,
        //        Rotation = imageItemDto.Rotation
        //    };

        //    await _imageItemRepository.AddImageItemAsync(imageItem);
        //    return imageItem;
        //
        //}


        //delete
        public async Task<bool> DeleteCollageAsync(int collageID)
        {
            return await _collageRepository.DeleteCollageAsync(collageID);
        }
    }
}
