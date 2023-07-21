using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersKeyServices.Models
{
    public class ResponseModel
    {
        public string Card { get; set; }
        public decimal Balance { get; set; }
        public string BalanceDate { get; set; }
        public decimal VirtualBalance { get; set; }
        public string VirtualBalanceDate { get; set; }
        public string Error { get; set; }
        public string ErrorMessage { get; set; }
    }
}
