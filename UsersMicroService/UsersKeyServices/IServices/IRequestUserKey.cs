using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersKeyServices.Models;

namespace UsersKeyServices.IServices
{
    public interface IRequestUserKey
    {
        Task<ResponseModel> GetBalanceAndInformationCard(string card, string jwtToken);
    }
}
