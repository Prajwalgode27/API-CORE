using APICORE1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICORE1.Service
{
    public class Registration:IRegistration
    {
      private readonly COREAPI1Context _appDbContext;
        public Registration(COREAPI1Context appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<TblRegistration>> GetRegistration()
        {
            var CustomerList = await _appDbContext.TblRegistration.ToListAsync();
            return CustomerList;
        }
        public async Task<TblRegistration> DeleteRegistration(int Id)
        {
            var result = await _appDbContext.TblRegistration.FirstOrDefaultAsync(x => x.Id == Id);
            if (result == null)
            {
                return null;
            }

            _appDbContext.TblRegistration.Remove(result);
            await _appDbContext.SaveChangesAsync();
            return result;
        }
        public async Task<TblRegistration> AddRegistration(TblRegistration Registration)
        {
            _appDbContext.TblRegistration.Add(Registration);
            await _appDbContext.SaveChangesAsync();
            return Registration;
        }
     
        public async Task<TblRegistration> UpdateRegistration(TblRegistration Registration)
        {
            _appDbContext.Entry(Registration).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return Registration;
        }
    }
}
