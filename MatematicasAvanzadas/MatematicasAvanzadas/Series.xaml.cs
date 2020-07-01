using Calculus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datachart = Microcharts.Entry;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MatematicasAvanzadas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Series : ContentPage
    {
        public Series()
        {
            InitializeComponent();
        }

        private void TrCos_Clicked(object sender, EventArgs e)
        {
            string funcion = funXAML.Text;
            string limS = supXAML.Text;
            string limI = infXAML.Text;
            string n = nXAML.Text;
            if (funcion != null && funcion.Length != 0 && n != null && n.Length != 0
                && limS != null && limS.Length != 0 && limI != null && limI.Length != 0)
            {
                GridProgress.IsVisible = true;
                infXAML.Text = "0";
                Resultado.Text = "Procesando.....";
                SeriesFourier sf = new SeriesFourier(funcion, float.Parse("0"), float.Parse(limS), int.Parse(n));
                sf.trCos();
                List<Datachart> datachartlist = new List<Datachart>();
                datachartlist = genInst(sf.puntos, sf.puntos2);
                Grafica.Chart = new Microcharts.LineChart
                {
                    Entries = datachartlist
                };
                Resultado.Text = sf.cos;
                Resultado.HeightRequest = (int.Parse(n) * 8.3) + 8.5;
                ResGraf.Text = genCompl(sf.puntos2, sf.puntos);
                ResGraf.HeightRequest = (sf.puntos2.Count * 13) + 8.5;
                sf.csf = 0;
                GridProgress.IsVisible = false;
            }
            else
            {
                DisplayAlert("Advertencia", "Campos incompletos", "Volver");
            }
        }

        private void TrSem_Clicked(object sender, EventArgs e)
        {
            string funcion = funXAML.Text;
            string limS = supXAML.Text;
            string limI = infXAML.Text;
            string n = nXAML.Text;
            if (funcion != null && funcion.Length != 0 && n != null && n.Length != 0
                && limS != null && limS.Length != 0 && limI != null && limI.Length != 0)
            {

                GridProgress.IsVisible = true;
                infXAML.Text = "0";
                Resultado.Text = "Procesando.....";
                SeriesFourier sf = new SeriesFourier(funcion, float.Parse("0"), float.Parse(limS), int.Parse(n));
                sf.trSen();
                List<Datachart> datachartlist = new List<Datachart>();
                datachartlist = genInst(sf.puntos, sf.puntos2);
                Grafica.Chart = new Microcharts.LineChart
                {
                    Entries = datachartlist
                };
                Resultado.Text = sf.sen;
                Resultado.HeightRequest = (int.Parse(n) * 8.3) + 8.5;
                ResGraf.Text = genCompl(sf.puntos2, sf.puntos);
                ResGraf.HeightRequest = (sf.puntos2.Count * 13) + 8.5;
                sf.csf = 0;
                GridProgress.IsVisible = false;
            }
            else
            {
                DisplayAlert("Advertencia", "Campos incompletos", "Volver");
            }
        }

        private void Serie_Clicked(object sender, EventArgs e)
        {
            string funcion = funXAML.Text;
            string limS = supXAML.Text;
            string limI = infXAML.Text;
            string n = nXAML.Text;
            if (funcion != null && funcion.Length != 0 && n != null && n.Length != 0
                && limS != null && limS.Length != 0 && limI != null && limI.Length != 0)
            {

                GridProgress.IsVisible = true;
                Resultado.Text = "Procesando.....";
                SeriesFourier sf = new SeriesFourier(funcion, float.Parse(limI), float.Parse(limS), int.Parse(n));
                sf.Paridad();
                List<Datachart> datachartlist = new List<Datachart>();
                datachartlist = genInst(sf.puntos, sf.puntos2);
                Grafica.Chart = new Microcharts.LineChart
                {
                    Entries = datachartlist
                };
                Resultado.Text = sf.sx;
                ResGraf.HeightRequest = (sf.csf * 8.3) + 8.5;
                ResGraf.Text = genCompl(sf.puntos2, sf.puntos);
                ResGraf.HeightRequest = (sf.puntos2.Count * 13) + 8.5;
                sf.csf = 0;

                GridProgress.IsVisible = false;
            }
            else
            {
                DisplayAlert("Advertencia", "Campos incompletos", "Volver");
            }
        }

        private List<Datachart> genInst(List<float> dat, List<float> dat2)
        {
            List<Datachart> datachartlist = new List<Datachart>();
            for (int i = 0; i < dat.Count; i++)
            {
                datachartlist.Add(new Datachart((float)(dat[i]))
                {
                    Color = SkiaSharp.SKColor.Parse(genHexRan()),
                    TextColor = SkiaSharp.SKColor.Parse(genHexRan()),
                    Label = "",//dat2[i].ToString(),
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

        public string genCompl(List<float> real, List<float> imag)
        {
            string res = "";
            if (real.Count == imag.Count)
            {
                for (int i = 0; i < real.Count; i++)
                {
                    if (0 < imag[i])
                    {

                        if (i % 2 != 0)
                        {
                            res += "P" + i + ": " + real[i] + " + " + imag[i] + " i \n";
                        }
                        else
                        {
                            res += "P" + i + ": " + real[i] + " + " + imag[i] + " i     ";
                        }
                    }
                    else
                    {

                        if (i % 2 != 0)
                        {
                            res += "P" + i + ": " + real[i] + " " + imag[i] + " i \n";
                        }
                        else
                        {
                            res += "P" + i + ": " + real[i] + " " + imag[i] + " i     ";
                        }
                    }
                }
                return res;
            }
            else
            {
                return res;
            }
        }

        private void Ejemplo_Clicked(object sender, EventArgs e)
        {
            funXAML.Text = "cos(x*4)^3";
            supXAML.Text = "5";
            infXAML.Text = "-5";
            nXAML.Text = "9";
        }
    }



    public class SeriesFourier
    {

        public int csf = 0;
        string funcion;
        float limS, limI;
        public string cos = "", sen = "", sx = "";
        int n;
        Integrar IS = new Integrar();
        public List<float> puntos = new List<float>();
        public List<float> puntos2 = new List<float>();

        public void trCos()
        {
            Calculo AnalizadorDeFunciones = new Calculo();
            string AN;
            bool pasa = false;
            for (float i = this.limI; i < this.limS; i = (float)(i + .035))
            {
                float suma = 0;
                AN = "";
                for (int j = 1; j < n + 1; j++)
                {
                    float z = (float)((j * 3.1416) / limS);
                    AN = this.funcion + "*(cos(" + z.ToString() + "*(x)" + "))";
                    float aux = (float)((float)((IS.trapecioComp(AN, limI.ToString(), limS.ToString())) * (Math.Sqrt(2 / Math.PI))) * Math.Cos(z * i));
                    suma += aux;
                    if (pasa == false)
                    {
                        if (j % 2 != 0)
                        {
                            this.cos += "a" + j + "= " + aux + "    ";
                        }
                        else
                        {
                            this.cos += "a" + j + "= " + aux + "\n";
                        }
                    }
                }
                pasa = true;
                puntos.Add(suma);
                puntos2.Add(i);
            }
        }

        public void trSen()
        {
            Calculo AnalizadorDeFunciones = new Calculo();
            string BN;
            bool pasa = false;
            for (float i = this.limI; i < this.limS; i = (float)(i + .035))
            {
                float suma = 0;
                BN = "";
                for (int j = 1; j < n + 1; j++)
                {
                    float z = (float)((j * 3.1416) / limS);
                    BN = this.funcion + "*(sen(" + z.ToString() + "*(x)" + "))";
                    float aux = (float)((float)((IS.trapecioComp(BN, limI.ToString(), limS.ToString())) * (Math.Sqrt(2 / Math.PI))) * Math.Sin(z * i));
                    suma += aux;
                    if (pasa == false)
                    {
                        if (j % 2 != 0)
                        {
                            this.sen += "b" + j + "= " + aux + "    ";
                        }
                        else
                        {
                            this.sen += "b" + j + "= " + aux + "\n";
                        }
                    }
                }
                pasa = true;
                puntos.Add(suma);
                puntos2.Add(i);
            }
        }




        public SeriesFourier(string f, float a, float b, int n)
        {
            this.funcion = f;
            this.limI = a;
            this.limS = b;
            this.n = n;
        }

        public void Paridad()
        {
            Calculo AnalizadorDeFunciones = new Calculo();
            bool pasa = false;
            double an1 = 0, an2 = 0;
            bool gr = false;
            if (AnalizadorDeFunciones.Sintaxis(funcion, 'x'))
            {
                an1 = AnalizadorDeFunciones.EvaluaFx(limI);
                an2 = AnalizadorDeFunciones.EvaluaFx(limS);
                gr = true;
            }
            if (an1 == an2 && gr == true)
            {
                float a0 = (float)(IS.trapecioComp(funcion, limI.ToString(), limS.ToString()) / Math.PI /*limS*/);
                string AN;
                //                float an = 0;
                for (float i = this.limI; i < this.limS; i = (float)(i + .035))
                {
                    float suma = 0;
                    AN = "";
                    for (int j = 1; j < n + 1; j++)
                    {
                        float z = (float)((j * 3.1416) / Math.PI /*limS*/);
                        AN = this.funcion + "*(cos(" + z.ToString() + "*(x)" + "))";
                        float aux1 = (float)((IS.trapecioComp(AN, limI.ToString(), limS.ToString())) / Math.PI);
                        float aux = (float)(aux1 /*limS */* Math.Cos(z * i));

                        suma += aux;

                        if (pasa == false)
                        {
                            this.sx += "S(" + j + "x)= " + a0 + " +Σ (" + aux1 + ")*(cos(" + j + "x)) + (" + 0.0 + ")*(sen(" + j + "x))" + "\n";   
                            pasa = true;
                            this.csf++;
                        }
                    }
                    pasa = true;
                    suma += a0 / 2;
                    puntos.Add(suma);
                    puntos2.Add(i);
                }
            }
            else
            {
                ///IMPAR BN
                float a0 = (float)(IS.trapecioComp(funcion, limI.ToString(), limS.ToString()) / Math.PI /*limS*/);
                if (a0 == 0)
                {
                    string BN = "";
                    for (float i = this.limI; i < this.limS; i = (float)(i + .035))
                    {
                        float suma = 0;
                        for (int j = 1; j < n + 1; j++)
                        {
                            float z = (float)((j * 3.1416) / Math.PI /*limS*/);
                            BN = this.funcion + "*(sen(" + z.ToString() + "*(x)" + "))";
                            float aux2 = (float)((IS.trapecioComp(BN, limI.ToString(), limS.ToString())) / Math.PI);
                            float aux = (float)((aux2 /*limS*/) * Math.Sin(z * i));
                            suma += aux;
                            if (pasa == false)
                            {
                                if (j % 2 != 0)
                                {
                                    this.sx += "S(" + j + "x)= " + a0 + " +Σ (" + 0.0 + ")*(cos(" + j + "x)) + (" + aux2 + ")*(sen(" + j + "x))" + "\n";
                                }
                                else
                                {
                                    this.sx += "S(" + j + "x)= " + a0 + " +Σ (" + 0.0 + ")*(cos(" + j + "x)) + (" + aux2 + ")*(sen(" + j + "x))" + "\n";
                                }

                            }
                        }
                        pasa = true;
                        puntos.Add(suma);
                        puntos2.Add(i);
                    }
                }
                else
                {
                    ///Para Calcular toda la serie "A0, AN, BN"     
                    string AN, BN;
                    //                    float an = 0;
                    for (float i = this.limI; i < this.limS; i = (float)(i + .035))
                    {
                        float suma = 0;
                        AN = "";
                        BN = "";
                        for (int j = 1; j < n + 1; j++)
                        {
                            float z = (float)((j * 3.1416) / Math.PI /*limS*/);
                            AN = this.funcion + "*(cos(" + z.ToString() + "*(x)" + "))";
                            float aux = (float)((float)((IS.trapecioComp(AN, limI.ToString(), limS.ToString())) / Math.PI /*limS*/) * Math.Cos(z * i));
                            BN = this.funcion + "*(sen(" + z.ToString() + "*(x)" + "))";
                            float aux2 = (float)((float)((IS.trapecioComp(BN, limI.ToString(), limS.ToString())) / Math.PI /*limS*/) * Math.Sin(z * i));
                            suma += aux + aux2;
                        }
                        suma += a0 / 2;
                        puntos.Add(suma);
                        puntos2.Add(i);
                    }
                }
            }
        }
    }


    public class Integrar
    {

        float limsup, liminf, resultado;
        string funcion;

        public float getLimsup()
        {
            return limsup;
        }

        public void setLimsup(float limsup)
        {
            this.limsup = limsup;
        }

        public float getLiminf()
        {
            return liminf;
        }

        public void setLiminf(float liminf)
        {
            this.liminf = liminf;
        }

        public string getFuncion()
        {
            return funcion;
        }

        public void setFuncion(string funcion)
        {
            this.funcion = funcion;
        }


        public Integrar()
        {

        }

        public Integrar(float i, float s, string f)
        {
            this.limsup = s;
            this.liminf = i;
            this.funcion = f;
        }

        public void VerificarIndices()
        {
            float a = -1 * this.liminf;
            if (a == this.limsup)
            {
                Paridad();
            }
            else
            {
                Simpson(this.limsup, this.liminf);
            }
        }


        public void Paridad()
        {
            Calculo AnalizadorDeFunciones = new Calculo();
            double an1 = 0, an2 = 0;
            bool gr = false;
            if (AnalizadorDeFunciones.Sintaxis(funcion, 'x'))
            {
                an1 = AnalizadorDeFunciones.EvaluaFx(limsup);
                an2 = AnalizadorDeFunciones.EvaluaFx(liminf);
                gr = true;
            }
            if (an1 == an2 && gr == true)
            {
                Simpson(this.limsup, 0);
                this.resultado = 2 * this.resultado;
            }
            else
            {
                this.resultado = 0;
            }
        }


        public void Simpson(float s, float i)
        {
            Calculo AnalizadorDeFunciones = new Calculo();
            double an1 = 0, an2 = 0;
            //            bool gr = false;
            float fa, fb, fcombinada;
            if (AnalizadorDeFunciones.Sintaxis(funcion, 'x'))
            {
                an1 = AnalizadorDeFunciones.EvaluaFx(limsup);
                an2 = AnalizadorDeFunciones.EvaluaFx(liminf);
                //                gr = true;

                fa = (float)AnalizadorDeFunciones.EvaluaFx((double)s);
                fb = (float)AnalizadorDeFunciones.EvaluaFx((double)i);
                double tmp = (i + s) / 2;
                fcombinada = (float)AnalizadorDeFunciones.EvaluaFx(tmp);
                this.resultado = ((s - i) / 6) * (fa + 4 * fcombinada + fb);
            }
        }

        public float trapecioComp(string infija, string va, string vb)
        {
            float res = 0;
            Calculo AnalizadorDeFunciones = new Calculo();
            if (AnalizadorDeFunciones.Sintaxis(infija, 'x'))
            {
                int n = 30;
                float fb = (float)AnalizadorDeFunciones.EvaluaFx(double.Parse(vb));
                float fa = (float)AnalizadorDeFunciones.EvaluaFx(double.Parse(va));
                float a = float.Parse(va);
                float b = float.Parse(vb);
                float h = (b - a) / n;
                float suma = 0;
                float aum = a;
                if (fa == fb)
                {
                    va = "0";
                    fb = (float)AnalizadorDeFunciones.EvaluaFx(double.Parse(vb));
                    fa = (float)AnalizadorDeFunciones.EvaluaFx(double.Parse(va));
                    a = float.Parse(va);
                    b = float.Parse(vb);
                    h = (b - a) / n;
                    suma = 0;
                    aum = a;
                    for (int i = 0; i < n; i++)
                    {
                        double tmp2 = AnalizadorDeFunciones.EvaluaFx(aum);
                        aum = aum + h;
                        suma = (float)(suma + tmp2);
                    }
                    res = 2 * ((h / 2) * (fa + (2 * suma) + fb));
                }
                else
                {
                    if (float.Parse(va) == -1 * float.Parse(vb))
                    {
                        res = 0;
                    }
                    else
                    {
                        for (int i = 0; i < n - 1; i++)
                        {
                            suma = (float)(suma + AnalizadorDeFunciones.EvaluaFx(aum));
                            aum = aum + h;
                        }
                        float x = (h / 2) * (fa + (2 * suma) + fb);
                        x += (float)(x * .07);
                        res = x;
                    }
                }
            }
            return res;
        }

    }


}