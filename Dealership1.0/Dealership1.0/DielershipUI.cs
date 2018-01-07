using DielershipLibrary;
using DielershipLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Dealership1._0.Properties;
using System.Xml;
using System.Xml.Linq;

namespace Dealership1._0
{
    public partial class DielershipUI : Form, IClearTextboxes
    {
        private Dieler dieler = new Dieler();
        private List<Car> soldCarsList = new List<Car>();
        BindingSource carsBinding = new BindingSource();
        BindingSource soldCarsBinding = new BindingSource();
        private int contractNumber;

        public DielershipUI()
        {
            InitializeComponent();
            SetupData();

            //carsBinding.DataSource = dieler.CarsList.Where(x => x.IsSold == false).ToList();
            carsBinding.DataSource = XMLDatabase.LoadXMLDatabase().Where(x => x.IsSold == false).ToList();

            carsListBox.DataSource = carsBinding;

            carsListBox.DisplayMember = "Display";
            carsListBox.ValueMember = "Display";

            soldCarsBinding.DataSource = soldCarsList;
            soldCarsListBox.DataSource = soldCarsBinding;

            soldCarsListBox.DisplayMember = "Display";
            soldCarsListBox.ValueMember = "Display";

            MenuStrip menuStrip = new MenuStrip();



        }
        // setupData empty
        private void SetupData()
        {




        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //create new car and add to carsList
            if (brandTextBox.ReadOnly == true)
            {
                TextboxesReadOnlyOrNot(false);
                ClearTextboxes();
                carsListBox.ClearSelected();
                return;
            }
            if (string.IsNullOrEmpty(brandTextBox.Text) && string.IsNullOrEmpty(modelTextBox.Text))
            {
                MessageBox.Show("Brand and model are mandatory !");
                soldCarsListBox.ClearSelected();
                return;
            }

            var Id = nextContractNumber();
            Car newCar = new Car(Id);
            newCar.Brand = brandTextBox.Text;
            newCar.Model = modelTextBox.Text;
            newCar.BodyworkType = typeTextBox.Text;
            newCar.EngineVolumeCc = EngineVolumeCCTextBox.Text;
            newCar.HorsePower = horsePowerTextBox.Text;
            newCar.FuelType = fuelTypeTextBox.Text;
            newCar.Color = colorTextBox.Text;
            newCar.ProductionDate = productionDateTextBox.Text;
            newCar.Mileage = mileageTextBox.Text;
            newCar.Price = priceTextBox.Text + " $";
            newCar.AdditionalInfo = additionalCarInfoTextBox.Text;
            newCar.Win = WinTextBox.Text;
            AddCheckedExtrasToCarProps(newCar);

            ClearTextboxes();
            carsBinding.ResetBindings(false);
            soldCarsListBox.ClearSelected();

            XMLDatabase.AppednToXML(newCar); // works fine

            //carsBinding.DataSource = Car.LoadXMLDatabase().Where(x => x.IsSold == false).ToList();
            carsBinding.DataSource = XMLDatabase.LoadXMLDatabase().Where(x => x.IsSold == false).ToList();
            UncheckCheckboxes();

        }

