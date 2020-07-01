using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MatematicasAvanzadas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalSRMD : ContentPage
    {
        public CalSRMD()
        {
            InitializeComponent();
        }

        private void Suma_Clicked(object sender, EventArgs e)
        {
            string real = N1RealXAML.Text;
            string imaginara = N1ImaginariaXAML.Text;
            string real2 = N2RealXAML.Text;
            string imaginara2 = N2ImaginariaXAML.Text;
            Conversiones conv = new Conversiones();
            Imaginarios im = new Imaginarios();
            Imaginarios im2 = new Imaginarios();
            Imaginarios res = new Imaginarios();
            if (real != null && imaginara != null && real2 != null && imaginara2 != null
                && !real.Length.Equals(0) && !imaginara.Length.Equals(0)
                && !real2.Length.Equals(0) && !imaginara2.Length.Equals(0))
            {
                im.setReal(float.Parse(real));
                im.setImaginaria(float.Parse(imaginara));
                im2.setReal(float.Parse(real2));
                im2.setImaginaria(float.Parse(imaginara2));
                res = im.suma(im2);
                if (res.getImaginaria() <0)
                {
                    Rreal.Text = res.getReal().ToString() + "" + res.getImaginaria().ToString() + "i";
                }
                else
                {
                    Rreal.Text = res.getReal().ToString() + "+" + res.getImaginaria().ToString() + "i";
                }
            }
            else
            {
                DisplayAlert("Advertencia", "Campos incompletos", "Volver");
            }
        }

        private void Resta_Clicked(object sender, EventArgs e)
        {
            string real = N1RealXAML.Text;
            string imaginara = N1ImaginariaXAML.Text;
            string real2 = N2RealXAML.Text;
            string imaginara2 = N2ImaginariaXAML.Text;
            Conversiones conv = new Conversiones();
            Imaginarios im = new Imaginarios();
            Imaginarios im2 = new Imaginarios();
            Imaginarios res = new Imaginarios();
            if (real != null && imaginara != null && real2 != null && imaginara2 != null
                && !real.Length.Equals(0) && !imaginara.Length.Equals(0)
                && !real2.Length.Equals(0) && !imaginara2.Length.Equals(0))
            {
                im.setReal(float.Parse(real));
                im.setImaginaria(float.Parse(imaginara));
                im2.setReal(float.Parse(real2));
                im2.setImaginaria(float.Parse(imaginara2));
                res = im.resta(im2);
                if (res.getImaginaria() < 0)
                {
                    Rreal.Text = res.getReal().ToString() + "" + res.getImaginaria().ToString() + "i";
                }
                else
                {
                    Rreal.Text = res.getReal().ToString() + "+" + res.getImaginaria().ToString() + "i";
                }
            }
            else
            {
                DisplayAlert("Advertencia", "Campos incompletos", "Volver");
            }

        }

        private void Mult_Clicked(object sender, EventArgs e)
        {
            string real = N1RealXAML.Text;
            string imaginara = N1ImaginariaXAML.Text;
            string real2 = N2RealXAML.Text;
            string imaginara2 = N2ImaginariaXAML.Text;
            Conversiones conv = new Conversiones();
            Imaginarios im = new Imaginarios();
            Imaginarios im2 = new Imaginarios();
            Imaginarios res = new Imaginarios();
            if (real != null && imaginara != null && real2 != null && imaginara2 != null
                && !real.Length.Equals(0) && !imaginara.Length.Equals(0)
                && !real2.Length.Equals(0) && !imaginara2.Length.Equals(0))
            {
                im.setReal(float.Parse(real));
                im.setImaginaria(float.Parse(imaginara));
                im2.setReal(float.Parse(real2));
                im2.setImaginaria(float.Parse(imaginara2));
                res = im.multiplicacion(im2);
                if (res.getImaginaria() < 0)
                {
                    Rreal.Text = res.getReal().ToString() + "" + res.getImaginaria().ToString() + "i";
                }
                else
                {
                    Rreal.Text = res.getReal().ToString() + "+" + res.getImaginaria().ToString() + "i";
                }
            }
            else
            {
                DisplayAlert("Advertencia", "Campos incompletos", "Volver");
            }

        }

        private void Division_Clicked(object sender, EventArgs e)
        {
            string real = N1RealXAML.Text;
            string imaginara = N1ImaginariaXAML.Text;
            string real2 = N2RealXAML.Text;
            string imaginara2 = N2ImaginariaXAML.Text;
            Conversiones conv = new Conversiones();
            Imaginarios im = new Imaginarios();
            Imaginarios im2 = new Imaginarios();
            Imaginarios res = new Imaginarios();
            if (real != null && imaginara != null && real2 != null && imaginara2 != null
                && !real.Length.Equals(0) && !imaginara.Length.Equals(0)
                && !real2.Length.Equals(0) && !imaginara2.Length.Equals(0))
            {
                im.setReal(float.Parse(real));
                im.setImaginaria(float.Parse(imaginara));
                im2.setReal(float.Parse(real2));
                im2.setImaginaria(float.Parse(imaginara2));
                res = im.division(im2);
                if (res.getImaginaria() < 0)
                {
                    Rreal.Text = res.getReal().ToString() + "" + res.getImaginaria().ToString() + "i";
                }
                else
                {
                    Rreal.Text = res.getReal().ToString() + "+" + res.getImaginaria().ToString() + "i";
                }
            }
            else
            {
                DisplayAlert("Advertencia", "Campos incompletos", "Volver");
            }
        }

        private void Modulo_Clicked(object sender, EventArgs e)
        {
            string real = RealXAMLMod.Text;
            string imaginara = ImaginariaXAMLMod.Text;
            Conversiones conv = new Conversiones();
            Imaginarios im = new Imaginarios();
            if (real != null && imaginara != null && !real.Length.Equals(0) && !imaginara.Length.Equals(0))
            {
                im.setReal(float.Parse(real));
                im.setImaginaria(float.Parse(imaginara));
                ResultadoMod.Text = im.getModulo().ToString();
            }
            else
            {
                DisplayAlert("Advertencia", "Campos incompletos", "Volver");
            }
        }
    }
}