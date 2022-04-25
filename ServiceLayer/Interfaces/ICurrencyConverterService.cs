﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface ICurrencyConverterService
    {
        public double? Convert(int fromCurrencyId, int toCurrencyId, double amount);
    }
}