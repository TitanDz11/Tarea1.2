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
    public partial class Page2 : ContentPage
    {
        public Page2(int i,String n,String a,int e,String c,String d)
        {
            InitializeComponent();
            id.Text = i.ToString();
            nombre.Text = n;
            apellido.Text = a;
            edad.Text = e.ToString();
            direccion.Text = d;
            correo.Text = c;
        }

        private void Modificar_Clicked(object sender, EventArgs e)
        {
            int idu = int.Parse(id.Text);
            int ed = int.Parse(edad.Text);
            Int32 resultado = 0;
            using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
            {
                resultado = conexion.Execute("update Personas set nombres='"+nombre.Text+"'" +
                    ",apellidos='" + apellido.Text + "', correo='" + correo.Text + "'," +
                    "direccion='" + direccion.Text + "', edad='" + int.Parse(edad.Text) + "' where id=" + idu+ "");
                DisplayAlert("Aviso", "Datos Actualizados", "Ok");
            }
        }

        private void Eliminar_Clicked(object sender, EventArgs e)
        {
            int idu = int.Parse(id.Text);
            Int32 resultado = 0;
            using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
            {
                resultado = conexion.Execute("delete from Personas where id="+idu+"");
                DisplayAlert("Aviso", "Datos Eliminado", "Ok");
            }
        }
    }
}