using System;


using Xamarin.Forms;

namespace inventarioTMP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            var usuario = txtUsuario.Text;
            var contrasena = txtContrasena.Text;
            if (String.IsNullOrEmpty(usuario) || String.IsNullOrEmpty(contrasena))
            {
                DisplayAlert("No permitido.!", "Ingrese sus credenciales", "Ok");
            }
            else if (usuario.Equals("Admin") && contrasena.Equals("Admin"))
            {
                Navigation.PushAsync(new MenuP(), false);
            }
            else {
                DisplayAlert("No permitido.!", "Credenciales de ingreso inválidas", "Ok");
            }


        }
    }
}
