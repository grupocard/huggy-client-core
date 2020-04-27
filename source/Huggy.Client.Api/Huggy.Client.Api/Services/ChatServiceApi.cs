using Huggy.Client.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Huggy.Client.Api.Services
{
    public class ChatServiceApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string> ListAllChats(string token)
        {
            var baseAddress = new Uri("https://api.huggy.io/v2/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("x-authorization", $"Bearer {token}");

                using (var response = await httpClient.GetAsync("chats"))
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    return responseData;
                }
            }
        }

        //public async Task<List<Chat>> ListAllChats(string token)
        //{
        //    return await Task.FromResult<List<Chat>>(null);
        //}
    }
}
