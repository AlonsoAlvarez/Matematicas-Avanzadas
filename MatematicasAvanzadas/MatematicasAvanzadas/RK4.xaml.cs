using Calculus;
using Microcharts;
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
    public partial class RK4 : ContentPage
    {
        public RK4()
        {
            InitializeComponent();
        }

        private void calcula_Clicked(object sender, EventArgs e)
        {
            var x0 = xXAML.Text;
            var y0 = yXAML.Text;
            var h = hXAML.Text;
            var n = nXAML.Text;
            var func = funXAML.Text;
            if (func != null && func.Length != 0 && n != null && n.Length != 0
                && h != null && h.Length != 0 && y0 != null && y0.Length != 0 && x0 != null && x0.Length != 0)
            {
//                GridProgress.IsVisible = true;
                RungeKuta RK = new RungeKuta(float.Parse(x0), float.Parse(y0), float.Parse(h), int.Parse(n), func);
                string kas = "";
                kas += "\n K1: " + RK.k1 + "    K2: " + RK.k2 + "   \n K3: " + RK.k3 + "    K4: " + RK.k4;
                //Console.WriteLine("f(res)={0}", kas);
                kXAML.Text = kas;
                Resultado.HeightRequest = (int.Parse(n)*8.3)+8.5;
                Resultado.Text = RK.Rec();
                List<Datachart> datachartlist = new List<Datachart>();
                datachartlist = genInst(RK.grafica);
                Grafica.Chart = new Microcharts.LineChart
                {
                    Entries = datachartlist
                };
 ///               GridProgress.IsVisible = false;
            }
            else
            {
                DisplayAlert("Advertencia", "Campos incompletos", "Volver");
            }
        }

        private List<Datachart> genInst(List<float> dat)
        {
            List<Datachart> datachartlist = new List<Datachart>();
            for (int i = 0; i < dat.Count; i++)
            {
                datachartlist.Add(new Datachart((float)(dat[i]))
                {
                    Color = SkiaSharp.SKColor.Parse(genHexRan()),
                    TextColor = SkiaSharp.SKColor.Parse(genHexRan()),
                    Label = "Y" + i,
                    ValueLabel = ""//dat[i].ToString()
                });
            }
            return datachartlist;
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

        private void ejemplo_Clicked(object sender, EventArgs e)
        {
            funXAML.Text = "sen(x*y)*x";
            hXAML.Text = "0.85";
            nXAML.Text = "15";
            xXAML.Text = "5";
            yXAML.Text = "6";
        }
    }


    public class RungeKuta
    {

        public float k1, k2, k3, k4, x0, y0, h;
        public int n;
        string cadena;

        public List<float> grafica = new List<float>();

        public RungeKuta(float x0i, float y0i, float hi, int ni, string func)
        {
            this.x0 = x0i;
            this.y0 = y0i;
            this.h = hi;
            this.n = ni;
            this.cadena = func;
            grafica.Add(y0);
            CalK1();
        }


        private void CalK1()
        {
            string y = y0.ToString();
            string aux = cadena.Replace("y", y);
            Calculo AnalizadorDeFunciones = new Calculo();
            float fa = 0;
            if (AnalizadorDeFunciones.Sintaxis(aux, 'x'))
            {
                fa = (float)AnalizadorDeFunciones.EvaluaFx(x0);
            }
            this.k1 = fa;
            CalK2();
        }

        public void CalK2()
        {
            double x1, y1;
            x1 = x0 + (.5f * this.h);
            y1 = y0 + (.5f * this.k1 * this.h);
            string aux = cadena.Replace("y", y1.ToString());
            Calculo AnalizadorDeFunciones = new Calculo();
            float fa = 0;
            if (AnalizadorDeFunciones.Sintaxis(aux, 'x'))
            {
                fa = (float)(AnalizadorDeFunciones.EvaluaFx(x1));
            }
            this.k2 = fa;
            CalK3();
        }


        public void CalK3()
        {
            double x1, y1;
            x1 = x0 + (.5f * this.h);
            y1 = y0 + (.5f * this.k2 * this.h);
            string aux = cadena.Replace("y", y1.ToString());
            Calculo AnalizadorDeFunciones = new Calculo();
            double fa = 0;
            if (AnalizadorDeFunciones.Sintaxis(aux, 'x'))
            {
                fa = AnalizadorDeFunciones.EvaluaFx(x1);
            }
            this.k3 = (float)fa;
            CalK4();
        }


        public void CalK4()
        {
            double x1, y1;
            x1 = x0 + h;
            y1 = y0 + (this.k3 * this.h);
            String aux = cadena.Replace("y", y1.ToString());
            Calculo AnalizadorDeFunciones = new Calculo();
            double fa = 0;
            if (AnalizadorDeFunciones.Sintaxis(aux, 'x'))
            {
                fa = AnalizadorDeFunciones.EvaluaFx(x1);
            }
            this.k4 = (float)fa;
        }

        public float res()
        {
            return (float)(this.y0 + (.166666) * (this.k1 + 2 * (this.k2 + this.k3) + this.k4) * h);
        }


        public string Rec()
        {
            string aux = "Y0= " + this.y0 + "    " + "Y1= " + this.res() + "\n";
            float xn = Calx(this.x0);
            float yn = res();
            //POrdenado par2 = new POrdenado(xn, yn);
            this.grafica.Add(yn);
            for (int i = 2; i < n; i++)
            {
                RungeKuta rp = new RungeKuta(xn, yn, this.h, 0, this.cadena);
                if (i % 2 != 0)
                {
                    aux = aux + "Y" + i + "= " + rp.res().ToString() + "\n";
                }
                else
                {
                    aux = aux + "Y" + i + "= " + rp.res().ToString() + "    ";
                }
                xn = Calx(rp.x0);
                yn = rp.res();
                //POrdenado par = new POrdenado(xn, yn);
                this.grafica.Add(yn);
            }
            return aux;
        }


        public float Calx(float x)
        {
            return (float)(x + this.h);
        }


    }




}