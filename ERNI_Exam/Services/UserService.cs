using ERNI_Exam.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ERNI_Exam.Services
{
    public class UserService : IUserService
    {
        public async Task<List<UserModel>> GetUsers()
        {
            List<UserModel> result = new List<UserModel>();

            var networkStatus = Connectivity.NetworkAccess;
            if (networkStatus == NetworkAccess.Internet)
            {
                var url = "https://gist.githubusercontent.com/erni-ph-mobile-team/c5b401c4fad718da9038669250baff06/raw/7e390e8aa3f7da4c35b65b493fcbfea3da55eac9/test.json";
                var client = new HttpClient();
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<List<UserModel>>(response.Content.ReadAsStringAsync().Result);
                    result = result.GroupBy(c => c.Id).Select(d => d.FirstOrDefault()).ToList();
                }
                else
                {
                    Debug.WriteLine("Request Failed.");
                }
            }
            else
            {
                Debug.WriteLine("No Internet Connection.");
            }

            return result;
        }
    }
}