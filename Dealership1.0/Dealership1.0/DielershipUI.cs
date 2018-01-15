namespace Dealership1._0
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using DielershipLibrary.Contracts;
    using DielershipLibrary;
    using Properties;
    using System.Text;

    /// <summary>
    /// Dielership Main
    /// </summary>
    public partial class DielershipUI : Form, IClearTextboxes
    {
        //private Dieler dieler = new Dieler();
        private List<Car> soldCarsList = new List<Car>();
        private BindingSource carsBinding = new BindingSource();
        private BindingSource soldCarsBinding = new BindingSource();
        private int contractNumber;

        public DielershipUI()
        {
            this.InitializeComponent();
            this.SetupData();

            ////carsBinding.DataSource = dieler.CarsList.Where(x => x.IsSold == false).ToList();
            this.carsBinding.DataSource = XMLDatabase.Load().Where(x => x.IsSold == false).ToList();

            carsListBox.DataSource = this.carsBinding;

            carsListBox.DisplayMember = "Display";
            carsListBox.ValueMember = "Display";

            this.soldCarsBinding.DataSource = this.soldCarsList;
            this.soldCarsListBox.DataSource = this.soldCarsBinding;

            soldCarsListBox.DisplayMember = "Display";
            soldCarsListBox.ValueMember = "Display";

            MenuStrip menuStrip = new MenuStrip();
        }
        //// setupData empty
        private void SetupData()
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (brandTextBox.ReadOnly == true)
            {
                this.TextboxesReadOnlyOrNot(false);
                this.ClearTextboxes();
                carsListBox.ClearSelected();
                return;
            }

            if (string.IsNullOrEmpty(brandTextBox.Text) && string.IsNullOrEmpty(modelTextBox.Text))
            {
                MessageBox.Show("Brand and model are mandatory !");
                soldCarsListBox.ClearSelected();
                return;
            }

            var id = this.NextContractNumber();
            Car newCar = new Car(id);
            newCar.Brand = brandTextBox.Text;
            newCar.Model = modelTextBox.Text;
            newCar.BodyworkType = typeTextBox.Text;
            newCar.EngineVolumeCc = EngineVolumeCCTextBox.Text;
            newCar.HorsePower = horsePowerTextBox.Text;
            newCar.FuelType = fuelTypeTextBox.Text;
            newCar.Color = colorTextBox.Text;
            newCar.ProductionDate = productionDateTextBox.Text;
            newCar.Mileage = mileageTextBox.Text;
            newCar.Price = priceTextBox.Text;
            newCar.AdditionalInfo = additionalCarInfoTextBox.Text;
            newCar.Win = WinTextBox.Text;
            this.AddExtrasToCarExtrasFieldIfChecked(newCar);

            this.ClearTextboxes();
            this.carsBinding.ResetBindings(false);
            soldCarsListBox.ClearSelected();

            XMLDatabase.AppendDataToXML(newCar); // works fine

            this.carsBinding.DataSource = XMLDatabase.Load().Where(x => x.IsSold == false).ToList();
            this.UncheckCheckboxes();
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

        ////private void DeserializeXMLDatabase()
        ////{
        ////    if (!File.Exists("data.xml"))
        ////    {
        ////        XmlSerializer xSerializer = new XmlSerializer(typeof(Car));
        ////        using (FileStream read = new FileStream("data.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
        ////        {
        ////            Car xmlCar = (Car)xSerializer.Deserialize(read);
        ////            dieler.CarsList.Add(xmlCar);
        ////        }
        ////    }
        //
        ////}

        private void soldButton_Click(object sender, EventArgs e)
        {
            // find selected item
            // copy item to soldCarsList
            // erase from carsList
            if (carsListBox.SelectedItem != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure ?", "Check", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Car selectedCar = (Car)carsListBox.SelectedItem;
                    var selectedCarPrice = int.Parse(selectedCar.Price);
                    Settings.Default.MonthlyProfit += selectedCarPrice;
                    Settings.Default.Save();

                    XMLDatabase.Remove(carsListBox.SelectedItem);
                    this.soldCarsList.Add(selectedCar);
                    this.soldCarsBinding.ResetBindings(false);

                    this.carsBinding.DataSource = XMLDatabase.Load().Where(x => x.IsSold == false).ToList();

                    carsListBox.ClearSelected();
                    soldCarsListBox.ClearSelected();

                    ProfitLabel.Text = Settings.Default.MonthlyProfit.ToString() + "$";
                }
                else
                {
                    return;
                }
            }
        }

        private void AddExtrasToCarExtrasFieldIfChecked(Car car)
        {
            var tempBuilder = new StringBuilder();
            List<CheckBox> checkList = new List<CheckBox>();
            checkList.Add(AlluminRimsCheckbox);
            checkList.Add(BrakeAssistCheckbox);
            checkList.Add(BluetoothHFCheckbox);
            checkList.Add(BarterCheckbox);
            checkList.Add(AutoStartStopCheckBox);
            checkList.Add(AutopilotCheckbox);
            checkList.Add(AutoGasSysCheckbox);
            checkList.Add(ASRCheckbox);
            checkList.Add(ASCCheckbox);
            checkList.Add(AirConditioningCheckbox);
            checkList.Add(AigBagSysCheckbox);
            checkList.Add(AdaptiveAirSuspCheckbox);
            checkList.Add(HeatingSysCheckbox);
            checkList.Add(CoolingGloveboxCheckbox);
            checkList.Add(DPFFilterCheckbox);
            checkList.Add(StereoCheckbox);
            checkList.Add(HeadlightsWashCheckbox);
            checkList.Add(ServoSteerAmplifierCheckbox);
            checkList.Add(SteeringAdjustmentCheckbox);
            checkList.Add(SeatsHeatingCheckbox);
            checkList.Add(RainSensorCheckbox);
            checkList.Add(FrontWindowHeatingCheckbox);
            checkList.Add(NavigationCheckbox);
            checkList.Add(SteeringHeaterCheckbox);
            checkList.Add(MultifunctionSteerCheckbox);
            checkList.Add(ClimatronicCheckbox);
            checkList.Add(ElSteerAmplifierCheckbox);
            checkList.Add(ElAdjustmentSeatsCheckbox);
            checkList.Add(ElAdjustmentSuspCheckbox);
            checkList.Add(ElMirrorsCheckbox);
            checkList.Add(ElWindowsCheckbox);
            checkList.Add(ECUCheckbox);
            checkList.Add(DifferentialLockCheckbox);
            checkList.Add(KeylessGoCheckbox);
            checkList.Add(USBAudioVideoAUXCheckbox);
            checkList.Add(SteptronicTiptronicCheckbox);
            checkList.Add(DvdTvCheckbox);
            checkList.Add(InStockCheckbox);
            checkList.Add(LeasingCheckbox);
            checkList.Add(MethanSysCheckbox);
            checkList.Add(NewImportCheckbox);
            checkList.Add(SevenSeatsCheckbox);
            checkList.Add(ServiceBookCheckbox);
            checkList.Add(TuningCheckbox);
            checkList.Add(FullServicedCheckbox);
            checkList.Add(RegisteredCheckbox);
            checkList.Add(FourWheelDriveCheckbox);
            checkList.Add(MetallicCheckbox);
            checkList.Add(FourOrFiveDoorsCheckbox);
            checkList.Add(HeatingWipesCheckbox);
            checkList.Add(XenonHeadlightsCheckbox);
            checkList.Add(SpoilerCheckbox);
            checkList.Add(PanoramicHatchCheckbox);
            checkList.Add(LedHeadlightsCheckbox);
            checkList.Add(DrawbarCheckbox);
            checkList.Add(DSACheckbox);
            checkList.Add(DistronicCheckbox);
            checkList.Add(DryBrakeSysCheckbox);
            checkList.Add(ISOFIXCheckbox);
            checkList.Add(SmartTireCheckbox);
            checkList.Add(ParktronicCheckbox);
            checkList.Add(ESPCheckbox);
            checkList.Add(ABSCheckbox);
            checkList.Add(AdaptiveFrontLightsCheckbox);
            checkList.Add(GPSCheckbox);
            checkList.Add(TwoOrThreeDoorsCheckbox);
            checkList.Add(HalogenLightsCheckbox);
            checkList.Add(ShuttleCheckbox);


            foreach (var box in checkList)
            {
                if (box.Checked)
                {
                    tempBuilder.Append(box.Text + "$");
                }
            }

            car.Extras += tempBuilder.ToString();
            ////if (this.AutoStartStopCheckBox.Checked)
            ////{
            ////    tempBuilder.Append("Auto start stop function" + "$");
            ////    //car.Extras += "Auto start stop function";
            ////    //car.Extras += "$";
            ////}

            ////if (this.BluetoothHFCheckbox.Checked)
            ////{
            ////    tempBuilder.Append("Bluetooth , handsfree система" + "$");
            ////    //car.Extras += "Bluetooth , handsfree система";
            ////    //car.Extras += "$";
            ////}

            ////if (this.DvdTvCheckbox.Checked)
            ////{
            ////    tempBuilder.Append("DVD, TV" + "$");
            ////    //car.Extras += "DVD, TV";
            ////    //car.Extras += "$";
            ////}

            ////if (this.SteptronicTiptronicCheckbox.Checked)
            ////{
            ////    tempBuilder.Append("Steptronic, Tiptronic" + "$");
            ////    //car.Extras += "Steptronic, Tiptronic";
            ////    //car.Extras += "$";
            ////}

            ////if (this.USBAudioVideoAUXCheckbox.Checked)
            ////{
            ////    tempBuilder.Append("USB, audio video, IN AUX изводи" + "$");
            ////    //car.Extras += "USB, audio video, IN AUX изводи";
            ////    //car.Extras += "$";
            ////}

            ////if (this.AdaptiveAirSuspCheckbox.Checked)
            ////{
            ////    tempBuilder.Append("Адаптивно въздушно окачване" + "$");
            ////    //car.Extras += "Адаптивно въздушно окачване";
            ////    //car.Extras += "$";
            ////}

            ////if (this.KeylessGoCheckbox.Checked)
            ////{
            ////    tempBuilder.Append("Безключово палене" + "$");
            ////    //car.Extras += "Безключово палене";
            ////    //car.Extras += "$";

            ////}

            ////if (this.DifferentialLockCheckbox.Checked)
            ////{
            ////    tempBuilder.Append("Блокаж на диференциала" + "$");
            ////    //car.Extras += "Блокаж на диференциала";
            ////    //car.Extras += "$";
            ////}

            ////if (this.ECUCheckbox.Checked)
            ////{
            ////    tempBuilder.Append("Бордкомпютър" + "$");
            ////    //car.Extras += "Бордкомпютър";
            ////    //car.Extras += "$";
            ////}

            ////if (this.ElMirrorsCheckbox.Checked)
            ////{
            ////    tempBuilder.Append("Ел. Огледала" + "$");
            ////    //car.Extras += "Ел. Огледала";
            ////    //car.Extras += "$";
            ////}

            ////if (this.ElWindowsCheckbox.Checked)
            ////{
            ////    tempBuilder.Append("Ел.стъкла" + "$");
            ////    //car.Extras += "Ел.стъкла";
            ////    //car.Extras += "$";
            ////}

            ////if (this.ElAdjustmentSuspCheckbox.Checked)
            ////{
            ////    tempBuilder.Append("Ел. регулиране на окачването" + "$");
            ////    //car.Extras += "Ел. регулиране на окачването";
            ////    //car.Extras += "$";
            ////}

            ////if (this.DPFFilterCheckbox.Checked)
            ////{
            ////    tempBuilder.Append("Филтър за твърди частици" + "$");
            ////    car.Extras += "Филтър за твърди частици";
            ////    car.Extras += "$";
            ////}

            ////if (this.CoolingGloveboxCheckbox.Checked)
            ////{
            ////    car.Extras += "Хладилна жабка";
            ////    car.Extras += "$";
            ////}

            ////if (this.StereoCheckbox.Checked)
            ////{
            ////    car.Extras += "Стерео уредба";
            ////    car.Extras += "$";
            ////}

            ////if (this.ElAdjustmentSeatsCheckbox.Checked)
            ////{
            ////    car.Extras += "Ел. регулиране на седалките";
            ////    car.Extras += "$";
            ////}

            ////if (this.ElSteerAmplifierCheckbox.Checked)
            ////{
            ////    car.Extras += "Ел. усилвател на волана";
            ////    car.Extras += "$";
            ////}

            ////if (this.AirConditioningCheckbox.Checked)
            ////{
            ////    car.Extras += "Климатик";
            ////    car.Extras += "$";
            ////}

            ////if (this.ClimatronicCheckbox.Checked)
            ////{
            ////    car.Extras += "Климатроник";
            ////    car.Extras += "$";
            ////}

            ////if (this.MultifunctionSteerCheckbox.Checked)
            ////{
            ////    car.Extras += "Мултифункционален волан";
            ////    car.Extras += "$";
            ////}

            ////if (this.NavigationCheckbox.Checked)
            ////{
            ////    car.Extras += "Навигация";
            ////    car.Extras += "$";
            ////}

            ////if (this.SteeringHeaterCheckbox.Checked)
            ////{
            ////    car.Extras += "Отопление на волана";
            ////    car.Extras += "$";
            ////}

            ////if (this.FrontWindowHeatingCheckbox.Checked)
            ////{
            ////    car.Extras += "Подгряване на предното стъкло";
            ////    car.Extras += "$";
            ////}

            ////if (this.AutopilotCheckbox.Checked)
            ////{
            ////    car.Extras += "Автопилот";
            ////    car.Extras += "$";
            ////}

            ////if (this.SeatsHeatingCheckbox.Checked)
            ////{
            ////    car.Extras += "Подгряване на седалките";
            ////    car.Extras += "$";
            ////}

            ////if (this.RainSensorCheckbox.Checked)
            ////{
            ////    car.Extras += "Сензор за дъжд";
            ////    car.Extras += "$";
            ////}

            ////if (this.SteeringAdjustmentCheckbox.Checked)
            ////{
            ////    car.Extras += "Регулиране на волана";
            ////    car.Extras += "$";
            ////}

            ////if (this.ServoSteerAmplifierCheckbox.Checked)
            ////{
            ////    car.Extras += "Серво усилвател на волана";
            ////    car.Extras += "$";
            ////}

            ////if (this.HeadlightsWashCheckbox.Checked)
            ////{
            ////    car.Extras += "Система за измиване на фаровете";
            ////    car.Extras += "$";
            ////}

            ////if (this.HeatingSysCheckbox.Checked)
            ////{
            ////    car.Extras += "Печка";
            ////    car.Extras += "$";
            ////}
        }

        private void clearSoldCarsButton_Click(object sender, EventArgs e)
        {
            ////mark item as sold 
            ////clear soldCarsList

            foreach (var item in soldCarsList)
            {
                if (item == null)
                {
                    return;
                }

                item.IsSold = true;
            }

            this.soldCarsList.Clear();
            //this.carsBinding.DataSource = this.dieler.CarsList.Where(x => x.IsSold == false).ToList();

            this.soldCarsBinding.ResetBindings(false);
            this.carsBinding.ResetBindings(false);
        }

        public void ClearTextboxes() // WORKS FINE
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

        public void TextboxesReadOnlyOrNot(bool condition) //// out of date
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

        private int NextContractNumber()
        {
            int result = int.Parse(Settings.Default["NumOfContracts"].ToString());
            Settings.Default["NumOfContracts"] = result + 1;
            Settings.Default.Save();
            return ++result;
        }



        private void carsListBox_DoubleClick(object sender, EventArgs e) //// WORK FINE
        {
            if (carsListBox.Items.Count > 0 && carsListBox.SelectedItem != null)
            {
                InfoForm infoForm = new InfoForm();

                infoForm.FillInfoFormTextbox(carsListBox.SelectedItem);
                
                infoForm.Show();

                ////soldCarsListBox.ClearSelected();
            }
        }

        private void soldCarsListBox_DoubleClick(object sender, EventArgs e) ////WORKS FINE
        {
            if (soldCarsListBox.Items.Count > 0 && soldCarsListBox.SelectedItem != null)
            {
                this.ClearTextboxes();
                var selectedIndex = soldCarsListBox.SelectedItem;
                carsListBox.ClearSelected();
            }
        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mileageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EngineVolumeCCTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //e.Handled = !char.IsDigit(e.KeyChar);
        }

        private void horsePowerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void WinTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            WinTextBox.CharacterCasing = CharacterCasing.Upper;
        }

        private void DielershipUI_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void DielershipUI_Load(object sender, EventArgs e)
        {   ////DeserializeXMLDatabase();
            carsListBox.Update();

            this.contractNumber = int.Parse(Settings.Default["NumOfContracts"].ToString());

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
