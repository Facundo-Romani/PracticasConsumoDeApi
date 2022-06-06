using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace RestApiXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public class DemoAPI
        {
            public int userId { get; set; }
            public int id { get; set; }
            public string title { get; set; }
            public string body { get; set; }
        }

        // API REST.

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Solicitud.
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://jsonplaceholder.typicode.com/posts");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accpet", "application/json");

            // Petición enviar objeto con solicitud.
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            // Chequear si da una respuesta.
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<DemoAPI>>(content);

                ListDemo.ItemsSource = resultado;
            }
        }
    }
}
