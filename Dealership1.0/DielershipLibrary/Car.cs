using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DielershipLibrary
{
    [Serializable]
    public class Car
    {
        private string _brand = string.Empty;
        private string _model = string.Empty;
        private string _bodywork = string.Empty;
        private string _horsePower = string.Empty;
        private string _fuelType = string.Empty;
        private string _color = string.Empty;
        private string _productionDate = string.Empty;
        private string _mileage = string.Empty;
        private bool _isSold;
        private string _additionalCarInfo = string.Empty;
        private int _contractNumber = 0;
        private string _price = string.Empty;
        private string _engineVolumeCc = string.Empty;
        private string _win = string.Empty;
        private string _autoStartStop = "Auto Start Stop function";
        private string _bluetoothHf = "Bluetooth , handsfree система";
        private string _dvdTv = "DVD, TV";
        private string _steptronicTiptronic = "Steptronic, Tiptronic";
        private string _usbAudioVideoAux = "USB, audio, video, IN AUX изводи";
        private string _adaptiveSusp = "Адаптивно въздушно окачване";
        private string _keylessGo = "Безключово палене";
        private string _differentialLock = "Блокаж на диференциала";
        private string _ecu = "Бордкомпютър";
        private string _elMirrors = "Ел. Огледала";
        private string _elWindows = "Ел. Стъкла";
        private string _elAdjustmentSusp = "Ел. регулиране на окачването";
        private string _elAdjustmentSeats = "Ел. регулиране на седалките";
        private string _elSteerAmplifier = "Ел. усилвател на волана";
        private string _airConditioning = "Климатик";
        private string _climatronic = "Климатроник";
        private string _multifuntionSteer = "Мултифункционален волан";
        private string _navigation = "Навигация";
        private string _steeringHeater = "Отопление на волана";
        private string _heatingSys = "Печка";
        private string _frontWindowHeating = "Подгряване на предното стъкло";
        private string _seatsHeating = "Подгряване на седалките";
        private string _steeringAdjustment = "Регулиране на волана";
        private string _rainSensor = "Сензор за дъжд";
        private string _servoSteerAmplifier = "Серво усилвател на волана";
        private string _headlightWash = "Система за измиване на фаровете";
        private string _autopilot = "Автопилот";
        private string _stereo = "Стерео уредба";
        private string _dpfFilter = "Филтър за твърди частици";
        private string _coolingGlovebox = "Хладилна жабка";
        private string _extras = string.Empty;

        public string AutoStartStop
        {
            get
            {
                return _autoStartStop;
            }
            set
            {
                _autoStartStop = value;
            }
        }
        public string BluetoothHF
        {
            get
            {
                return _bluetoothHf;
            }
            set
            {
                _bluetoothHf = value;
            }
        }
        public string DvdTv
        {
            get
            {
                return _dvdTv;
            }
            set
            {
                _dvdTv = value;
            }
        }
        public string SteptronicTiptronic
        {
            get
            {
                return _steptronicTiptronic;
            }
            set
            {
                _steptronicTiptronic = value;
            }
        }
        public string USBAudioVideoAUX
        {
            get
            {
                return _usbAudioVideoAux;
            }
            set
            {
                _usbAudioVideoAux = value;
            }
        }
        public string AdaptiveAirSusp
        {
            get
            {
                return _adaptiveSusp;
            }
            set
            {
                _adaptiveSusp = value;
            }
        }
        public string KeylessGo
        {
            get
            {
                return _keylessGo;
            }
            set
            {
                _keylessGo = value;
            }
        }
        public string DifferentialLock
        {
            get
            {
                return _differentialLock;
            }
            set
            {
                _differentialLock = value;
            }
        }
        public string ECU
        {
            get
            {
                return _ecu;
            }
            set
            {
                _ecu = value;
            }
        }
        public string ElMirrors
        {
            get
            {
                return _elMirrors;
            }
            set
            {
                _elMirrors = value;
            }
        }
        public string ElWindows
        {
            get
            {
                return _elWindows;
            }
            set
            {
                _elWindows = value;
            }
        }
        public string ElAdjustmentSusp
        {
            get
            {
                return _elAdjustmentSusp;
            }
            set
            {
                _elAdjustmentSusp = value;
            }
        }
        public string DPFFilter
        {
            get
            {
                return _dpfFilter;
            }
            set
            {
                _dpfFilter = value;
            }
        }
        public string CoolingGlovebox
        {
            get
            {
                return _coolingGlovebox;
            }
            set
            {
                _coolingGlovebox = value;
            }
        }
        public string Stereo
        {
            get
            {
                return _stereo;
            }
            set
            {
                _stereo = value;
            }
        }
        public string ElAdjustmentSeats
        {
            get
            {
                return _elAdjustmentSeats;
            }
            set
            {
                _elAdjustmentSeats = value;
            }
        }
        public string ElSteerAmplifier
        {
            get
            {
                return _elSteerAmplifier;
            }
            set
            {
                _elSteerAmplifier = value;
            }
        }
        public string AirConditioning
        {
            get
            {
                return _airConditioning;
            }
            set
            {
                _airConditioning = value;
            }
        }
        public string Climatronic
        {
            get
            {
                return _climatronic;
            }
            set
            {
                _climatronic = value;
            }
        }
        public string MultifunctionSteer
        {
            get
            {
                return _multifuntionSteer;
            }
            set
            {
                _multifuntionSteer = value;
            }
        }
        public string Navigation
        {
            get
            {
                return _navigation;
            }
            set
            {
                _navigation = value;
            }
        }
        public string SteeringHeater
        {
            get
            {
                return _steeringHeater;
            }
            set
            {
                _steeringHeater = value;
            }
        }
        public string FrontWindowHeating
        {
            get
            {
                return _frontWindowHeating;
            }
            set
            {
                _frontWindowHeating = value;
            }
        }
        public string Autopilot
        {
            get
            {
                return _autopilot;
            }
            set
            {
                _autopilot = value;
            }
        }
        public string SeatsHeating
        {
            get
            {
                return _seatsHeating;
            }
            set
            {
                _seatsHeating = value;
            }
        }
        public string RainSensor
        {
            get
            {
                return _rainSensor;
            }
            set
            {
                _rainSensor = value;
            }
        }
        public string SteeringAdjustment
        {
            get
            {
                return _steeringAdjustment;
            }
            set
            {
                _steeringAdjustment = value;
            }
        }
        public string ServoSteerAmplifier
        {
            get
            {
                return _servoSteerAmplifier;
            }
            set
            {
                _servoSteerAmplifier = value;
            }
        }
        public string HeadlightsWash
        {
            get
            {
                return _headlightWash;
            }
            set
            {
                _headlightWash = value;
            }
        }
        public string HeatingSys
        {
            get
            {
                return _heatingSys;
            }
            set
            {
                _heatingSys = value;
            }
        }
        public string Extras
        {
            get
            {
                return _extras;
            }

            set
            {
                _extras = value;
            }
        }

        [System.Xml.Serialization.XmlElement("Brand")]
        public string Brand
        {
            get
            {
                return _brand;
            }
            set
            {
                if (value.Count() < 2 || string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Invalid brand digit lenght !");
                    return;
                }
                _brand = value.ToUpper();
            }
        }
        [System.Xml.Serialization.XmlElement("Model")]
        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "----";
                }
                _model = value;
            }
        }
        [System.Xml.Serialization.XmlElement("Bodytype")]
        public string BodyworkType
        {
            get
            {
                return _bodywork;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "----";
                }
                _bodywork = FirstLetterToUpperCaseOrConvertNullToEmptyString(value);
            }
        }
        [System.Xml.Serialization.XmlElement("HorsePower")]
        public string HorsePower
        {
            get
            {
                return _horsePower;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "----";
                }
                _horsePower = value;
            }
        }
        [System.Xml.Serialization.XmlElement("FuelType")]
        public string FuelType
        {
            get
            {
                return _fuelType;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "----";

                }
                _fuelType = value;
            }
        }
        [System.Xml.Serialization.XmlElement("Color")]
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "----";
                }
                _color = FirstLetterToUpperCaseOrConvertNullToEmptyString(value);
            }
        }
        [System.Xml.Serialization.XmlElement("ProductionDate")]
        public string ProductionDate
        {
            get
            {
                return _productionDate;
            }
            set
            {
                if (value == null)
                {
                    value = "----";
                }
                _productionDate = value;
            }
        }
        [System.Xml.Serialization.XmlElement("Mileage")]
        public string Mileage
        {
            get
            {
                return _mileage;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "----";
                }
                _mileage = value;
            }
        }
        [System.Xml.Serialization.XmlElement("IsSold")]
        public bool IsSold
        {
            get
            {
                return _isSold;
            }
            set
            {
                _isSold = value;
            }
        }
        [System.Xml.Serialization.XmlElement("AdditionalCarInfo")]
        public string AdditionalInfo
        {
            get
            {
                return _additionalCarInfo;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "----";
                }
                _additionalCarInfo = value;
            }
        }
        [System.Xml.Serialization.XmlElement("ContractNumber")]
        public int ContractNumber
        {
            get
            {
                return _contractNumber;
            }
            set
            {
                _contractNumber = value;
            }

        }
        [System.Xml.Serialization.XmlElement("Price")]
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _price = "0";
                    return;
                }
                _price = value;
            }
        }
        [System.Xml.Serialization.XmlElement("EngineVolumeCc")]
        public string EngineVolumeCc
        {
            get
            {
                return _engineVolumeCc;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _engineVolumeCc = "----";
                }
                _engineVolumeCc = value;
            }
        }
        [System.Xml.Serialization.XmlElement("WIN")]
        public string Win
        {
            get
            {
                return _win;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _win = "----";
                }
                _win = value;
            }
        }
       
        

        public Car()
        {

        }
        //public static List<Car> LoadXMLDatabase() //CHECKED ! WORKS FINE , MOVED TO XMLDatabase !
        //{
        //    List<Car> listo = new List<Car>();
        //    XDocument dox = XDocument.Load("data.xml");
        //    //var studentLst = dox.Descendants("Car").Select(d =>
        //    //    new {
        //    //              Brand = d.Element("Brand").Value,
        //    //              Name = d.Element("Model").Value
        //    //        }).ToList();
        //    listo = dox.Descendants("Car").Select(d =>
        //        new Car
        //        {
        //            Brand = d.Element("Brand").Value,
        //            Model = d.Element("Model").Value,
        //            BodyworkType = d.Element("BodyworkType").Value,
        //            HorsePower = d.Element("HorsePower").Value,
        //            FuelType = d.Element("FuelType").Value,
        //            Color = d.Element("Color").Value,
        //            ProductionDate = d.Element("ProductionDate").Value,
        //            Mileage = d.Element("Mileage").Value,
        //            AdditionalInfo = d.Element("AdditionalInfo").Value,
        //            Price = d.Element("Price").Value,
        //            EngineVolumeCc = d.Element("EngineVolumeCc").Value,
        //            Win = d.Element("Win").Value,
        //            ContractNumber = int.Parse(d.Element("ContractNumber").Value)

        //        }).ToList();

        //    return listo;

        //}
        public Car(int contractNumber)
        {
            this._contractNumber = contractNumber;

        }

        public string Display
        {
            get
            {
                return string.Format("#{0}      {1} {2} {3}", ContractNumber, Brand, Model, ProductionDate);
            }
        }


        public static string FirstLetterToUpperCaseOrConvertNullToEmptyString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            char[] result = value.ToCharArray();
            result[0] = char.ToUpper(result[0]);
            return new string(result);
        }


    }
}

