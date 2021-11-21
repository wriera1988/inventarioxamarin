using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace inventarioTMP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bodegas : TabbedPage
    {
        private const String urlListar = "http://192.168.100.61:8000/api/bodegas";
        private const String urlCrear = "http://192.168.100.61:8000/api/bodega";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<BodegasDTO> bodegalLista;
        public Bodegas()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing() {
            string content = await cliente.GetStringAsync(urlListar);
            List<BodegasDTO> posts = JsonConvert.DeserializeObject<List<BodegasDTO>>(content);
            bodegalLista = new ObservableCollection<BodegasDTO>(posts);
            listaBodegas.ItemsSource = bodegalLista;
            base.OnAppearing();
        }

        public async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            BodegasDTO nuevaBodega = new BodegasDTO();
            nuevaBodega.nombre = txtNombre.Text;
            nuevaBodega.descripcion = txtDescripcion.Text;
            nuevaBodega.direccion = txtDireccion.Text;
            
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(nuevaBodega);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
           
                response = await cliente.PostAsync(urlCrear, content);
            

            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("Exito.!", "Bodega creada con corectamente", "Ok");
            }

            limpiarPantalla();
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {

        }

        private void limpiarPantalla() {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtDireccion.Text = "";
            OnAppearing();
        }
    }
}