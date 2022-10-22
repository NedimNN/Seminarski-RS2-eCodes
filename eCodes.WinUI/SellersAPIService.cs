using eCodes.WinUI.Properties;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCodes.WinUI
{
    public class SellersAPIService : APIService
    {
        private string _resource = null;

        public SellersAPIService(string resource) : base("Sellers")
        {
            _resource = resource;
        }
        public async Task<T> RequestDelete<T>(object id)
        {
            try
            {
                var result = await $"{_endpoint}{_resource}/{id}/RequestDelete".WithBasicAuth(username, password).PutAsync().ReceiveJson<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, {string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }

        }



    }
}
