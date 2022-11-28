using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
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
    public sealed partial class AjoutProjet : Page
    {
        public AjoutProjet()
        {
            this.InitializeComponent();
            liste.ItemsSource = GestionBD.getInstance().AffficheComboBox();
        }

        private void btnvalider_Click(object sender, RoutedEventArgs e)
        {

            double budget = Double.Parse(tbxbudget.Text);


            if (budget < 10000 || budget > 100000)
            {
                tblbudget.Visibility = Visibility.Visible;
            }


            if (tbxNum.Text.Trim() == "")
            {


                ErreurNum.Visibility = Visibility.Visible;

            }

            //if (tbxbudget.Text.Trim() == null)
            //{


            //    ErreurBudget.Visibility = Visibility.Visible;

            //}

            if (tbxdes.Text.Trim() == "")
            {


                Erreurdes.Visibility = Visibility.Visible;

            }
            //if (calendar.DataContext == null)
            //{


            //    ErreurCalendar.Visibility = Visibility.Visible;

            //}

            if (liste.Text.Trim() == "")
            {


                ErreurEmployer.Visibility = Visibility.Visible;

            }


           

            DateTime d = calendar.Date.Value.Date;
           calendar.MaxDate = new DateTimeOffset(new DateTime(2022, 12, 1));
            calendar.MinDate = new DateTimeOffset(new DateTime(2021, 1, 1));

            Employe emp = liste.SelectedItem as Employe;

            GestionBD.getInstance().AjouterProjet(tbxNum.Text, d, budget,tbxdes.Text, emp.Matricule);

          
        }
    }
}
