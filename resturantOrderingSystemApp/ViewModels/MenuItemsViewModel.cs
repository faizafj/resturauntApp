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
using MenuItem = resturantOrderingSystemApp.Models.MenuItem;

namespace resturantOrderingSystemApp.ViewModels
{
    public class MenuItemsViewModel : BaseViewModel

    {
        public ObservableCollection<MenuItem> menuItems { get; set; }
        public MenuItem SelectedItem { get; set; }
        public Command ViewMenuItemsCommand { get; set; }
        private readonly IMenuService _menuService;
        public Command menuItemSelectedCommand { get; set; }


        public MenuItemsViewModel(IMenuService ApiMenuService) //command for navigation
        {
            ViewMenuItemsCommand = new Command(viewMenuItemsPage);
            _menuService = ApiMenuService;
            MenuItems = new ObservableCollection<MenuItem>();
            menuItemSelectedCommand = new Command<MenuItem>(menuItemSelected);
        }

        private void viewMenuItemsPage() //pushes the nextPage which is orders
        {
            var nextPage = new MenuItemsPage();
            NavigationDispatcher.Instance.Navigation.PushAsync(nextPage);

        }


        public ObservableCollection<MenuItem> MenuItems 
        {
            get => menuItems;
            set
            {
                menuItems = value;
                OnPropertyChanged(nameof(MenuItems));
            }
        }

        public async Task GetMenuItems() //gets all the menu items
        {
            try
            {
                MenuItems.Clear(); //clears anything that was there before

                var retrievedMenuItems = await _menuService.GetMenuItems(); //retrieves all the menu items
                foreach (var menuItems in retrievedMenuItems)
                {
                    MenuItems.Add(menuItems);
                }
            }
            catch (Exception ex) //if its not working, throws an error
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void menuItemSelected(MenuItem selectedMenuItem)
        {
            Console.WriteLine("Menu Item Selected");
            var newPage = new MenuItemDetailsPage(selectedMenuItem);
            NavigationDispatcher.Instance.Navigation.PushAsync(newPage);
        }
    }
}
