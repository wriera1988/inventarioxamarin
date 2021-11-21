using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace inventarioTMP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuP
        : ContentPage
    {
        public MenuP()
        {
            InitializeComponent();
        }

        private void Bodegas_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Bodegas(), false);
        }

        private void Productos_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Productos(), false);
        }

        private void Ingresos_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Ingresos(), false);
        }

        private void Egresos_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Egresos(), false);
        }

        private void Info_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Info(), false);
        }

        private void Reporte_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Reporte(), false);
        }
    }
}