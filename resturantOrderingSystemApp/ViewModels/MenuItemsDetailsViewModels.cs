using System;
using Xamarin.Forms;
using resturantOrderingSystemApp.Views;
using resturantOrderingSystemApp.Interfaces;
using resturantOrderingSystemApp.Models;
using resturantOrderingSystemApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MenuItem = resturantOrderingSystemApp.Models.MenuItem;

namespace resturantOrderingSystemApp.ViewModels

{
    public class MenuItemsDetailsViewModel : BaseViewModel
    {
        private readonly IMenuService _menuService;
        public ObservableCollection<MenuItemDetails> menuItemDetails { get; set; }
        public MenuItem _currentMenuItem;
        public MenuItemDetails _currentMenuItemDetails;

        public ObservableCollection<MenuItem> menuItem 
        {
            get => menuItem;
            set
            {
                menuItem = value;
                OnPropertyChanged(nameof(MenuItem));
            }
        }


        public async Task GetMenuItemDetails() 
        {
            try
            {
                CurrentMenuItemDetails = await _menuService.GetMenuItemDetails(CurrentMenuItem.itemId);
                Console.WriteLine(CurrentMenuItemDetails);
            }
            catch (Exception ex) //if its not working, throws an error
            {
                Console.WriteLine(ex.Message);
            }
        }


        public MenuItem CurrentMenuItem
        {
            get => _currentMenuItem;
            set
            {
                _currentMenuItem = value;
                OnPropertyChanged(nameof(CurrentMenuItem));
            }
        }

        public MenuItemDetails CurrentMenuItemDetails
        {
            get => _currentMenuItemDetails;
            set
            {
                _currentMenuItemDetails = value;
                OnPropertyChanged(nameof(CurrentMenuItemDetails));
            }
        }

        public MenuItemsDetailsViewModel(IMenuService menuService)
        {
            _menuService = menuService;

        }
    }
}

