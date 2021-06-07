using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
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
            actionLog = new ObservableCollection<string>();
            ActionLogListBox.ItemsSource = actionLog;
            UpdateFarmBinding();
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
            UpdateFarmBinding();
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

        // save farm button
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Save farm to file";
            dlg.FileName = "MyFarm";
            dlg.DefaultExt = ".txt";

            bool? result = dlg.ShowDialog();

            if (true == result)
            {
                try
                {
                    farm.SaveFarmToFile(dlg.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Exception handled",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }

        //open farm button
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open farm";
            dlg.DefaultExt = ".txt";

            bool? result = dlg.ShowDialog();

            if (true == result)
            {
                Farm tempFarm;
                try
                {
                    tempFarm = farm.LoadNewFarm(dlg.FileName);
                    farm = tempFarm;
                    UpdateFarmBinding();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Exception handled",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
            UpdateFarmBinding();
        }

        private void UpdateFarmBinding()
        {
            AnimalListView.ItemsSource = farm?.AnimalsList;
            actionLog?.Clear();
        }
    }   
}
