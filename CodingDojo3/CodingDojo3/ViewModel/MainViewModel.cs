using CodingDojo3.Simulation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Shared.BaseModels;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace CodingDojo3.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private Simulator sim;
        private List<ItemVm> modelItems = new List<ItemVm>();
        public ObservableCollection<ItemVm> SensorList { get; set; }
        public ObservableCollection<ItemVm> ActorList { get; set; }
        public ObservableCollection<string> ModeSelectionList { get; set; }
        public RelayCommand SensorAddBtnClickCmd { get; set; }
        public RelayCommand SensorDelBtnClickCmd { get; set; }
        public RelayCommand ActorAddBtnClickCmd { get; set; }
        public RelayCommand ActorDelBtnClickCmd { get; set; }
        private string currTime = DateTime.Now.ToLocalTime().ToShortTimeString();
        private string currDate = DateTime.Now.ToLocalTime().ToShortDateString();

        public string CurrDate
        {
            get { return currDate; }
            set { currDate = value; RaisePropertyChanged(); }
        }

        public string CurrTime
        {
            get { return currTime; }
            set { currTime = value; RaisePropertyChanged(); }
        }

        public MainViewModel()
        {
            SensorList = new ObservableCollection<ItemVm>();
            ActorList = new ObservableCollection<ItemVm>();
            ModeSelectionList = new ObservableCollection<string>();

            foreach(var item in Enum.GetNames(typeof(SensorModeType)))
            {
                ModeSelectionList.Add(item);
            }
            foreach (var item in Enum.GetNames(typeof(ModeType)))
            {
                ModeSelectionList.Add(item);
            }

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 40);
            if (!IsInDesignMode)
            {
                LoadData();
                timer.Start();
            }
        }

        private void LoadData()
        {
            Simulator sim = new Simulator(modelItems);
            foreach(var item in sim.Items)
            {
                if (item.ItemType.Equals(typeof(ISensor)))
                    SensorList.Add(item);
                else if (item.ItemType.Equals(typeof(IActuator)))
                    ActorList.Add(item);
            }
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            CurrTime = DateTime.Now.ToLocalTime().ToShortTimeString();
            currDate = DateTime.Now.ToLocalTime().ToShortDateString();
        }
        
    }

}