        private void UncheckCheckboxes()
        {
            AutoStartStopCheckBox.Checked = false;
            BluetoothHFCheckbox.Checked = false;
            DvdTvCheckbox.Checked = false;
            SteptronicTiptronicCheckbox.Checked = false;
            USBAudioVideoAUXCheckbox.Checked = false;
            AdaptiveAirSuspCheckbox.Checked = false;
            KeylessGoCheckbox.Checked = false;
            DifferentialLockCheckbox.Checked = false;
            ECUCheckbox.Checked = false;
            ElMirrorsCheckbox.Checked = false;
            ElWindowsCheckbox.Checked = false;
            ElAdjustmentSuspCheckbox.Checked = false;
            DPFFilterCheckbox.Checked = false;
            CoolingGloveboxCheckbox.Checked = false;
            StereoCheckbox.Checked = false;
            ElAdjustmentSeatsCheckbox.Checked = false;
            ElSteerAmplifierCheckbox.Checked = false;
            AirConditioningCheckbox.Checked = false;
            ClimatronicCheckbox.Checked = false;
            MultifunctionSteerCheckbox.Checked = false;
            NavigationCheckbox.Checked = false;
            SteeringHeaterCheckbox.Checked = false;
            FrontWindowHeatingCheckbox.Checked = false;
            AutopilotCheckbox.Checked = false;
            SeatsHeatingCheckbox.Checked = false;
            RainSensorCheckbox.Checked = false;
            SteeringAdjustmentCheckbox.Checked = false;
            ServoSteerAmplifierCheckbox.Checked = false;
            HeadlightsWashCheckbox.Checked = false;
            HeatingSysCheckbox.Checked = false;
        }
        //private void DeserializeXMLDatabase()
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
        private void soldButton_Click(object sender, EventArgs e)
        {
            // find selected item
            // copy item to soldCarsList
            // erase from carsList
            DialogResult dialogResult = MessageBox.Show("Are you sure ?", "Check", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Car selectedCar = (Car)carsListBox.SelectedItem;
                var selectedCarPrice = Int32.Parse(selectedCar.Price);
                Settings.Default.MonthlyProfit += selectedCarPrice;

                Settings.Default.Save();
                XMLDatabase.Remove(carsListBox.SelectedItem);
                soldCarsList.Add(selectedCar);
                soldCarsBinding.ResetBindings(false);

                carsBinding.DataSource = XMLDatabase.LoadXMLDatabase().Where(x => x.IsSold == false).ToList();

                carsListBox.ClearSelected();
                soldCarsListBox.ClearSelected();

                ProfitLabel.Text = Settings.Default.MonthlyProfit.ToString() + "$";

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }


        }
        private void AddCheckedExtrasToCarProps(Car car)
        {
            if (this.AutoStartStopCheckBox.Checked)
            {
                car.AutoStartStop = "Auto start stop function";
            }
            if (this.BluetoothHFCheckbox.Checked)
            {
                car.BluetoothHF = "Bluetooth , handsfree система";
            }
            if (this.DvdTvCheckbox.Checked)
            {
                car.DvdTv = "DVD, TV";
            }
            if (this.SteptronicTiptronicCheckbox.Checked)
            {
                car.SteptronicTiptronic = "Steptronic, Tiptronic";
            }
            if (this.USBAudioVideoAUXCheckbox.Checked)
            {
                car.USBAudioVideoAUX = "USB, audio video, IN AUX изводи";
            }
            if (this.AdaptiveAirSuspCheckbox.Checked)
            {
                car.AdaptiveAirSusp = "Адаптивно въздушно окачване";
            }
            if (this.KeylessGoCheckbox.Checked)
            {
                car.KeylessGo = "Безключово палене";
            }
            if (this.DifferentialLockCheckbox.Checked)
            {
                car.DifferentialLock = "Блокаж на диференциала";
            }
            if (this.ECUCheckbox.Checked)
            {
                car.ECU = "Бордкомпютър";
            }
            if (this.ElMirrorsCheckbox.Checked)
            {
                car.ElMirrors = "Ел. Огледала";
            }
            if (this.ElWindowsCheckbox.Checked)
            {
                car.ElWindows = "Ел. стъкла";
            }
            if (this.ElAdjustmentSuspCheckbox.Checked)
            {
                car.ElAdjustmentSusp = "Ел. регулиране на окачването";
            }
            if (this.DPFFilterCheckbox.Checked)
            {
                car.DPFFilter = "Филтър за твърди частици";
            }
            if (this.CoolingGloveboxCheckbox.Checked)
            {
                car.CoolingGlovebox = "Хладилна жабка";
            }
            if (this.StereoCheckbox.Checked)
            {
                car.Stereo = "Стерео уредба";
            }
            if (this.ElAdjustmentSeatsCheckbox.Checked)
            {
                car.ElAdjustmentSeats = "Ел. регулиране на седалките";
            }
            if (this.ElSteerAmplifierCheckbox.Checked)
            {
                car.ElSteerAmplifier = "Ел. усилвател на волана";
            }
            if (this.AirConditioningCheckbox.Checked)
            {
                car.AirConditioning = "Климатик";
            }
            if (this.ClimatronicCheckbox.Checked)
            {
                car.Climatronic = "Климатроник";
            }
            if (this.MultifunctionSteerCheckbox.Checked)
            {
                car.MultifunctionSteer = "Мултифункционален волан";
            }
            if (this.NavigationCheckbox.Checked)
            {
                car.Navigation = "Навигация";
            }
            if (this.SteeringHeaterCheckbox.Checked)
            {
                car.SteeringHeater = "Отопление на волана";
            }
            if (this.FrontWindowHeatingCheckbox.Checked)
            {
                car.FrontWindowHeating = "Подгряване на предното стъкло";
            }
            if (this.AutopilotCheckbox.Checked)
            {
                car.Autopilot = "Автопилот";
            }
            if (this.SeatsHeatingCheckbox.Checked)
            {
                car.SeatsHeating = "Подгряване на седалките";
            }
            if (this.RainSensorCheckbox.Checked)
            {
                car.RainSensor = "Сензор за дъжд";
            }
            if (this.SteeringAdjustmentCheckbox.Checked)
            {
                car.SteeringAdjustment = "Регулиране на волана";
            }
            if (this.ServoSteerAmplifierCheckbox.Checked)
            {
                car.ServoSteerAmplifier = "Серво усилвател на волана";
            }
            if (this.HeadlightsWashCheckbox.Checked)
            {
                car.HeadlightsWash = "Система за измиване на фаровете";
            }
            if (this.HeatingSysCheckbox.Checked)
            {
                car.HeatingSys = "Печка";
            }

        }
        private void clearSoldCarsButton_Click(object sender, EventArgs e)
        {
            //mark item as sold 
            //clear soldCarsList

            foreach (var item in soldCarsList)
            {
                if (item == null)
                {
                    return;
                }
                item.IsSold = true;
            }

            soldCarsList.Clear();
            carsBinding.DataSource = dieler.CarsList.Where(x => x.IsSold == false).ToList();

            soldCarsBinding.ResetBindings(false);
            carsBinding.ResetBindings(false);
        }

