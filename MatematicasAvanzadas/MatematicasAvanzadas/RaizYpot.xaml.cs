using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Datachart = Microcharts.Entry;

namespace MatematicasAvanzadas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RaizYpot : ContentPage
    {
        public RaizYpot()
        {
            InitializeComponent();
        }

        public List<Datachart> genInst(int num)
        {
            List<Datachart> datachartlist = new List<Datachart>();
            float val = 360 / num;
            for (int i = 0; i < num; i++)
            {
                datachartlist.Add(new Datachart(val)
                {
                    Color = SkiaSharp.SKColor.Parse(genHexRan()),
                    TextColor = SkiaSharp.SKColor.Parse(genHexRan()),
                    Label = "Punto" + i,
                    //ValueLabel = "3.4"
                });
            }
            return datachartlist;
        }

        private void Raiz_Clicked(object sender, EventArgs e)
        {
            var real = RealXAML.Text;
            var imag = ImaginariaXAML.Text;
            var num = ValPR.Text;
            Conversiones conv = new Conversiones();
            Imaginarios im = new Imaginarios();
            if (real != null && imag != null && num != null
                && !real.Length.Equals(0) && !imag.Length.Equals(0)
                && !num.Length.Equals(0))
            {
                im.setReal(float.Parse(real));
                im.setImaginaria(float.Parse(imag));
                Resultado.Text = "Raiz: \n" + conv.Raices(im, int.Parse(num));
                Resultado.HeightRequest = (int.Parse(num)*60)+8.5;
                Grafica.IsVisible = true;
                List<Datachart> datachartlist = new List<Datachart>();
                int nint = int.Parse(num);
                datachartlist = genInst(nint);
                Grafica.Chart = new Microcharts.RadarChart
                {
                    Entries = datachartlist
                };
            }
            else
            {
                DisplayAlert("Advertencia", "Campos incompletos", "Volver");
            }
        }

        public string genHexRan()
        {
            Random r = new Random();
            string res = "";
            for (int i = 0; i < 6; i++)
            {
                int n = r.Next(0, 15);
                if (n < 10)
                {
                    res += n;
                }
                else
                {
                    if (n == 10)
                    {
                        res += "a";
                    }
                    if (n == 11)
                    {
                        res += "b";
                    }
                    if (n == 12)
                    {
                        res += "c";
                    }
                    if (n == 13)
                    {
                        res += "d";
                    }
                    if (n == 14)
                    {
                        res += "e";
                    }
                    if (n == 15)
                    {
                        res += "f";
                    }
                }
            }
            Console.WriteLine("f(res)={0}", res);
            return res;
        }


        private void Potencia_Clicked(object sender, EventArgs e)
        {
            var real = RealXAML.Text;
            var imag = ImaginariaXAML.Text;
            var num = ValPR.Text;
            Conversiones conv = new Conversiones();
            Imaginarios im = new Imaginarios();
            if (real != null && imag != null && num != null
                && !real.Length.Equals(0) && !imag.Length.Equals(0)
                && !num.Length.Equals(0))
            {
                im.setReal(float.Parse(real));
                im.setImaginaria(float.Parse(imag));
                Resultado.Text = "Potencia: \n" + conv.Potencias(im, int.Parse(num));
                Resultado.HeightRequest = 100;
                Grafica.IsVisible = false;
            }
            else
            {
                DisplayAlert("Advertencia", "Campos incompletos", "Volver");
            }
        }
    }
}