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
    public class ChatServiceApi
    {

        private Uri baseAddress = new Uri("https://api.huggy.io/v2/");
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Obter os Chats da api do HUGGY
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string> ListAllChatsJson(string token)
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var stringTask = await client.GetStringAsync("https://api.huggy.io/v2/chats");

                return stringTask;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<List<Chat>> ListAllChats(string token)
        {
            if (token.Length < 30) throw new ArgumentException("O parametro token é invalido!");

            int result, page = 0;
            List<Chat> list = new List<Chat>();

            try
            {
                do
                {
                    result = 0;

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                    var serialiazer = new DataContractJsonSerializer(typeof(List<Chat>));
                    var streamTask = await client.GetStreamAsync($"https://api.huggy.io/v2/chats?page={page}");

                    var myList = serialiazer.ReadObject(streamTask) as List<Chat>;
                    list.AddRange(myList);

                    result = myList.Count;
                    page++;

                } while (result >= 20);

                return list;
            }
            catch(AggregateException ag)
            {
                Console.WriteLine($"Erro de agregação no objeto "+ ag.Message);
                throw ag;
            }
            catch (ArgumentNullException a)
            {
                Console.WriteLine("Falta um argumento para processar a solicitação");
                throw a;
            }
            catch (Exception e)
            {
                Console.WriteLine("Um erro ocorreu! " + e.Message);
                throw e;
            }
        }
    }
}
