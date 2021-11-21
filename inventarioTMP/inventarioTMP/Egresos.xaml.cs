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
    public partial class Egresos : TabbedPage
    {
        private const String urlListar = "http://192.168.100.61:8000/api/movimientos/egreso";
        private const String urlCrear = "http://192.168.100.61:8000/api/movimiento";
        private const String urlListarBod = "http://192.168.100.61:8000/api/bodegas";
        private const String urlListarProd = "http://192.168.100.61:8000/api/productos";        

        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<MovimientosDTO> movimientosLista;
        private ObservableCollection<BodegasDTO> bodegalLista;
        private ObservableCollection<ProductosDTO> productosLista;
        public Egresos()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing() {
            string content = await cliente.GetStringAsync(urlListarBod);
            List<BodegasDTO> postsBod = JsonConvert.DeserializeObject<List<BodegasDTO>>(content);
            bodegalLista = new ObservableCollection<BodegasDTO>(postsBod);
            slcBodega.ItemsSource = bodegalLista;

            content = await cliente.GetStringAsync(urlListarProd);
            List<ProductosDTO> postsPro = JsonConvert.DeserializeObject<List<ProductosDTO>>(content);
            productosLista = new ObservableCollection<ProductosDTO>(postsPro);
            slcProducto.ItemsSource = productosLista;

            content = await cliente.GetStringAsync(urlListar);
            List<MovimientosDTO> posts  = JsonConvert.DeserializeObject<List<MovimientosDTO>>(content);
            movimientosLista = new ObservableCollection<MovimientosDTO>(posts);
            listaIngresos.ItemsSource = movimientosLista;
            base.OnAppearing();
        }

        public async void btnGuardar_Clicked(object sender, EventArgs e)
        {            
            MovimientosDTO nuevoMovimiento = new MovimientosDTO();
            nuevoMovimiento.tipo = "EGRESO";
            nuevoMovimiento.detalle = txtDetalle.Text;
            nuevoMovimiento.cantidad = Convert.ToInt32( txtCantidad.Text);
            var bodegaSeleccionada = slcBodega.SelectedItem as BodegasDTO;
            nuevoMovimiento.id_bodega = bodegaSeleccionada.id;
            var productoSeleccionado = slcProducto.SelectedItem as ProductosDTO;
            nuevoMovimiento.id_producto = productoSeleccionado.id;


            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(nuevoMovimiento);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
           
            response = await cliente.PostAsync(urlCrear, content);
           
            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("Exito.!", "Movimiento creado corectamente", "Ok");
            }

            limpiarPantalla();
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {

        }

        private void limpiarPantalla() {
            txtCantidad.Text = "";
            txtDetalle.Text = "";
            OnAppearing();
        }
    }
}