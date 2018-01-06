using Client.Communication;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System;

namespace Client.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        // Properties
        public string Name { get; set; }
        public string Messages { get; set; }
        public RelayCommand BtnConnect { get; set; }
        public RelayCommand BtnSend { get; set; }
        public ObservableCollection<string> ReceivedMessages { get; set; }

        public ClientHandler clientHandler;

        //Methode
        public void Connect()
        {
            clientHandler = new ClientHandler(new Action<string>(NewMessage));
        }

        public void Send()
        {
            clientHandler.SendMessage(Name + ": " + Messages);
            ReceivedMessages.Add("You: " + Messages);
        }

        public void NewMessage(string message)
        {
            App.Current.Dispatcher.Invoke( () => { ReceivedMessages.Add(message); } );
        }


        //Methode MVM
        public MainViewModel()
        {
            ReceivedMessages = new ObservableCollection<string>();
            BtnConnect = new RelayCommand(Connect);
            BtnSend = new RelayCommand(Send);
            
        }


    }
}