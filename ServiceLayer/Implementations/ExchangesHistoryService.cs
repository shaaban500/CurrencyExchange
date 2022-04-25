using DomainLayer.Models;
using RepositoryLayer.Dtos;
using RepositoryLayer.Implementations;
using RepositoryLayer.Interfaces;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementations
{
    public class ExchangesHistoryService : IExchangesHistoryService
    {
        private readonly IExchangesHistoryRepsitory _exchangesHistoryRepository;

        public ExchangesHistoryService(IExchangesHistoryRepsitory exchangesHistoryRepository)
        {
            _exchangesHistoryRepository = exchangesHistoryRepository;
        }

        public double? GetLastById(int id)
        {
            return _exchangesHistoryRepository.GetLastById(id);
        }

        public IEnumerable<int> GetHighestNCurrencies(int n, DateTime fromDate, DateTime toDate)
        {
            return _exchangesHistoryRepository.GetHighestNCurrencies(n, fromDate, toDate);
        }


        public IEnumerable<int> GetLowestNCurrencies(int n, DateTime fromDate, DateTime toDate)
        {
            return _exchangesHistoryRepository.GetLowestNCurrencies(n, fromDate, toDate);
        }


        public IEnumerable<MostOrLeastImprovedCurrenciesDto> GetMostNImprovedCurrenciesByDate(int n, DateTime fromDate, DateTime toDate)
        {
            return _exchangesHistoryRepository.GetMostNImprovedCurrenciesByDate(n, fromDate, toDate);
        }
        

        public IEnumerable<MostOrLeastImprovedCurrenciesDto> GetLeastNImprovedCurrenciesByDate(int n, DateTime fromDate, DateTime toDate)
        {
            return _exchangesHistoryRepository.GetLeastNImprovedCurrenciesByDate(n, fromDate, toDate);
        }

    }
}
