using AutoMapper;
using DomainLayer.Models;
using RepositoryLayer.Interfaces;
using ServiceLayer.Dtos;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementations
{
    public class CurrenciesService : ICurrenciesService
    {
        //private readonly IMapper _mapper;
        private readonly ICurrenciesRepository _currenciesRepository;

        public CurrenciesService(ICurrenciesRepository currenciesRepository, IMapper mapper)
        {
          //  _mapper = mapper;
            _currenciesRepository = currenciesRepository;
        }

        public async Task<Currency> Add(CurrencyDto currencyDto)
        {
            //var currency = _mapper.Map<Currency>(currencyDto);

            Currency currency = new Currency();
            currency.Name = currencyDto.Name;
            currency.Sign = currencyDto.Sign;
            currency.IsActive = currencyDto.IsActive;

             await _currenciesRepository.Add(currency);

            var addedCurrency =  GetByName(currency.Name);
            return addedCurrency;

        }

        public Currency GetByName(string name)
        {
            var currency =  _currenciesRepository.GetByName(name);
            return currency;
        }

        public IEnumerable<Currency> GetAll()
        {
            return _currenciesRepository.GetAll();
        }


        public Currency Update(int id, CurrencyDto currencyDto)
        {
            var currency = _currenciesRepository.GetById(id);

            if (currency == null)
                throw new ArgumentNullException();

            currency.Name = currencyDto.Name;
            currency.Sign = currencyDto.Sign;
            currency.IsActive = currencyDto.IsActive;

            return _currenciesRepository.Update(currency);
        }

        public Currency Delete(int id)
        {
            var currency = _currenciesRepository.GetById(id);

            if (currency == null)
                throw new ArgumentNullException();

            return _currenciesRepository.Delete(currency);
        }

    }
}
