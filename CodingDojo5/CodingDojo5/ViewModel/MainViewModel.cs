using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace CodingDojo5.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private ItemVm currentItem;
        private RelayCommand<ItemVm> buyBtnClicked;
        public ObservableCollection<ItemVm> Items { get; set; }
        public ObservableCollection<ItemVm> Cart { get; set; }

        public ItemVm CurrentItem
        {
            get { return currentItem; }
            set { currentItem = value; RaisePropertyChanged(); }
        }
        

        public RelayCommand<ItemVm> BuyBtnClicked
        {
            get { return buyBtnClicked; }
            set { buyBtnClicked = value; RaisePropertyChanged(); }
        }



        public MainViewModel()
        {
            Cart = new ObservableCollection<ItemVm>();

            BuyBtnClicked = new RelayCommand<ItemVm>( (p) => 
            { Cart.Add(p);
            }, 
            (p) => { return true; } );

            Items = new ObservableCollection<ItemVm>();

            GenerateDemoData();
        }

        private void GenerateDemoData()
        {

            Items.Add(new ItemVm("My Lego", new BitmapImage(new Uri("Images/lego1.jpg", UriKind.Relative)), "-"));
            Items.Add(new ItemVm("My Playmobil", new BitmapImage(new Uri("Images/playmobil1.jpg", UriKind.Relative)), "-"));

            Items[1].ItemList.Add(new ItemVm("Playmobil 2", new BitmapImage(new Uri("Images/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[0].ItemList.Add(new ItemVm("Lego 2", new BitmapImage(new Uri("Images/lego2.jpg", UriKind.Relative)), "10+"));

        }

    }
}