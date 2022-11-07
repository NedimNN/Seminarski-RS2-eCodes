using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace eCodes.WinUI
{
    public class UsersAPIService : APIService
    {
        private string _resource = null;

        public UsersAPIService(string resource) : base("User")
        {
            _resource = resource;
        }
        public async Task<string> GetAccType(string username)
        {

            try
            {
                var result = await $"{_endpoint}{_resource}/GetAccType?username={username}".WithBasicAuth(username, password).GetStringAsync();
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
                return "";
            }

        }
    }
}
