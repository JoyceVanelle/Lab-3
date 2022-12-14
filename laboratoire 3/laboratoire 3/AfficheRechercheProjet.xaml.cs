using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace laboratoire_3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AfficheRechercheProjet : Page
    {
        public AfficheRechercheProjet()
        {
            this.InitializeComponent();
            lvListe.ItemsSource = GestionBD.getInstance().GetProjet();


        }
        

        private void Rechercher_Click(object sender, RoutedEventArgs e)
        {
            DateTime d = calendar1.Date.Value.DateTime;
            lvListe.ItemsSource = GestionBD.getInstance().RechercheProjet(d);
        }
    }
}
