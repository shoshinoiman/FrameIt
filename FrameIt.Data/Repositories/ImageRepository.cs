using FrameIt.Core.Repositories;
using FrameIt.Data.Items;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameIt.Data.Repositories
{
    public class ImageItemRepository : IImageItemRepository
    {
        private readonly DataContext _context;

        public ImageItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddImageItemAsync(ImageItem imageItem)
        {
            await _context.ImageItems.AddAsync(imageItem);
            await _context.SaveChangesAsync();
        }

        public async Task<ImageItem> GetImageItemByIdAsync(int imageId)
        {
            return await _context.ImageItems.FindAsync(imageId);
        }

        public async Task UpdateImageItemAsync(ImageItem imageItem)
        {
            _context.ImageItems.Update(imageItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteImageItemAsync(ImageItem imageItem)
        {
            _context.ImageItems.Remove(imageItem);
            await _context.SaveChangesAsync();
        }
    }
}
