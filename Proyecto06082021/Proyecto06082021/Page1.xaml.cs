using Proyecto06082021.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto06082021
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
            {
                conexion.CreateTable<Personas>();
                var listpersonas = conexion.Table<Personas>().ToList();
                ListaPersonas.ItemsSource = listpersonas;
            }
        }

        private void ListaPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Personas selectedItem = e.SelectedItem as Personas;
            int iduser = selectedItem.id;
            String name = selectedItem.nombres;
            String surname = selectedItem.apellidos;
            int year = selectedItem.edad;
            String email = selectedItem.correo;
            String direction = selectedItem.direccion;
            this.Navigation.PushAsync(new Page2(iduser,name,surname,year,email,direction));
        }

        private void ListaPersonas_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}