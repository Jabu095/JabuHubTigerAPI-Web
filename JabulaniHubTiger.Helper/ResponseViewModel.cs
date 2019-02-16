using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniHubTiger.Helper
{
    public class ResponseViewModel<T>
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
