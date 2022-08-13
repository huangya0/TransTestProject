using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockServer.Services
{
    public class StockDemoService:StockService.StockServiceBase
    {
        /// <summary>
        /// 简单模式
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<StockResponse> GetStockByCode(QueryStockRequest request, ServerCallContext context)
        {
            var res = Data.Stocks.Where(s => s.StockCode == request.StockCode).FirstOrDefault();
            if (res == null)
            {
                return Task.FromResult(new StockResponse { });
            }
            var stockRes = new StockResponse
            {
                Stock = res
            };
            return Task.FromResult(stockRes);
        }
        /// <summary>
        /// 服务端流模式
        /// </summary>
        /// <param name="request"></param>
        /// <param name="responseStream"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GetAllOptionalStock(QueryAllOptionalStockRequest request, IServerStreamWriter<StockResponse> responseStream, ServerCallContext context)
        {
            foreach (var stock in Data.Stocks)
            {
                await responseStream.WriteAsync(new StockResponse { Stock = stock });
                await Task.Delay(1000);
            }
        }
        /// <summary>
        /// 客户端流模式
        /// </summary>
        /// <param name="requestStream"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<CommonResponse> BuyManyStocks(IAsyncStreamReader<BuyStocksRequest> requestStream, ServerCallContext context)
        {
            try
            {
                var tempData = new List<string>();
                while (await requestStream.MoveNext())
                {
                    tempData.Add(requestStream.Current.StockCode);
                    Console.WriteLine($"收到购买股票代码{requestStream.Current.StockCode}");
                }
                return new CommonResponse { Code = 0, Msg = $"{tempData.Count}只股票购买成功" };
            }
            catch (Exception ex)
            {
                return new CommonResponse { Code = -1, Msg = "股票购买失败" };
            }
        }
        /// <summary>
        /// 双向流模式
        /// </summary>
        /// <param name="requestStream"></param>
        /// <param name="responseStream"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task FreshStocks(IAsyncStreamReader<FreshStockRequest> requestStream, IServerStreamWriter<StockResponse> responseStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                var stockCode = requestStream.Current.StockCode;
                Console.WriteLine($"收到要刷新股票代码{stockCode}");
                var res = Data.Stocks.Where(s => s.StockCode == stockCode).FirstOrDefault();
                if(res != null)
                {
                    res.CurrentPrice = res.CurrentPrice + res.CurrentPrice * 0.1f;
                    await responseStream.WriteAsync(new StockResponse
                    {
                        Stock = res
                    });
                }
            }
        }
    }
}
