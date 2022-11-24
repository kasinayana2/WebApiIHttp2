using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebApiIHttp2.CustomActionResult
{
    public class TestResult : IHttpActionResult
    {
        string  Value;
        HttpRequestMessage Request;
        public TestResult(string _Value,HttpRequestMessage _Request)
        {
            Value = _Value;
            Request = _Request;
        }
        Task<HttpResponseMessage> IHttpActionResult.ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage
            {
                Content = new StringContent(Value),
                RequestMessage = Request

            };
            return Task.FromResult(response);
        }
    }
}