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
    public partial class Calculadora : ContentPage
    {
        public Calculadora()
        {
            InitializeComponent();
        }

        private void Modulo_Clicked(object sender, EventArgs e)
        {
            string real = RealXAML.Text;
            string imaginara = ImaginariaXAML.Text;
            Conversiones conv = new Conversiones();
            Imaginarios im = new Imaginarios();
            if (real != null && imaginara != null && !real.Length.Equals(0) && !imaginara.Length.Equals(0))
            {
                im.setReal(float.Parse(real));
                im.setImaginaria(float.Parse(imaginara));
                Resultado.Text = im.getModulo().ToString();
            }
            else
            {
                DisplayAlert("Advertencia", "Campos incompletos", "Volver");
            }
        }
    }

    public class Conversiones
    {

        ///Aqui esta el arreglo global en donde se guardan los numeros en su forma compleja, para llenarlo previamente se debe  
        //Hacer funvionar el metodo ******public String Raices(Imaginarios im, int n)****** 


        List<Imaginarios> arreglo = new List<Imaginarios>();

        public float angulo;
        public float mod;



        public Conversiones()
        {

        }


        public void CalcAngulo(Imaginarios im)
        {

            float coseno, seno;
            mod = im.CalModulo();

            if (im.getReal().Equals(-1) && im.getImaginaria().Equals(0))
            {
                this.angulo = 180;
            }
            else
            {
                coseno = im.getReal() / mod;
                seno = im.getImaginaria() / mod;

                angulo = (float)((Math.Atan(seno / coseno)) * 57.295779513);
            }

            if (angulo < 0)
            {

                angulo = 360 + angulo;
            }


        }

        public float getAngulo()
        {
            return angulo;
        }


        public float getMod()
        {
            return mod;
        }


        public string trigonometrica(Imaginarios im)
        {

            this.CalcAngulo(im);

            return this.mod + "(Cos(" + this.angulo + "°) + iSen(" + this.angulo + "°)";

        }


        public String euler(Imaginarios im)
        {
            this.CalcAngulo(im);
            return this.mod + "e^( " + this.angulo + "°)i";
        }

        public String Raices(Imaginarios im, int n)
        {
            String formula = "";
            this.CalcAngulo(im);
            float suma = (float)(Math.Pow(im.getReal(), 2) + Math.Pow(im.getImaginaria(), 2));
            float potencia = (float)1 / (n + 2);
            float r = (float)Math.Pow(suma, potencia);
            /// el arreglo en donde se guardaran los vectores a graficar
            for (int k = 0; k < n; k++)
            {
                float anguloN = (float)((this.angulo + 2 * k * Math.PI) / n);
                float auxR, auxI;
                auxR = (float)(Math.Cos(anguloN) * r);
                auxI = (float)(Math.Sin(anguloN) * r);
                //se estan guardando los numeros imaginarios en su forma compleja. 
                Imaginarios aux = new Imaginarios(auxR, auxI);
                arreglo.Add(aux);
                formula = formula + "Para k=" + k + ", \n   " + r + "e^(" + anguloN + ")i " + "\n   Z= " + auxR + " + i" + auxI + "\n";
            }
            return formula;
        }

        public String Potencias(Imaginarios im, int n)
        {
            float newAngulo;
            this.CalcAngulo(im);
            newAngulo = this.getAngulo() * n;
            String Formula = " (" + this.euler(im) + ")^(" + n + ") \n = e^(" + newAngulo + ")i \n = Cos(" + newAngulo + ") + iSen(" + newAngulo + ")";
            return Formula;
        }

        public float ConRadianes()
        {
            return (float)(Math.PI * this.angulo) / 180;
        }

    }

    public class Imaginarios
    {
        protected float real;
        protected float imaginaria;

        public Imaginarios(float real, float imaginaria)
        {
            this.real = real;
            this.imaginaria = imaginaria;

        }

        public Imaginarios()
        {
            this.imaginaria = 0;
            this.real = 0;
        }

        ///Calcular el modulo
        public float CalModulo()
        {
            return (float)Math.Sqrt(Math.Pow(this.real, 2) + Math.Pow((this.imaginaria), 2));
        }

        ////Suma 
        public Imaginarios suma(Imaginarios n1)
        {
            Imaginarios total = new Imaginarios();
            total.real = (this.real + n1.real);
            total.imaginaria = (this.imaginaria + n1.imaginaria);
            return total;
        }

        //Resta
        public Imaginarios resta(Imaginarios n1)
        {
            Imaginarios total = new Imaginarios();
            total.real = (this.real - n1.real);
            total.imaginaria = (this.imaginaria - n1.imaginaria);
            return total;
        }

        //Multiplicacion
        public Imaginarios multiplicacion(Imaginarios n1)
        {
            Imaginarios total = new Imaginarios();
            total.real = ((this.real * n1.real) - (this.imaginaria * n1.imaginaria));
            total.imaginaria = ((this.real * n1.imaginaria) + (this.imaginaria * n1.real));
            return total;
        }

        //División
        public Imaginarios division(Imaginarios n1)
        {
            Imaginarios total = new Imaginarios();
            total.real = (((this.real * n1.real) + (this.imaginaria * n1.imaginaria)) / ((n1.real * n1.real) + (n1.imaginaria * n1.imaginaria)));
            total.imaginaria = (((this.real * n1.imaginaria) - (this.imaginaria * n1.real)) / ((n1.real * n1.real) + (n1.imaginaria * n1.imaginaria)));
            return total;
        }

        ////Set and Get de los atributos principales
        public float getReal()
        {
            return real;
        }

        public void setReal(float real)
        {
            this.real = real;
        }

        public float getImaginaria()
        {
            return imaginaria;
        }

        public void setImaginaria(float imaginaria)
        {
            this.imaginaria = imaginaria;
        }

        /// Get especial para retornar Modulo
        public float getModulo()
        {
            return CalModulo();
        }

    }

    //public class Funcion
    //{
    //    private string operacion;
    //    private string resultadoConversion;
    //    private string resultadoOperacion;
    //    private int indiceIni;
    //    private int indiceFin;
    //    private string valor;

    //    public Funcion()
    //    {

    //    }

    //    public string evaluar(string oper, string val)
    //    {
    //        this.operacion = oper;
    //        this.valor = val;
    //        this.resultadoConversion = analizaCadena(this.operacion);
    //        this.resultadoConversion = reemplazaOperacionJS(this.resultadoConversion);
    //        return this.resultadoOperacion = calculo(this.resultadoConversion);
    //    }

    //    private string calculo(string cadena)
    //    {
    //        return null; // eval(cadena).toString();
    //    }

    //    private string analizaCadena(string cadena)
    //    {
    //        cadena = cadena.Replace("x", this.valor);
    //        cadena = quitarEspacios(cadena);
    //        cadena = "?" + cadena;
    //        char[] vectorCadena = cadena.ToCharArray();
    //        if (cadena.Contains("^"))
    //        {
    //            cadena = reemplazaPotencia(vectorCadena, cadena);
    //        }
    //        vectorCadena = cadena.ToCharArray();
    //        if (cadena.Contains("cos"))
    //        {
    //            cadena = reemplazaTrigonometrica(vectorCadena, cadena, ".co", 'c');
    //        }
    //        vectorCadena = cadena.ToCharArray();
    //        if (cadena.Contains("sen"))
    //        {
    //            cadena = reemplazaTrigonometrica(vectorCadena, cadena, ".si", 's');
    //        }
    //        vectorCadena = cadena.ToCharArray();
    //        if (cadena.Contains("tan"))
    //        {
    //            cadena = reemplazaTrigonometrica(vectorCadena, cadena, ".ta", 't');
    //        }
    //        return cadena;
    //    }

    //    private string reemplazaParIzq(char[] cadena, int indice)
    //    {
    //        List<char> lista1 = new List<char>();
    //        List<char> lista2 = new List<char>();
    //        string res = "";
    //        int i;
    //        for (i = indice - 1; i >= 0; i--)
    //        {
    //            if (cadena[i] == ')')
    //            {
    //                lista1.Add(cadena[i]);
    //            }
    //            else
    //            {
    //                if (cadena[i] == '(')
    //                {
    //                    lista2.Add(cadena[i]);
    //                }
    //            }
    //            res = cadena[i] + res;
    //            if ((lista1.Capacity == lista2.Capacity) && (i != (indice - 1)))
    //            {
    //                this.indiceIni = i;
    //                return res;
    //            }
    //        }
    //        return null;
    //    }

    //    private string reemplazaParDer(char[] cadena, int indice)
    //    {
    //        List<char> lista1 = new List<char>();
    //        List<char> lista2 = new List<char>();
    //        string res = "";
    //        int i;
    //        for (i = indice + 1; i < cadena.Length; i++)
    //        {
    //            if (cadena[i] == '(')
    //            {
    //                lista1.Add(cadena[i]);
    //            }
    //            else
    //            {
    //                if (cadena[i] == ')')
    //                {
    //                    lista2.Add(cadena[i]);
    //                }
    //            }
    //            res += cadena[i];
    //            if ((lista1.Capacity == lista2.Capacity) && (i != (indice + 1)))
    //            {
    //                this.indiceFin = i + 1;
    //                return res;
    //            }
    //        }
    //        return null;
    //    }

    //    private string reemplazaNumIzq(char[] cadena, int indice)
    //    {
    //        string resultadoBase = "";
    //        string res = "";
    //        for (int i = indice - 1; i >= 0; i--)
    //        {
    //            res = resultadoBase;
    //            res += cadena[i];
    //            if (isNumeric(res))
    //            {
    //                resultadoBase = cadena[i] + resultadoBase;
    //                this.indiceIni = i;
    //            }
    //            else
    //            {
    //                break;
    //            }
    //        }
    //        return resultadoBase;
    //    }

    //    private string reemplazaNumDer(char[] cadena, int indice)
    //    {
    //        string resultadoBase = "";
    //        string res = "";
    //        for (int i = indice + 1; i < cadena.Length; i++)
    //        {
    //            res = resultadoBase;
    //            res += cadena[i];
    //            if (isNumeric(res))
    //            {
    //                resultadoBase += cadena[i];
    //                this.indiceIni = i + 1;
    //            }
    //            else
    //            {
    //                break;
    //            }
    //        }
    //        return resultadoBase;
    //    }

    //    private bool isNumeric(string str)
    //    {
    //        if (!str.Equals("."))
    //        {
    //            try
    //            {
    //                double.Parse(str);
    //            }
    //            catch
    //            {
    //                return false;
    //            }
    //            return true;
    //        }
    //        else
    //        {
    //            return true;
    //        }
    //    }

    //    private string reemplazaPotencia(char[] vectorCadena, string cadena)
    //    {
    //        string resIzq = "", resDer = "";
    //        for (int indice = 0; indice < vectorCadena.Length; indice++)
    //        {
    //            if (vectorCadena[indice] == '^')
    //            {
    //                if (vectorCadena[indice - 1] == ')')
    //                {
    //                    resIzq = reemplazaParIzq(vectorCadena, indice);
    //                }
    //                else
    //                {
    //                    resIzq = reemplazaNumIzq(vectorCadena, indice);
    //                }
    //                if (vectorCadena[indice + 1] == '(')
    //                {
    //                    resDer = reemplazaParDer(vectorCadena, indice);
    //                }
    //                else
    //                {
    //                    resDer = reemplazaNumDer(vectorCadena, indice);
    //                }
    //                vectorCadena = (cadena.Substring(0, this.indiceIni) + ".po("
    //                    + resIzq + "," + resDer + ")" + (cadena.Substring(this.indiceFin, cadena.Length))).ToCharArray();
    //                cadena = (cadena.Substring(0, this.indiceIni) + ".po("
    //                    + resIzq + "," + resDer + ")" + (cadena.Substring(this.indiceFin, cadena.Length)));
    //                indice = 0;
    //            }
    //        }
    //        return cadena;
    //    }

    //    private string reemplazaTrigonometrica(char[] vectorCadena, string cadena, string operacion, char caracter)
    //    {
    //        string resDer = "";
    //        for (int indice = 0; indice < vectorCadena.Length; indice++)
    //        {
    //            if ((vectorCadena[indice] == caracter) && ((vectorCadena)[indice - 1] != '.') && (indice != 0))
    //            {
    //                if (vectorCadena[indice + 3] == '(')
    //                {
    //                    resDer = reemplazaParDer(vectorCadena, indice + 2);
    //                }
    //                else
    //                {
    //                    resDer = reemplazaNumDer(vectorCadena, indice + 2);
    //                }

    //                vectorCadena = (cadena.Substring(0, indice) + operacion + "("
    //                        + resDer + ")" + (cadena.Substring(this.indiceFin, cadena.Length))).ToCharArray();
    //                cadena = (cadena.Substring(0, indice) + operacion + "("
    //                        + resDer + ")" + (cadena.Substring(this.indiceFin, cadena.Length)));
    //                indice = 0;
    //            }
    //        }
    //        return cadena;
    //    }

    //    public string getResultadoConversion()
    //    {
    //        return this.resultadoConversion;
    //    }

    //    public string getResultadoOperacion()
    //    {
    //        return resultadoOperacion;
    //    }

    //    private string quitarEspacios(string sTexto)
    //    {
    //        string sCadenaSinBlancos = "";
    //        for (int x = 0; x < sTexto.Length; x++)
    //        {
    //            if (sTexto[x] != ' ')
    //            {
    //                sCadenaSinBlancos += sTexto[x];
    //            }
    //        }
    //        return sCadenaSinBlancos;
    //    }

    //    private String reemplazaOperacionJS(String operacion)
    //    {
    //        this.resultadoConversion = operacion.Replace(".po", "Math.Pow");
    //        this.resultadoConversion = this.resultadoConversion.Replace(".co", "Math.Cos");
    //        this.resultadoConversion = this.resultadoConversion.Replace(".si", "Math.Sin");
    //        this.resultadoConversion = this.resultadoConversion.Replace(".ta", "Math.Tan");
    //        return this.resultadoConversion.Substring(1, this.resultadoConversion.Length);
    //    }




    //}

}