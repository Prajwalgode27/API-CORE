using System.Collections.Generic;
using System.Threading.Tasks;
using APICORE1.Models;
using System.Linq;

namespace APICORE1.Service
{
    public interface IRegistration
    {

        Task<IEnumerable<TblRegistration>> GetRegistration();

        Task<TblRegistration> DeleteRegistration(int Id);

        Task<TblRegistration> AddRegistration(TblRegistration Registration);
        Task<TblRegistration> UpdateRegistration(TblRegistration Registration);

    }
}
