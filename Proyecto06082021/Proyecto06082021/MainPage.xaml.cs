using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using Proyecto06082021.Model;

namespace Proyecto06082021
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnSalvar_Clicked(object sender, EventArgs e)
        {
            Int32 resultado = 0;
            var persona = new Personas()
            {
                nombres = nombre.Text,
                apellidos = apellido.Text,
                edad = int.Parse(edad.Text),
                correo = correo.Text,
                direccion = direccion.Text,
                FechaNacimiento = Fecha.ToString()
            };

            using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
            {
                conexion.CreateTable<Personas>();
                resultado = conexion.Insert(persona);

                if (resultado > 0)
                    DisplayAlert("Aviso", "Adicionado", "Ok");
                else
                    DisplayAlert("Aviso", "Error", "Ok");
            }
        }

        private async void toolbarmenu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }

        public DateTime ultima;
        private void Fecha_DateSelected(object sender, DateChangedEventArgs e)
        {
            ultima = e.NewDate;
            var fechamostrar = e.NewDate.ToString("D");
        }
    }
}
