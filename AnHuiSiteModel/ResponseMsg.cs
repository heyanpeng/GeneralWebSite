using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnHuiSite
{
    public class ResponseMsg
    {
        public string Data { get; set; }

        public bool Result { get; set; }

        public string Error { get; set; }

        public ResponseMsg()
        {
            this.Result = true;
        }

        public ResponseMsg(bool result, string data, string error)
        {
            this.Result = result;
            this.Data = data;
            this.Error = error;
        }
    }
}