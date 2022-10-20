using resturantOrderingSystemApp.Navigation;
using Xamarin.Forms;
using resturantOrderingSystemApp.Views;
using resturantOrderingSystemApp.Interfaces;
using resturantOrderingSystemApp.Models;
using resturantOrderingSystemApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System;
using Xamarin.Essentials;

namespace resturantOrderingSystemApp.ViewModels
{
    public class TablesViewModel : BaseViewModel

    {
        public ObservableCollection<Table> tables { get; set; }
        public TablesData SelectedItem { get; set; }
        private readonly ITableService _tableService;
        public Command tableSelectedCommand { get; set; }

        public TablesViewModel(ITableService ApiTableService) 
        {
            _tableService = ApiTableService;
            Tables = new ObservableCollection<Table>();
            tableSelectedCommand = new Command<Table>(OnTableSelected);
        }

        public ObservableCollection<Table> Tables
        {
            get => tables;
            set
            {
                tables = value;
                OnPropertyChanged(nameof(Tables));
            }
        }

        public async Task GetAvailableTables() //gets all the table items
        {
            try
            {
                Tables.Clear(); //clears anything that was there before

                var retrievedTables = await _tableService.GetAvailableTables(); //retrieves all the tables
                foreach (var table in retrievedTables)
                {
                    if (table.attributes.tableStatus == "Available")
                    {
                        Tables.Add(table);
                    }
                }
            }
            catch (Exception ex) //if its not working, throws an error
            {
                Console.WriteLine(ex.Message);
            }
        }

        async void OnTableSelected(Table selectedItem)
        {
            if (selectedItem == null)
                Console.WriteLine("item null");
            else
            {
                Console.WriteLine("Selected Table");
                Console.WriteLine(selectedItem.tableNumber);
                await SecureStorage.SetAsync("tableNumber", selectedItem.tableNumber.ToString());
            }

            //save Table in local storage and update table status 
        }

    }


}
