using Huggy.Client.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Huggy.Client.Api.Services
{
    public class AgentServiceApi
    {
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="page"></param>
        /// <param name="allPages"></param>
        /// <returns></returns>
        public async Task<List<Agent>> ListAll(string token, int page = 0, bool allPages = true)
        {
            if (token.Length < 30) throw new ArgumentException("O parametro token é invalido!");

            int result;
            List<Agent> list = new List<Agent>();

            try
            {
                do
                {
                    result = 0;

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                    var serialiazer = new DataContractJsonSerializer(typeof(List<Agent>));
                    var streamTask = await client.GetStreamAsync($"https://api.huggy.io/v2/agents?page={page}");

                    var myList = serialiazer.ReadObject(streamTask) as List<Agent>;
                    list.AddRange(myList);

                    result = myList.Count;
                    page++;

                } while (result >= 20 && allPages);

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("Um erro ocorreu! " + e.Message);
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Agent> Get(string token, long id)
        {
            if (token.Length < 30 || id == 0) throw new ArgumentException("O parametro é invalido!");

            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var serialiazer = new DataContractJsonSerializer(typeof(Agent));
                var streamTask = await client.GetStreamAsync($"https://api.huggy.io/v2/agents/{id}");

                var obj = serialiazer.ReadObject(streamTask) as Agent;

                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
