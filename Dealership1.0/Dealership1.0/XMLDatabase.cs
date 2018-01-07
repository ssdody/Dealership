using System.Xml.Serialization;
using DielershipLibrary;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.IO;

namespace Dealership1._0
{
    public class XMLDatabase
    {
        private static XmlSerializer seriliazer = new XmlSerializer(typeof(Car));

        public static void AppednToXML(Car carToAdd)        // CHECKED
        {

            //file name
            string filename = "C:\\Users\\krisi\\Documents\\Visual Studio 2015\\Projects\\Dealership1.0\\Dealership1.0\\bin\\Debug\\data.xml";

            //create new instance of XmlDocument
            XmlDocument doc = new XmlDocument();

            //load from file
            doc.Load(filename);

            //create node and add value
            XmlNode headNode = doc.CreateNode(XmlNodeType.Element, "Car", null);
            //node.InnerText = "new node";

            //create title node
            XmlNode contractNumNode = doc.CreateElement("ContractNumber");
            contractNumNode.InnerText = carToAdd.ContractNumber.ToString();
            headNode.AppendChild(contractNumNode);

            XmlNode nodeTitle = doc.CreateElement("Brand");
            nodeTitle.InnerText = carToAdd.Brand ;
            headNode.AppendChild(nodeTitle);

            //create model node and add
            XmlNode modelNode = doc.CreateElement("Model");
            modelNode.InnerText = carToAdd.Model; 
            headNode.AppendChild(modelNode);

            //create bodytype node and add
            XmlNode bodyNode = doc.CreateElement("BodyworkType");
            bodyNode.InnerText = carToAdd.BodyworkType ;
            headNode.AppendChild(bodyNode);

            XmlNode horsePowerNode = doc.CreateElement("HorsePower");
            horsePowerNode.InnerText = carToAdd.HorsePower ;
            headNode.AppendChild(horsePowerNode);

            XmlNode fuelTypeNode = doc.CreateElement("FuelType");
            fuelTypeNode.InnerText = carToAdd.FuelType ;
            headNode.AppendChild(fuelTypeNode);
            //todo the same for every car prop !

            XmlNode colorNode = doc.CreateElement("Color");
            colorNode.InnerText = carToAdd.Color ;
            headNode.AppendChild(colorNode);

            XmlNode productionDateNode = doc.CreateElement("ProductionDate");
            productionDateNode.InnerText = carToAdd.ProductionDate ;
            headNode.AppendChild(productionDateNode);

            XmlNode mileageNode = doc.CreateElement("Mileage");
            mileageNode.InnerText = carToAdd.Mileage ;
            headNode.AppendChild(mileageNode);

            XmlNode priceNode = doc.CreateElement("Price");
            priceNode.InnerText = carToAdd.Price ;
            headNode.AppendChild(priceNode);

            XmlNode addictionalInfoNode = doc.CreateElement("AdditionalInfo");
            addictionalInfoNode.InnerText = carToAdd.AdditionalInfo ;
            headNode.AppendChild(addictionalInfoNode);

            XmlNode engineVolumeNode = doc.CreateElement("EngineVolumeCc");
            engineVolumeNode.InnerText = carToAdd.EngineVolumeCc ;
            headNode.AppendChild(engineVolumeNode);

            XmlNode WINNode = doc.CreateElement("Win");
            WINNode.InnerText = carToAdd.Win ;
            headNode.AppendChild(WINNode);

            XmlNode AutoStartStopNode = doc.CreateElement("AutoStartStop");
            AutoStartStopNode.InnerText = carToAdd.AutoStartStop ;
            headNode.AppendChild(AutoStartStopNode);

            XmlNode BluetoothHFNode = doc.CreateElement("BluetoothHF");
            BluetoothHFNode.InnerText = carToAdd.BluetoothHF ;
            headNode.AppendChild(BluetoothHFNode);

            XmlNode DvdTvNode = doc.CreateElement("DvdTv");
            DvdTvNode.InnerText = carToAdd.DvdTv ;
            headNode.AppendChild(DvdTvNode);

            XmlNode SteptronicTiptronicNode = doc.CreateElement("SteptronicTiptronic");
            SteptronicTiptronicNode.InnerText = carToAdd.SteptronicTiptronic;
            headNode.AppendChild(SteptronicTiptronicNode);

            XmlNode USBAudioVideoAUXNode = doc.CreateElement("USBAudioVideoAUX");
            USBAudioVideoAUXNode.InnerText = carToAdd.USBAudioVideoAUX ;
            headNode.AppendChild(USBAudioVideoAUXNode);

            XmlNode AdaptiveAirSuspNode = doc.CreateElement("AdaptiveAirSusp");
            AdaptiveAirSuspNode.InnerText = carToAdd.AdaptiveAirSusp;
            headNode.AppendChild(AdaptiveAirSuspNode);

            XmlNode KeylessGoNode = doc.CreateElement("KeylessGo");
            KeylessGoNode.InnerText = carToAdd.KeylessGo;
            headNode.AppendChild(KeylessGoNode);

            XmlNode DifferentialLockNode = doc.CreateElement("DifferentialLock");
            DifferentialLockNode.InnerText = carToAdd.DifferentialLock;
            headNode.AppendChild(DifferentialLockNode);

            XmlNode ECUNode = doc.CreateElement("ECU");
            ECUNode.InnerText = carToAdd.ECU;
            headNode.AppendChild(ECUNode);

            XmlNode ElMirrorsNode = doc.CreateElement("ElMirrors");
            ElMirrorsNode.InnerText = carToAdd.ElMirrors;
            headNode.AppendChild(ElMirrorsNode);

            XmlNode ElWindowsNode = doc.CreateElement("ElWindows");
            ElWindowsNode.InnerText = carToAdd.ElWindows;
            headNode.AppendChild(ElWindowsNode);


            XmlNode ElAdjustmentSuspNode = doc.CreateElement("ElAdjustmentSusp");
            ElAdjustmentSuspNode.InnerText = carToAdd.ElAdjustmentSusp;
            headNode.AppendChild(ElAdjustmentSuspNode);

            XmlNode DPFFilterNode = doc.CreateElement("DPFFilter");
            DPFFilterNode.InnerText = carToAdd.DPFFilter;
            headNode.AppendChild(DPFFilterNode);

            XmlNode CoolingGloveboxNode = doc.CreateElement("CoolingGlovebox");
            CoolingGloveboxNode.InnerText = carToAdd.CoolingGlovebox;
            headNode.AppendChild(CoolingGloveboxNode);

            XmlNode StereoNode = doc.CreateElement("Stereo");
            StereoNode.InnerText = carToAdd.Stereo;
            headNode.AppendChild(StereoNode);

            XmlNode ElAdjustmentSeatsNode = doc.CreateElement("ElAdjustmentSeats");
            ElAdjustmentSeatsNode.InnerText = carToAdd.ElAdjustmentSeats;
            headNode.AppendChild(ElAdjustmentSeatsNode);

            XmlNode ElSteerAmplifierNode = doc.CreateElement("ElSteerAmplifier");
            ElSteerAmplifierNode.InnerText = carToAdd.ElSteerAmplifier;
            headNode.AppendChild(ElSteerAmplifierNode);

            XmlNode AirConditioningNode = doc.CreateElement("AirConditioning");
            AirConditioningNode.InnerText = carToAdd.AirConditioning;
            headNode.AppendChild(AirConditioningNode);

            XmlNode ClimatronicNode = doc.CreateElement("Climatronic");
            ClimatronicNode.InnerText = carToAdd.Climatronic;
            headNode.AppendChild(ClimatronicNode);

            XmlNode MultifunctionSteerNode = doc.CreateElement("MultifunctionSteer");
            MultifunctionSteerNode.InnerText = carToAdd.MultifunctionSteer;
            headNode.AppendChild(MultifunctionSteerNode);

            XmlNode NavigationNode = doc.CreateElement("Navigation");
            NavigationNode.InnerText = carToAdd.Navigation;
            headNode.AppendChild(NavigationNode);

            XmlNode SteeringHeaterNode = doc.CreateElement("SteeringHeater");
            SteeringHeaterNode.InnerText = carToAdd.SteeringHeater;
            headNode.AppendChild(SteeringHeaterNode);

            XmlNode FrontWindowHeatingNode = doc.CreateElement("FrontWindowHeating");
            FrontWindowHeatingNode.InnerText = carToAdd.FrontWindowHeating;
            headNode.AppendChild(FrontWindowHeatingNode);

            XmlNode AutopilotNode = doc.CreateElement("Autopilot");
            AutopilotNode.InnerText = carToAdd.Autopilot;
            headNode.AppendChild(AutopilotNode);

            XmlNode SeatsHeatingNode = doc.CreateElement("SeatsHeating");
            SeatsHeatingNode.InnerText = carToAdd.SeatsHeating;
            headNode.AppendChild(SeatsHeatingNode);

            XmlNode RainSensorNode = doc.CreateElement("RainSensor");
            RainSensorNode.InnerText = carToAdd.RainSensor;
            headNode.AppendChild(RainSensorNode);

            XmlNode SteeringAdjustmentNode = doc.CreateElement("SteeringAdjustment");
            SteeringAdjustmentNode.InnerText = carToAdd.SteeringAdjustment;
            headNode.AppendChild(SteeringAdjustmentNode);

            XmlNode ServoSteerAmplifierNode = doc.CreateElement("ServoSteerAmplifier");
            ServoSteerAmplifierNode.InnerText = carToAdd.ServoSteerAmplifier;
            headNode.AppendChild(ServoSteerAmplifierNode);

            XmlNode HeadlightsWashNode = doc.CreateElement("HeadlightsWash");
            HeadlightsWashNode.InnerText = carToAdd.HeadlightsWash;
            headNode.AppendChild(HeadlightsWashNode);

            XmlNode HeatingSysNode = doc.CreateElement("HeatingSys");
            HeatingSysNode.InnerText = carToAdd.HeatingSys;

            headNode.AppendChild(HeatingSysNode);

            //add to elements collection
            doc.DocumentElement.AppendChild(headNode);

            //save back
            doc.Save(filename);



        }

