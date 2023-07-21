using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UsersKeyServices.Application;
using UsersKeyServices.IServices;
using UsersKeyServices.Models;

namespace UsersKeyServices.Services
{
    public class RequestUserKey: IRequestUserKey
    {
        private readonly RequestUrl _requetUrl;
        public RequestUserKey(RequestUrl requetUrl)
        {
            this._requetUrl = requetUrl;
        }

        public async Task<ResponseModel> GetBalanceAndInformationCard( string card, string jwtToken)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var url = this._requetUrl.BalanceAndInformationUrl() + card;
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode && response != null)
                    {
                        var strResponse = response.Content.ReadAsStringAsync().Result;
                        var responseModel = JsonConvert.DeserializeObject<ResponseModel>(strResponse);
                        return responseModel;
                    }


                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
