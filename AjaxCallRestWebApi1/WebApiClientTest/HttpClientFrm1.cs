using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace WebApiClientTest
{
    public partial class HttpClientFrm1 : Form
    {
        public HttpClientFrm1()
        {
            InitializeComponent();
        }

        private void btnConnectWebAPI_SiteList_Click(object sender, EventArgs e)
        {
            var requestJson = JsonConvert.SerializeObject(new { startId = 1, itemcount = 3 });

            HttpContent httpContent = new StringContent(requestJson);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpClient = new HttpClient();
            //http://localhost:56018/api/rest/SiteList3?startId=1&itemcount=3
            var responseJson = httpClient.PostAsync("http://localhost:56018/api/rest/SiteList3", httpContent)
                .Result.Content.ReadAsStringAsync().Result;

            //var sites = JsonConvert.DeserializeObject<IList<Site>>(responseJson);

            //sites.ToList().ForEach(x => Console.WriteLine(x.Title + "：" + x.Uri));

            MessageBox.Show(responseJson);


            //JS调用如下
            //var requestJson = JSON.stringify({ startId: 1, itemcount: 3 });
            //$.ajax({
            //    url: '/api/demo/sitelist',
            //    data: requestJson,
            //    type: "post",
            //    dataType: "json",
            //    contentType: "application/json; charset=utf8",
            //    success: function (data) {
            //        jQuery.each(data, function (i, val) {
            //            $("#result").append(val.Title + '： ' + val.Uri +'<br/>');
            //        });
            //    }
            //});
        }
    }
}
