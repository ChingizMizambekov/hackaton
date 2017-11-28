using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackaton.Models.Repositories
{
    public interface IDroidRepository
    {
        Task<IEnumerable<Droid>> GetAllDroids();
        Task<Droid> GetDroidById(int id);
        Task<Droid> GetDroidByName(string name);
        Task<bool> CreateNewDroid(Droid droid);
    }
}