        public void ClearTextboxes()// WORKS FINE
        {
            brandTextBox.Clear();
            modelTextBox.Clear();
            typeTextBox.Clear();
            EngineVolumeCCTextBox.Clear();
            horsePowerTextBox.Clear();
            fuelTypeTextBox.Clear();
            colorTextBox.Clear();
            productionDateTextBox.Clear();
            mileageTextBox.Clear();
            additionalCarInfoTextBox.Clear();
            priceTextBox.Clear();
            WinTextBox.Clear();
            ContractNumberLabel.Text = "#---";
        }
        public void TextboxesReadOnlyOrNot(bool condition) //WORKS FINE
        {
            brandTextBox.ReadOnly = condition;
            modelTextBox.ReadOnly = condition;
            typeTextBox.ReadOnly = condition;
            horsePowerTextBox.ReadOnly = condition;
            fuelTypeTextBox.ReadOnly = condition;
            colorTextBox.ReadOnly = condition;
            productionDateTextBox.ReadOnly = condition;
            mileageTextBox.ReadOnly = condition;
            additionalCarInfoTextBox.ReadOnly = condition;
            priceTextBox.ReadOnly = condition;
            EngineVolumeCCTextBox.ReadOnly = condition;
            WinTextBox.ReadOnly = condition;
        }
        public void FillTextBoxesWithSelectedCarParameters(ListBox listBox) //WORKS FINE
        {
            Car selectedCar = (Car)listBox.SelectedItem;

            ContractNumberLabel.Text = string.Format("#{0}", selectedCar.ContractNumber.ToString());
            brandTextBox.Text = selectedCar.Brand;
            modelTextBox.Text = selectedCar.Model;
            typeTextBox.Text = selectedCar.BodyworkType;
            EngineVolumeCCTextBox.Text = selectedCar.EngineVolumeCc;
            horsePowerTextBox.Text = selectedCar.HorsePower.ToString();
            fuelTypeTextBox.Text = selectedCar.FuelType;
            colorTextBox.Text = selectedCar.Color;
            productionDateTextBox.Text = selectedCar.ProductionDate;
            mileageTextBox.Text = selectedCar.Mileage.ToString();
            additionalCarInfoTextBox.Text = selectedCar.AdditionalInfo;
            priceTextBox.Text = selectedCar.Price;
            WinTextBox.Text = selectedCar.Win;

        }
        public int nextContractNumber()
        {
            int result = int.Parse(Settings.Default["NumOfContracts"].ToString());
            Settings.Default["NumOfContracts"] = result + 1;
            Settings.Default.Save();
            return ++result;
        }

