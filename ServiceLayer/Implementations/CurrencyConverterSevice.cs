using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementations
{
    public class CurrencyConverterSevice : ICurrencyConverterService
    {
        private readonly IExchangesHistoryService _exchangesHistoryService;

        public CurrencyConverterSevice(IExchangesHistoryService exchangesHistoryService)
        {
            _exchangesHistoryService = exchangesHistoryService;
        }

        public double? Convert(int fromCurrencyId, int toCurrencyId, double amount)
        {

            var fromRate = _exchangesHistoryService.GetLastById(fromCurrencyId);
            var ToRate = _exchangesHistoryService.GetLastById(toCurrencyId);

            if (fromRate == null || ToRate == null)
                return null;

            double? fromRateToDollar = fromRate * amount;
            double? fromDollarToTarget = fromRateToDollar / ToRate;

            return fromDollarToTarget;
        }
    }
}
