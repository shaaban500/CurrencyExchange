using DomainLayer.Models;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Implementations
{
    public class CurrenciesRepository : ICurrenciesRepository
    {
        private readonly AppDbContext _context;

        public CurrenciesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Currency currency)
        {
            await _context.Currencies.AddAsync(currency);
            _context.SaveChanges();
        }

        public Currency GetByName(string name)
        {
            var currency = _context.Currencies.FirstOrDefault(c => c.Name == name);
            return currency;
        }
        
        public IEnumerable<Currency> GetAll()
        {
            var currencies = _context.Currencies.ToList();
            return currencies;
        }

        public Currency GetById(int id)
        {
            return _context.Currencies.FirstOrDefault(c => c.Id == id);
        }

        
        public Currency Update(Currency currency)
        {
            _context.Currencies.Update(currency);
            _context.SaveChanges();
            return currency;
        }

        public Currency Delete(Currency currency)
        {
            _context.Remove(currency);
            return currency;
        }

    }
}
