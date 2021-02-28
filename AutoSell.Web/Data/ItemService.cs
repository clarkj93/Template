using AutoSell.Data.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutoSell.Web.Data
{
    public class ItemService
    {
        public async Task<Item[]> GetAllAsync()
        {
            HttpClient client = new HttpClient();

            string json = null;

            HttpResponseMessage response = await client.GetAsync("http://localhost:51386/item");

            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<Item[]>(json);
        }

    }
}
