using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockServer
{
    public static class Data
    {
        public static List<Stock> Stocks = new List<Stock>
        {
            new Stock{ StockCode="300750", StockName="宁德时代",BuyingPrice=265,  CurrentPrice=525 },
            new Stock{ StockCode="600519",StockName="贵州茅台",BuyingPrice=800,  CurrentPrice=1800 },
            new Stock{ StockCode="000001",StockName="平安银行",BuyingPrice=10,  CurrentPrice=12 },
            new Stock{ StockCode="000858",StockName="五粮液",BuyingPrice=150,  CurrentPrice=180 },
            new Stock{ StockCode="000651",StockName="格力电器",BuyingPrice=50,  CurrentPrice=31 },
            new Stock{ StockCode="600888",StockName="科创电力",BuyingPrice=1,  CurrentPrice=10000  }
       };
    }
}
