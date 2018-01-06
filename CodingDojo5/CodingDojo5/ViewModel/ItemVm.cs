using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo5.ViewModel
{
    public class ItemVm
    {
        public string Description { get; set; }
        public BitmapImage Image { get; set; }
        public string Age { get; set; }
        public ObservableCollection<ItemVm> ItemList { get; set; }

        //Constructor
        public ItemVm(string description, BitmapImage image, string age)
        {
            Description = description;
            Image = image;
            Age = age;
            ItemList = new ObservableCollection<ItemVm>();
        }

        // Methode
    }
}
