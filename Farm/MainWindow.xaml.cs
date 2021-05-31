using System;
using System.Collections.Generic;
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
using FarmModel;

namespace FarmView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FarmModel.Farm farm;

        public MainWindow()
        {
            InitializeComponent();

            farm = new FarmModel.Farm();
            AnimalListView.ItemsSource = farm.animalsList;
        }

        private void ChooseAnimaInListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            farm.SetFilterToAnimalsList((AnimalsKinds)AnimalViewCB.SelectedItem);
        }

        private void AddCustomAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                farm.AddAnimal((FarmModel.AnimalsKinds)AnimalViewCB.SelectedItem,
                               (FarmModel.AnimalSex)CustomAnimalSexCB.SelectedItem,
                                int.Parse(CustomAnimalAgeCB.Text),
                                double.Parse(CustomAnimalWeightTB.Text));
            }
            catch(Exception ex)    
            {
                MessageBox.Show(ex.Message, "Error", 
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //creates empty farm
            farm = new Farm();
        }

        private void PerformActionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                farm.PerformActionToAnimals((FarmModel.Action)ChooseActionComboBox.SelectedItem,
                                            AnimalListView.SelectedItems.Cast<Animal>());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
            }
        }
    }   
}
