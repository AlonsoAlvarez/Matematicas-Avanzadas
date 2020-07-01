using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculus;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MatematicasAvanzadas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Integrales : ContentPage
    {
        public string funcion = "";
        public Integrales()
        {
            InitializeComponent();
        }

        private void sin_Clicked(object sender, EventArgs e)
        {
            funcion += "sen";
            funXAML.Text = funcion;
        }

        private void cos_Clicked(object sender, EventArgs e)
        {
            funcion += "cos";
            funXAML.Text = funcion;
        }

        private void tan_Clicked(object sender, EventArgs e)
        {
            funcion += "tan";
            funXAML.Text = funcion;
        }

        private void res_Clicked(object sender, EventArgs e)
        {

            double res, h, dc, da, db, fa, fb, fab;
            string a, b;
            b = supXAML.Text;
            a = infXAML.Text;
            Calculo AnalizadorDeFunciones = new Calculo();
            string func = funXAML.Text;
            if (func != null && func.Length != 0 && a != null && a.Length != 0 && b != null && b.Length != 0)
            {
                if (AnalizadorDeFunciones.Sintaxis(func, 'x'))
                {
                    da = double.Parse(a);
                    db = double.Parse(b);
                    dc = (da + db) / 2;
                    fa = AnalizadorDeFunciones.EvaluaFx(da);
                    fb = AnalizadorDeFunciones.EvaluaFx(db);
                    fab = AnalizadorDeFunciones.EvaluaFx(dc);
                    h = (db - da) / 6;
                    res = h * (fa + (4 * fab) + fb);
                    resultXAML.Text = res.ToString();
                }
                else
                {
                    DisplayAlert("Error", "Sintaxis Incorrecta", "Volver");
                }
                //if (AnalizadorDeFunciones.Sintaxis(func, 'x')) //("2*x+2", 'x')) //pasamos la funcion con la variable a evaluar
                //{
                //    fx = AnalizadorDeFunciones.EvaluaFx(2.3);
                //    //area = AnalizadorDeFunciones.Integra(2, 5, 0.0003);
                //    //Console.WriteLine("f(2.3)={0}    Area={1}", fx, area);
                //    resultXAML.Text = fx.ToString();
                //}
                //else
                //{
                //    // aquí mensaje de error en sintaxis
                //    DisplayAlert("Error", "Sintaxis Incorrecta", "Volver");
                //}
            }
            else
            {
                DisplayAlert("Advertencia", "Campos incompletos", "Volver");
            }
        }

        private void abp_Clicked(object sender, EventArgs e)
        {
            funcion += "(";
            funXAML.Text = funcion;
        }

        private void crp_Clicked(object sender, EventArgs e)
        {
            funcion += ")";
            funXAML.Text = funcion;
        }

        private void xvar_Clicked(object sender, EventArgs e)
        {
            funcion += "x";
            funXAML.Text = funcion;
        }

        private void clear_Clicked(object sender, EventArgs e)
        {
            funcion += "^";
            funXAML.Text = funcion;
        }

        private void div_Clicked(object sender, EventArgs e)
        {
            funcion += "/";
            funXAML.Text = funcion;
        }

        private void mult_Clicked(object sender, EventArgs e)
        {
            funcion += "*";
            funXAML.Text = funcion;
        }

        private void resta_Clicked(object sender, EventArgs e)
        {
            funcion += "-";
            funXAML.Text = funcion;
        }

        private void suma_Clicked(object sender, EventArgs e)
        {
            funcion += "+";
            funXAML.Text = funcion;
        }

        private void uno_Clicked(object sender, EventArgs e)
        {
            funcion += "1";
            funXAML.Text = funcion;
        }

        private void cuatro_Clicked(object sender, EventArgs e)
        {
            funcion += "4";
            funXAML.Text = funcion;
        }

        private void tre_Clicked(object sender, EventArgs e)
        {
            funcion += "3";
            funXAML.Text = funcion;
        }

        private void dos_Clicked(object sender, EventArgs e)
        {
            funcion += "2";
            funXAML.Text = funcion;
        }

        private void cinco_Clicked(object sender, EventArgs e)
        {
            funcion += "5";
            funXAML.Text = funcion;
        }

        private void seis_Clicked(object sender, EventArgs e)
        {
            funcion += "6";
            funXAML.Text = funcion;
        }

        private void siete_Clicked(object sender, EventArgs e)
        {
            funcion += "7";
            funXAML.Text = funcion;
        }

        private void ocho_Clicked(object sender, EventArgs e)
        {
            funcion += "8";
            funXAML.Text = funcion;
        }

        private void ce_Clicked(object sender, EventArgs e)
        {
            string aux = "";
            if (1 < funcion.Length)
            {
                for (int i = 0; i < funcion.Length - 1; i++)
                {
                    aux += funcion[i];
                }
            }
            funcion = aux;
            funXAML.Text = funcion;
        }

        private void punto_Clicked(object sender, EventArgs e)
        {
            funcion += ".";
            funXAML.Text = funcion;
        }

        private void cero_Clicked(object sender, EventArgs e)
        {
            funcion += "0";
            funXAML.Text = funcion;
        }

        private void nueve_Clicked(object sender, EventArgs e)
        {
            funcion += "9";
            funXAML.Text = funcion;
        }
    }
}