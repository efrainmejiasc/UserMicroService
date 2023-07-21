using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersKeyServices.Application
{
    public class RequestUrl
    {
        private readonly IConfiguration _configuration;

        public RequestUrl(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public  string BalanceAndInformationUrl()
        {
            string url = _configuration["RequestUrl:BalanceAndInformationUrl"];
            return url;
        }
    }
}
