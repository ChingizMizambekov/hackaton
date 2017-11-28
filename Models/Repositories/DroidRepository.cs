using Hackaton.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackaton.Models.Repositories
{
    public class DroidRepository : IDroidRepository
    {
        private readonly DroidContext context;

        public DroidRepository(DroidContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateNewDroid(Droid droid)
        {
            try
            {
                await context.Droids.AddAsync(droid);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Droid>> GetAllDroids()
        {
            try
            {
                return await context.Droids.ToListAsync();
            }
            catch (Exception ex)
            {
                // Logger functions
                return null;
            }
        }

        public async Task<Droid> GetDroidById(int id)
        {
            try
            {
                return await context.Droids.SingleOrDefaultAsync(c => c.DroidID == id);
            }
            catch (Exception ex)
            {
                // Logger functions
                return null;
            }
        }

        public async Task<Droid> GetDroidByName(string name)
        {            
            try
            {
                return await context.Droids.SingleOrDefaultAsync(u => u.Name == name);
            }
            catch (Exception ex)
            {
                // Logger functions
                return null;
            }
        }


    }
}
