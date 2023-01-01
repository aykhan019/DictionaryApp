using DictionaryApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryApp.Services
{
    public class DictionaryService
    {
        private static HttpClient _client = new HttpClient();
        private static readonly string URL = "https://api.dictionaryapi.dev/api/v2/entries/en/";
        public static async Task<WordDetail> GetWordDetail(string word)
        {
            var url = URL + word;
            var response = Task.Run(() => _client.GetAsync(url)).Result;
            var str = await response.Content.ReadAsStringAsync();
            dynamic data;
            try
            {
                data = JsonConvert.DeserializeObject<List<WordDetail>>(str);
                return data[0];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
