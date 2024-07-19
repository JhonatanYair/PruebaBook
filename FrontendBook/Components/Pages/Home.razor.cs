using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;
using FrontendBook.Models;
using Newtonsoft.Json;
using System.Net;
using Microsoft.AspNetCore.Connections;
using FrontendBook.Common;
using System.Collections.Generic;

namespace FrontendBook.Components.Pages
{
    public partial class Home : ComponentBase
    {
        List<authors> listAuthors = new List<authors>();
        HttpClient client;

        public Home()
        {
            client = new HttpClient();
        }

        private async Task<List<authors>> GetAuthors(int? id = 0)
        {
            var response = await client.GetAsync($"{SharedUtils.urlEndpoint}/Author/{id}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            ResponseApi responseAuthors = JsonConvert.DeserializeObject<ResponseApi>(responseBody);
            List<authors> authors = JsonConvert.DeserializeObject<List<authors>>(responseAuthors.Object.ToString());

            return authors;
        }

        protected override async Task OnInitializedAsync()
        {
            listAuthors = await GetAuthors();
        }

    }
}