        private void ShowInfo(object sender, EventArgs e) //WORKS FINE
        {
            ///clear  text boxes
            //show selected car info in texboxes
            ClearTextboxes();
            Car selectedCar = (Car)carsListBox.SelectedItem;
            if (selectedCar == null)
            {
                selectedCar = (Car)soldCarsListBox.SelectedItem;
                if (selectedCar == null)
                {
                    MessageBox.Show("Select item from the list!");
                    return;
                }
                FillTextBoxesWithSelectedCarParameters(soldCarsListBox);

                TextboxesReadOnlyOrNot(true);

                return;
            }

            FillTextBoxesWithSelectedCarParameters(carsListBox);

            TextboxesReadOnlyOrNot(true);
        }

        private void carsListBox_DoubleClick(object sender, EventArgs e)// WORK FINE
        {
            if (carsListBox.Items.Count > 0)
            {
                ClearTextboxes();
                var selectedIndex = carsListBox.SelectedItem;
                ShowInfo(selectedIndex, e);
                soldCarsListBox.ClearSelected();
            }
            InfoForm infoForm = new InfoForm();
            infoForm.FillInfoFormTextbox(carsListBox.SelectedItem);//selectedIndex
            infoForm.Show();
            


        }

        private void soldCarsListBox_DoubleClick(object sender, EventArgs e)//WORKS FINE
        {
            if (soldCarsListBox.Items.Count > 0)
            {
                ClearTextboxes();
                var selectedIndex = soldCarsListBox.SelectedItem;
                ShowInfo(selectedIndex, e);
                carsListBox.ClearSelected();
            }
        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar));

        }

        private void mileageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar));
        }

        private void EngineVolumeCCTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar));
        }

        private void horsePowerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar));
        }

        private void WinTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            WinTextBox.CharacterCasing = CharacterCasing.Upper;
        }


        //empty
        private void DielershipUI_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


        private void DielershipUI_Load(object sender, EventArgs e)
        {
            //DeserializeXMLDatabase();
            carsListBox.Update();
            contractNumber = int.Parse(Settings.Default["NumOfContracts"].ToString());
            ProfitLabel.Text = Settings.Default.MonthlyProfit.ToString() + " $";
            carsListBox.ClearSelected();
        }


        private void ResetProfitLabelButton_Click(object sender, EventArgs e)
        {
            Settings.Default.MonthlyProfit = 0;
            ProfitLabel.Text = Settings.Default.MonthlyProfit.ToString() + "$";
            Settings.Default.Save();
        }
    }
}
