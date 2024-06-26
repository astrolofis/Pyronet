using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message=null)
        {
            StatusCode=statusCode;
            Message=message??GetMessageForStatus(statusCode);
        }       

        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetMessageForStatus(int statusCode)
        {
            return statusCode switch
            {
                400=>"Yanlış bir istekte bulundunuz!",
                401=>"Yetkiniz yok",
                404=>"Kaynak Bulunamadı",
                500=>"Internal Server Hatası",
                _=>null
            };
        }
    }
}