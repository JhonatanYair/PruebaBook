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
        [Inject]
        private NavigationManager Navigation { get; set; }
        private List<authors> listAuthors;
        private readonly HttpClient client;

        public Home()
        {
            client = new HttpClient();
            listAuthors = new List<authors>();
        }

        protected override async Task OnInitializedAsync()
        {
            listAuthors = await GetAuthors();
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

 
        private async void redirectPage(int id,string nameAuthor)
        {
            Navigation.NavigateTo($"/authorDetails/{id}/{nameAuthor}");
        }

    }
}
