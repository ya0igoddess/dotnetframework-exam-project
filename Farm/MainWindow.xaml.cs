using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using FarmModel;

namespace FarmView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FarmModel.Farm farm;
        ObservableCollection<string> actionLog;
        
        public MainWindow()
        {
            InitializeComponent();

            farm = new FarmModel.Farm();
            AnimalListView.ItemsSource = farm.animalsList;
            actionLog = new ObservableCollection<string>();
            ActionLogListBox.ItemsSource = actionLog;
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
            farm = new FarmModel.Farm();
        }

        private void PerformActionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                 actionLog.AddAll<string>(farm.PerformActionToAnimals((FarmModel.Action)ChooseActionComboBox.SelectedItem,
                                            AnimalListView.SelectedItems.Cast<Animal>()));
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
