using NewsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Services
{
    public class ApiService
    {
        public async Task<Root> GetNews(string categoryName)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync($"https://gnews.io/api/v4/top-headlines?category={categoryName.ToLower()}&apikey=0bb84c5bea7959addc9ca60108f80a1e");
            return JsonConvert.DeserializeObject<Root>(response);
        }
    }
}
