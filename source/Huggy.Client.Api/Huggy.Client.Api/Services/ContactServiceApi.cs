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
    public class ContactServiceApi
    {
        private Uri baseAddress = new Uri("https://api.huggy.io/v2");
        private static readonly HttpClient client = new HttpClient();


        public async Task<List<Contact>> ListAllContacts(string token, int page = 0, bool allPages = true, string uri = "https://api.huggy.io/v2")
        {
            if (token.Length < 30) throw new ArgumentException("O parametro token é invalido!");

            int result;
            List<Contact> list = new List<Contact>();

            try
            {
                do
                {
                    result = 0;

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                    var serializer = new DataContractJsonSerializer(typeof(List<Contact>));
                    var streamTask = await client.GetStreamAsync($"{uri}/contacts?page={page}");

                    var myList = serializer.ReadObject(streamTask) as List<Contact>;
                    list.AddRange(myList);

                    result = myList.Count;
                    page++;

                } while (result >= 20 && allPages);

                return list;
            }
            catch (AggregateException ag)
            {
                Console.WriteLine($"Erro de agregação no objeto " + ag.Message);
                throw ag;
            }
            catch (ArgumentNullException a)
            {
                Console.WriteLine("Falta um argumento para processar a solicitação. " + a.Message);
                throw a;
            }
            catch (Exception e)
            {
                Console.WriteLine("Um erro ocorreu! " + e.Message);
                throw e;
            }
        }


        public async Task<Contact> GetContact(string token, long id, string uri = "https://api.huggy.io/v2")
        {
            if (token.Length < 30 || id == 0) throw new ArgumentException("O parametro é invalido!");

            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var serializer = new DataContractJsonSerializer(typeof(Contact));
                var streamTask = await client.GetStreamAsync($"{uri = -}/contacts/{id}");

                var contact = serializer.ReadObject(streamTask) as Contact;

                return contact;
            }
            catch (Exception e)
            {
                Console.WriteLine("Um erro ocorreu! " + e.Message);
                throw e;
            }
        }

    }
}
