using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ICurrenciesRepository
    {
        Task Add(Currency currency);

        Currency GetByName(string name);

        IEnumerable<Currency> GetAll();

        Currency GetById(int id);

        Currency Update(Currency currency);

        Currency Delete(Currency currency);

    }
}
