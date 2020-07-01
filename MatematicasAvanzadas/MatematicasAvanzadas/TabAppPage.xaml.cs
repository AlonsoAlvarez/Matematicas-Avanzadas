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
    public partial class TabAppPage : TabbedPage
    {
        public TabAppPage()
        {
            InitializeComponent();
            //           Children.Add(new Calculadora());
            Children.Add(new CalSRMD());
            Children.Add(new RaizYpot());
            Children.Add(new Integrales());
            Children.Add(new RK4());
            Children.Add(new Series());
        }
    }
}