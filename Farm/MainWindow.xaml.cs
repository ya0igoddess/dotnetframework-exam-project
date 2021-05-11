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
            AnimalListView.ItemsSource = farm.GetFilteredAnimals(FarmModel.AnimalsKinds.All);
        }

        private void ChooseAnimaInListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AnimalListView.ItemsSource = farm.GetFilteredAnimals(
                                         (FarmModel.AnimalsKinds)AnimalViewCB.SelectedItem);
        }

        private void AddCustomAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                farm.addAnimal((FarmModel.AnimalsKinds)AnimalViewCB.SelectedItem,
                               (FarmModel.AnimalSex)CustomAnimalSexCB.SelectedItem,
                                int.Parse(CustomAnimalAgeCB.Text),
                                int.Parse(CustomAnimalWeightTB.Text));
            }
            catch(Exception)
            {
                //TODO add ExceptionHandler
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            farm = new FarmModel.Farm();
        }

        private void PerformActionButton_Click(object sender, RoutedEventArgs e)
        {
            farm.PerformActionToAnimals((FarmModel.Action)ChooseActionComboBox.SelectedItem,
                                        AnimalListView.SelectedItems);
        }
    }
}
