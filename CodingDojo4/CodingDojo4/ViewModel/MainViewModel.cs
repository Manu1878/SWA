using CodingDojo4.Communication;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace CodingDojo4.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //Properties
        public RelayCommand BtnStart { get; set; }
        public RelayCommand BtnStop { get; set; }
        public RelayCommand BtnDrop { get; set; }
        public ObservableCollection<string> User { get; set; }
        public ObservableCollection<string> Messages { get; set; }
        public string SelectedUser { get; set; }
        Server server;

        //Methods
        public void UpdateGui(string message)
        {
            App.Current.Dispatcher.Invoke(() => 
            {
                string name = message.Split(':')[0];
                if (!User.Contains(name))
                {
                    User.Add(name);
                }
                Messages.Add(message);
                RaisePropertyChanged();
            });
        }

        //MVM
        public MainViewModel()
        {
            User = new ObservableCollection<string>();
            Messages = new ObservableCollection<string>();
            BtnStart = new RelayCommand(() => { server = new Server(UpdateGui); server.StartAccepting(); });
            BtnStop = new RelayCommand(() => { server.Stop(); });
            BtnDrop = new RelayCommand(() => { server.DisconnectUser(SelectedUser); User.Remove(SelectedUser); } );
        }
    }
}