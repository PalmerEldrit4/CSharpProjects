using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
            public MainWindow()
            {
                InitializeComponent();
            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                bool valid = true;
                string fileName = @"..\..\info.txt";
                File.AppendAllText(fileName, "Name;Age;pets;" + "\n");

                string name = txtName.Text;
                //you can have validation method to check the name
                if (name.Length == 0)
                {
                    MessageBox.Show("please enter your name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    valid = false;
                }
                string age = "";
                if (rbtnBelow18.IsChecked == true)
                {
                    age = rbtnBelow18.Content.ToString();
                }
                else if (rbtnOver30.IsChecked == true)
                {
                    age = rbtnOver30.Content.ToString();
                }

                else if (rbtnOver80.IsChecked == true)
                {
                    age = rbtnOver80.Content.ToString();
                }
                else
                {
                    MessageBox.Show("please choose one of the age options");
                    valid = false;
                }
                List<string> petList = new List<string>();
                if (chboxCat.IsChecked == true)
                {
                    petList.Add(chboxCat.Content.ToString());
                }
                if (chboxDog.IsChecked == true)
                {
                    petList.Add(chboxDog.Content.ToString());
                }
                if (chboxOther.IsChecked == true)
                {
                    petList.Add(chboxCat.Content.ToString());
                }

                string pets = string.Join(",", petList);

                string continent = cmbContinents.Text;
                string preferredTemp = lblTemp.VerticalContentAlignment.ToString();

                if (valid == true)
                {
                    File.AppendAllText(fileName, $"{name};{age};{pets}");
                    MessageBox.Show("saved successfully");
                }
            }

            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("The form is loaded", "this is my caption",
                    MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            }
    }
    
}
