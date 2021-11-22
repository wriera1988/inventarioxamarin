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
    public partial class Productos : TabbedPage
    {
        private const String urlListar = "http://192.168.1.10:8000/api/productos";
        private const String urlCrear = "http://192.168.1.10:8000/api/producto";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<ProductosDTO> bodegalLista;
        public Productos()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing() {
            string content = await cliente.GetStringAsync(urlListar);
            List<ProductosDTO> posts = JsonConvert.DeserializeObject<List<ProductosDTO>>(content);
            bodegalLista = new ObservableCollection<ProductosDTO>(posts);
            listaProductos.ItemsSource = bodegalLista;
            base.OnAppearing();
        }

        public async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            ProductosDTO nuevoProducto = new ProductosDTO();
            nuevoProducto.nombre = txtNombre.Text;
            nuevoProducto.descripcion = txtDescripcion.Text;
            nuevoProducto.codigo = txtCodigo.Text;
            nuevoProducto.foto = "-";

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(nuevoProducto);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
           
            response = await cliente.PostAsync(urlCrear, content);
          
            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("Exito.!", "Producto creado corectamente", "Ok");
            }

            limpiarPantalla();
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {

        }

        private void limpiarPantalla() {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtCodigo.Text = "";
            OnAppearing();
        }
    }
}