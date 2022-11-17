using Grpc.Net.Client;
using StockServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormStockClientDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 简单模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //1、创建grpc客户端
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var grpcClient = new StockService.StockServiceClient(channel);
            //2、发起请求
            var resp = grpcClient.GetStockByCode(new QueryStockRequest
            {
                StockCode = tbStockCode.Text.Trim()
            });
            //3、处理响应结果，将其显示在文本框中
            if (resp.Stock != null)
            {
                this.tbResult.Text = "";
                this.tbResult.Text = $"股票代码：{resp.Stock.StockCode}, 股票名称：{resp.Stock.StockName}，现价：{resp.Stock.CurrentPrice}";
            }
        }
        /// <summary>
        /// 客户端流模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            //1、创建grpc客户端
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var grpcClient = new StockService.StockServiceClient(channel);
            //3、通过客户端请求流将文件流发送的服务端
            using var call = grpcClient.BuyManyStocks();
            var clientStream = call.RequestStream;
            List<string> buyStockCodes = new List<string>() { "000001", "600888", "600519" };
            //4、循环发送，指定发送完文件
            foreach(string code in buyStockCodes)
            {
                // 5、一次发送一个股票代码
                await clientStream.WriteAsync(new BuyStocksRequest() { StockCode = code});
                await Task.Delay(1000);
            }
            // 6、发送完成之后，告诉服务端发送完成
            await clientStream.CompleteAsync();
            this.tbResult.Text = "";
            // 7、接收返回结果，并显示在文本框中
            var res = await call.ResponseAsync;
            this.tbResult.Text = $"Msg:{res.Msg}";
        }
        /// <summary>
        /// 服务端流模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button3_Click(object sender, EventArgs e)
        {
            //用于多线程通知
            CancellationTokenSource cts = new CancellationTokenSource();
            //1、创建grpc客户端
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var grpcClient = new StockService.StockServiceClient(channel);
            //2、客户端一次请求，多次返回
            using var respStreamingCall = grpcClient.GetAllOptionalStock(new QueryAllOptionalStockRequest());
            //3、获取响应流
            var respStreaming = respStreamingCall.ResponseStream;
            this.tbResult.Text = "";
            //4、循环读取响应流，直到读完为止
            while (await respStreaming.MoveNext(cts.Token))
            {
                //5、取得每次返回的信息，并显示在文本框中
                var stock = respStreaming.Current.Stock;
                this.tbResult.Text += $"股票代码：{stock.StockCode}, 股票名称：{stock.StockName}，买入价：{stock.BuyingPrice}, 现价：{stock.CurrentPrice}\r\n";
            }

        }
        /// <summary>
        /// 双向流模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button4_Click(object sender, EventArgs e)
        {
            //用于多线程通知
            CancellationTokenSource cts = new CancellationTokenSource();
            //模拟通过请求流方式刷新多只股票行情，同时通过响应流的方式返回查询结果
            //1、创建grpc客户端
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var grpcClient = new StockService.StockServiceClient(channel);
            //2、分别取得请求流和响应流
            using var call = grpcClient.FreshStocks();
            var requestStream = call.RequestStream;
            var responseStream = call.ResponseStream;
            this.tbResult.Text = "";
            //3、开启一个线程专门用来接收响应流
            var taskResp = Task.Run(async () => {
                while (await responseStream.MoveNext(cts.Token))
                {
                    var stock = responseStream.Current.Stock;
                    // 将接收到结果在文本框中显示 ，多线程更新UI简单处理一下：Control.CheckForIllegalCrossThreadCalls = false;
                    this.tbResult.Text += $"股票代码：{stock.StockCode}, 股票名称：{stock.StockName}，买入价：{stock.BuyingPrice}, 现价：{stock.CurrentPrice}\r\n";
                }
            });
            List<string> refreshStockCodes = new List<string>() { "000001", "600888", "600519", "000858" };
            //4、通过请求流的方式将多条数据依次传到服务端
            foreach (var code in refreshStockCodes)
            {
                // 每次发送一个学生请求
                await requestStream.WriteAsync(new FreshStockRequest()
                {
                    StockCode = code
                });
                
                await Task.Delay(1000);
            }
            //5、传送完毕
            await requestStream.CompleteAsync();
            await taskResp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 允许多线程更新UI 
            Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
