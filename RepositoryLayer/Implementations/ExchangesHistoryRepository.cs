using DomainLayer.Models;
using RepositoryLayer.Dtos;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Implementations
{
    public class ExchangesHistoryRepository : IExchangesHistoryRepsitory
    {
        private readonly AppDbContext _context;

        public ExchangesHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public double GetLastById(int id)
        {
            return  _context.ExchangesHistory
                    .Where(x => x.CurrencyId == id)
                    .OrderByDescending(x => x.ExchangeDate)
                    .FirstOrDefault().Rate;
        }

        public IEnumerable<int> GetHighestNCurrencies(int n, DateTime fromDate, DateTime toDate)
        {
            return  (from ex in _context.ExchangesHistory
                    where ex.ExchangeDate >= fromDate && ex.ExchangeDate <= toDate
                    group ex by ex.CurrencyId into g
                    orderby g.Max(x => x.Rate) descending
                    select g.Key)
                    .Take(n)
                    .ToList();
        }
        

        public IEnumerable<int> GetLowestNCurrencies(int n, DateTime fromDate, DateTime toDate)
        {
            return (from ex in _context.ExchangesHistory
                    where ex.ExchangeDate >= fromDate && ex.ExchangeDate <= toDate
                    group ex by ex.CurrencyId into g
                    orderby g.Min(x => x.Rate) descending
                    select g.Key)
                    .Take(n)
                    .ToList();
        }


        public IEnumerable<MostOrLeastImprovedCurrenciesDto> GetMostNImprovedCurrenciesByDate(int n, DateTime fromDate, DateTime toDate)
        {
            var MaxRateForEachCurrency = (from ex1 in _context.ExchangesHistory
                                        where ex1.ExchangeDate >= fromDate && ex1.ExchangeDate <= toDate
                                        group ex1 by ex1.CurrencyId into g1
                                        orderby g1.Max(x => x.Rate) descending
                                        select new MaxOrMinRateDto
                                        { 
                                            Id = g1.Key,
                                            exchangeDate = g1.Max(x => x.ExchangeDate),
                                            Rate = g1.Max(x => x.Rate)
                                        })
                                        
                                        .ToList();

            var MinRateForEachCurrency = (from ex2 in _context.ExchangesHistory
                                          where ex2.ExchangeDate >= fromDate && ex2.ExchangeDate <= toDate
                                          group ex2 by ex2.CurrencyId into g2
                                          orderby g2.Min(x => x.Rate) ascending
                                          select new MaxOrMinRateDto
                                          { 
                                              Id = g2.Key,
                                              exchangeDate = g2.Max(x => x.ExchangeDate),
                                              Rate = g2.Min(x => x.Rate)
                                          })
                                          .ToList();


            var MaxAndMinRatesForEachCurreny = (from t1 in MaxRateForEachCurrency
                                                join t2 in MinRateForEachCurrency
                                                on t1.Id equals t2.Id
                                                select new MostOrLeastImprovedCurrenciesDto
                                                {
                                                    Id = t1.Id,
                                                    dif = (t2.exchangeDate < t1.exchangeDate) ? t1.Rate - t2.Rate : t2.Rate - t1.Rate
                                                })
                                                .ToList();

            var MostImprovedCurrencies = (from r in MaxAndMinRatesForEachCurreny
                                          group r by r.Id into g
                                           orderby g.Max(x => x.dif) descending
                                           select new MostOrLeastImprovedCurrenciesDto 
                                           { 
                                               Id = g.Key,
                                               dif = g.Max(x => x.dif) 
                                           })
                                           .Take(n)
                                           .ToList();
            
            return MostImprovedCurrencies;

        }


        public IEnumerable<MostOrLeastImprovedCurrenciesDto> GetLeastNImprovedCurrenciesByDate(int n, DateTime fromDate, DateTime toDate)
        {
            var MaxRateForEachCurrency = (from ex1 in _context.ExchangesHistory
                                          where ex1.ExchangeDate >= fromDate && ex1.ExchangeDate <= toDate
                                          group ex1 by ex1.CurrencyId into g1
                                          orderby g1.Max(x => x.Rate) descending
                                          select new MaxOrMinRateDto
                                          {
                                              Id = g1.Key,
                                              exchangeDate = g1.Max(x => x.ExchangeDate),
                                              Rate = g1.Max(x => x.Rate)
                                          })
                                        .ToList();

            var MinRateForEachCurrency = (from ex2 in _context.ExchangesHistory
                                          where ex2.ExchangeDate >= fromDate && ex2.ExchangeDate <= toDate
                                          group ex2 by ex2.CurrencyId into g2
                                          orderby g2.Min(x => x.Rate) ascending
                                          select new MaxOrMinRateDto
                                          {
                                              Id = g2.Key,
                                              exchangeDate = g2.Max(x => x.ExchangeDate),
                                              Rate = g2.Min(x => x.Rate)
                                          })
                                          .ToList();


            var MaxAndMinRatesForEachCurreny = (from t1 in MaxRateForEachCurrency
                                                join t2 in MinRateForEachCurrency
                                                on t1.Id equals t2.Id
                                                select new MostOrLeastImprovedCurrenciesDto
                                                {
                                                    Id = t1.Id,
                                                    dif = (t2.exchangeDate < t1.exchangeDate) ? t1.Rate - t2.Rate : t2.Rate - t1.Rate
                                                })
                                                .ToList();

            var LeastImprovedCurrencies = (from r in MaxAndMinRatesForEachCurreny
                                          group r by r.Id into g
                                          orderby g.Min(x => x.dif) descending
                                          select new MostOrLeastImprovedCurrenciesDto
                                          {
                                              Id = g.Key,
                                              dif = g.Min(x => x.dif)
                                          })
                                          .Take(n)
                                          .ToList();

            return LeastImprovedCurrencies;

        }

    }
}
