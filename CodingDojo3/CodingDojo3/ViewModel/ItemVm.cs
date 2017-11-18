using GalaSoft.MvvmLight;
using Shared.BaseModels;
using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo3.ViewModel
{
    public class ItemVm : ViewModelBase
    {
        private ItemBase baseItem;

        //Constructor

        public ItemVm(ISensor sensor)
        {
            baseItem = sensor as ItemBase;
        }

        public ItemVm(IActuator actuator)
        {
            baseItem = actuator as ItemBase;
        }

        // Property
        public int Id
        {
            get { return baseItem.Id; }
        }

        public string Description
        {
            get { return baseItem.Description; }
            set { baseItem.Description = value; }
        }

        public string Name
        {
            get { return baseItem.Name; }
            set { baseItem.Name = value; }
        }

        public string Room
        {
            get { return baseItem.Room; }
            set { baseItem.Room = value; }
        }

        public int PosX
        {
            get { return baseItem.PosX; }
            set { baseItem.PosX = value; }
        }

        public int PosY
        {
            get { return baseItem.PosY; }
            set { baseItem.PosY = value; }
        }

        public string ValueType
        {
            get
            {
                if (baseItem is ISensor)
                    return (baseItem as BaseSensor).SensorValueType.Name;
                else if (baseItem is IActuator)
                    return (baseItem as BaseActuator).ActuatorValueType.Name;
                else
                    throw new NotImplementedException();
            }
        }

        public Type ItemType
        {
            get
            {
                if (baseItem is ISensor)
                    return typeof(ISensor);
                else if (baseItem is IActuator)
                    return typeof(IActuator);
                else
                    throw new NotImplementedException();
            }
        }

        public string Mode
        {
            get
            {
                if (baseItem is ISensor)
                    return (baseItem as BaseSensor).SensorMode.ToString();
                if (baseItem is IActuator)
                    return (baseItem as BaseActuator).ActuatorMode.ToString();
                else return null;
            }
            set
            {
                if (baseItem is ISensor)
                    (baseItem as BaseSensor).SensorMode = (SensorModeType)Enum.Parse(typeof(SensorModeType), value, false);
                if (baseItem is IActuator)
                    (baseItem as BaseActuator).ActuatorMode = (ModeType)Enum.Parse(typeof(ModeType), value, false);

                RaisePropertyChanged();
            }
        }

        public object Value
        {
            get
            {
                if (baseItem is ISensor)
                    return (baseItem as BaseSensor).SensorValue;
                else if (baseItem is IActuator)
                    return (baseItem as BaseActuator).ActuatorValue;
                else throw new NotImplementedException();
            }
            set
            {
                if (baseItem is ISensor)
                    (baseItem as BaseSensor).SensorValue = value;
                else if (baseItem is IActuator)
                    (baseItem as BaseActuator).ActuatorValue = value;
                else throw new NotImplementedException();

                RaisePropertyChanged();
            }
        } 
    }
}