        public static List<Car> LoadXMLDatabase() //CHECKED ! WORKS FINE
        {
            List<Car> xmlCarList = new List<Car>();
            XDocument xDoc = XDocument.Load("data.xml");
            //var studentLst = dox.Descendants("Car").Select(d =>
            //    new {
            //              Brand = d.Element("Brand").Value,
            //              Name = d.Element("Model").Value
            //        }).ToList();
            xmlCarList = xDoc.Descendants("Car").Select(d =>
                new Car
                {
                    ContractNumber = int.Parse(d.Element("ContractNumber").Value),
                    Brand = d.Element("Brand").Value,
                    Model = d.Element("Model").Value,
                    BodyworkType = d.Element("BodyworkType").Value,
                    EngineVolumeCc = d.Element("EngineVolumeCc").Value,
                    HorsePower = d.Element("HorsePower").Value,
                    FuelType = d.Element("FuelType").Value,
                    Color = d.Element("Color").Value,
                    ProductionDate = d.Element("ProductionDate").Value,
                    Mileage = d.Element("Mileage").Value,
                    Price = d.Element("Price").Value,
                    AdditionalInfo = d.Element("AdditionalInfo").Value,
                    Win = d.Element("Win").Value,
                    AutoStartStop = d.Element("AutoStartStop").Value,
                    BluetoothHF = d.Element("BluetoothHF").Value,
                    DvdTv = d.Element("DvdTv").Value,
                    SteptronicTiptronic = d.Element("SteptronicTiptronic").Value,
                    USBAudioVideoAUX = d.Element("USBAudioVideoAUX").Value,
                    AdaptiveAirSusp = d.Element("AdaptiveAirSusp").Value,
                    KeylessGo = d.Element("KeylessGo").Value,
                    DifferentialLock = d.Element("DifferentialLock").Value,
                    ECU = d.Element("ECU").Value,
                    ElMirrors = d.Element("ElMirrors").Value,
                    ElWindows = d.Element("ElWindows").Value,
                    ElAdjustmentSusp = d.Element("ElAdjustmentSusp").Value,
                    DPFFilter = d.Element("DPFFilter").Value,
                    CoolingGlovebox = d.Element("CoolingGlovebox").Value,
                    Stereo = d.Element("Stereo").Value,
                    ElAdjustmentSeats = d.Element("ElAdjustmentSeats").Value,
                    ElSteerAmplifier = d.Element("ElSteerAmplifier").Value,
                    AirConditioning = d.Element("AirConditioning").Value,
                    Climatronic = d.Element("Climatronic").Value,
                    MultifunctionSteer = d.Element("MultifunctionSteer").Value,
                    Navigation = d.Element("Navigation").Value,
                    SteeringHeater = d.Element("SteeringHeater").Value,
                    FrontWindowHeating = d.Element("FrontWindowHeating").Value,
                    Autopilot = d.Element("Autopilot").Value,
                    SeatsHeating = d.Element("SeatsHeating").Value,
                    RainSensor = d.Element("RainSensor").Value,
                    SteeringAdjustment = d.Element("SteeringAdjustment").Value,
                    ServoSteerAmplifier = d.Element("ServoSteerAmplifier").Value,
                    HeadlightsWash = d.Element("HeadlightsWash").Value,
                    HeatingSys = d.Element("HeatingSys").Value
                }).ToList();

            return xmlCarList;

        }
        //private void DeserializeXMLDatabase()//dont work hierarchy problem
        //{
        //    if (!File.Exists("data.xml"))
        //    {
        //        XmlSerializer xSerializer = new XmlSerializer(typeof(Car));
        //        using (FileStream read = new FileStream("data.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
        //        {
        //            Car xmlCar = (Car)xSerializer.Deserialize(read);
        //            dieler.CarsList.Add(xmlCar);
        //        }
        //    }

        //}
        public static void Remove(object car)
        {
            if (car != null)
            {

                XmlDocument doc = new XmlDocument();
                doc.Load("data.xml");
                var carConv = (Car)car;
                XmlNodeList nodes = doc.SelectNodes("//Car[ContractNumber='" + carConv.ContractNumber + "']");

                foreach (XmlNode node in nodes)
                {
                    node.ParentNode.RemoveChild(node);
                }
                doc.Save("data.xml");
            }
        }
    }
}
