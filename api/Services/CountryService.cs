using ResumeBuilderAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilderAPI.Services
{
    public class CountryService
    {
        private readonly DatawarehouseContext _dbContext;
        private readonly IEnumerable<Country> _countries = new List<Country>();

        public CountryService(DatawarehouseContext dbContext)
        {
            _dbContext = dbContext;
            if (_dbContext.Database.CanConnect())
                _countries = _dbContext.Countries.AsNoTracking().Include(x => x.States).Include(x => x.SubRegion).Include(x => x.Region).ToList();
        }

        public IEnumerable<Country> RetrieveCountries() 
        {
            return _countries;
        }

        public IEnumerable<State> RetrieveStatesByCountryId(int Id)
        {
            List<State> states = new List<State>();
            
            if (_countries.Any(x => x.Id == Id))
                return _countries.SingleOrDefault(x => x.Id == Id).States;
            else
                return states;
        }

        public IEnumerable<State> RetrieveStatesByISO2CountryCode(string ISO2CountryCode)
        {
            List<State> states = new List<State>();

            if (_countries.Any(x => x.ISO2 == ISO2CountryCode))
                return _countries.SingleOrDefault(x => x.ISO2 == ISO2CountryCode).States;
            else
                return states;
        }
    }
}
