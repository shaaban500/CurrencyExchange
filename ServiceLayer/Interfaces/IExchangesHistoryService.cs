using DomainLayer.Models;
using RepositoryLayer.Dtos;
using RepositoryLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IExchangesHistoryService
    {
        double? GetLastById(int id);

        IEnumerable<int> GetHighestNCurrencies(int n, DateTime fromDate, DateTime toDate);

        IEnumerable<int> GetLowestNCurrencies(int n, DateTime fromDate, DateTime toDate);

        IEnumerable<MostOrLeastImprovedCurrenciesDto> GetMostNImprovedCurrenciesByDate(int n, DateTime fromDate, DateTime toDate);

        IEnumerable<MostOrLeastImprovedCurrenciesDto> GetLeastNImprovedCurrenciesByDate(int n, DateTime fromDate, DateTime toDate);

    }
}
