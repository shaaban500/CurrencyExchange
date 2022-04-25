using DomainLayer.Models;
using ServiceLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface ICurrenciesService
    {
        Task<Currency> Add(CurrencyDto currencyDto);

        Currency GetByName(string name);

        IEnumerable<Currency> GetAll();
        
        Currency Update(int id, CurrencyDto currencyDto);

        Currency Delete(int id);

    }
}
