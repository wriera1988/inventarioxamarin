using System;
using System.Collections.Generic;
using System.Linq;
using Microcharts;
using Xamarin.Forms;
using System.Net.Http;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
namespace inventarioTMP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reporte
        : ContentPage
    {
        private const String urlListar = "http://192.168.1.10:8000/api/movimientos";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<MovimientosDTO> movimientosLista;
        public Reporte()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {            
            string content = await cliente.GetStringAsync(urlListar);
            List<MovimientosDTO> posts = JsonConvert.DeserializeObject<List<MovimientosDTO>>(content);
            movimientosLista = new ObservableCollection<MovimientosDTO>(posts);
            listaMovimientos.ItemsSource = movimientosLista;
            base.OnAppearing();
        }
    }
}