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

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void Bodegas_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TabbedPage1(), false);
        }
    }
}