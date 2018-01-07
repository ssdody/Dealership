using DielershipLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Dealership1._0
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }
        public void FillInfoFormTextbox(object car)
        {
            var carConv = (Car)car;
            XmlDocument doc = new XmlDocument();
            doc.Load("data.xml");
            XmlNodeList nodes = doc.SelectNodes("//Car[ContractNumber='" + carConv.ContractNumber + "']");
            string[] sb = new string[nodes.Count];
            string textContainer = "";
            //foreach (XmlNode node in nodes)
            //{

            //    /*CarInfoTextbox.AppendText(node.InnerText);*/
            //    //to do (split text if possible)
            //    textContainer += node.InnerText;
            //}
            //var contArr = textContainer.Split(' ', ' ');
            //foreach (var item in contArr)
            //{

            //    CarInfoTextbox.AppendText(item);
            //    CarInfoTextbox.AppendText("\n");
            //}
            CarInfoTextbox.Text = CarInfoToStringBuilder(carConv).ToString();
        }
        private StringBuilder CarInfoToStringBuilder(Car car)
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.AppendLine(car.Brand);
            sBuilder.AppendLine(car.Model);
            sBuilder.AppendLine(car.BodyworkType);
            sBuilder.AppendLine(car.EngineVolumeCc);
            sBuilder.AppendLine(car.HorsePower);
            sBuilder.AppendLine(car.Color);
            sBuilder.AppendLine(car.FuelType);
            sBuilder.AppendLine(car.ProductionDate);
            sBuilder.AppendLine(car.Mileage);
            sBuilder.AppendLine(car.Price);
            sBuilder.AppendLine(car.Win);
            sBuilder.AppendLine(car.AdditionalInfo);
            sBuilder.AppendLine("--------------------------------");
            sBuilder.AppendLine(car.AutoStartStop);
            sBuilder.AppendLine(car.BluetoothHF);
            sBuilder.AppendLine(car.DvdTv);
            sBuilder.AppendLine(car.SteptronicTiptronic);
            sBuilder.AppendLine(car.USBAudioVideoAUX);
            sBuilder.AppendLine(car.AdaptiveAirSusp);
            sBuilder.AppendLine(car.KeylessGo);
            sBuilder.AppendLine(car.DifferentialLock);
            sBuilder.AppendLine(car.ECU);
            sBuilder.AppendLine(car.ElMirrors);
            sBuilder.AppendLine(car.ElWindows);
            sBuilder.AppendLine(car.ElAdjustmentSusp);
            sBuilder.AppendLine(car.DPFFilter);
            sBuilder.AppendLine(car.CoolingGlovebox);
            sBuilder.AppendLine(car.Stereo);
            sBuilder.AppendLine(car.ElSteerAmplifier);
            sBuilder.AppendLine(car.AirConditioning);
            sBuilder.AppendLine(car.Climatronic);
            sBuilder.AppendLine(car.MultifunctionSteer);
            sBuilder.AppendLine(car.Navigation);
            sBuilder.AppendLine(car.SteeringHeater);
            sBuilder.AppendLine(car.FrontWindowHeating);
            sBuilder.AppendLine(car.Autopilot);
            sBuilder.AppendLine(car.SeatsHeating);
            sBuilder.AppendLine(car.RainSensor);
            sBuilder.AppendLine(car.SteeringAdjustment);
            sBuilder.AppendLine(car.ServoSteerAmplifier);
            sBuilder.AppendLine(car.HeatingSys);
            sBuilder.AppendLine("--------------------------------");

            return sBuilder;
        }
        private void InfoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
