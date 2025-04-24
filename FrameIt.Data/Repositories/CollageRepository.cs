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
    public class CollageRepository : ICollageRepository
    {
        private readonly DataContext _context;

        public CollageRepository(DataContext context)
        {
            _context = context;
        }

        //create new collage
        public async Task<Collage> AddCollageAsync(Collage collage)
        {
            await _context.Collages.AddAsync(collage);
            await _context.SaveChangesAsync();
            return collage;
        }

        public async Task<Collage> GetCollageByIdAsync(int collageId)
        {
            //return await _context.Collages.Include(c => c.Images).FirstOrDefaultAsync(c => c.Id == collageId);
            return await _context.Collages.FirstOrDefaultAsync(c => c.Id == collageId);
        }

        public async Task<List<Collage>> GetCollagesByUserIdAsync(int userId)
        {
            return await _context.Collages
                                 .Where(c => c.UserId == userId)
                                 //.Include(c => c.Images) 
                                 .ToListAsync();
        }


        //delete
        public async Task<bool> DeleteCollageAsync(int collageID)
        {
            var collage = await _context.Collages.FindAsync(collageID);
            if (collage == null)
                return false;

            _context.Collages.Remove(collage);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
