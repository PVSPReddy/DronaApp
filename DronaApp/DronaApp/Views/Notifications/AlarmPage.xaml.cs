using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using System.Linq;

namespace DronaApp
{
    public partial class AlarmPage : ContentPage
    {
        #region for Global VAriables
        bool isTimeSelected, isRepititionConfirmed, isDateSelected;
        string repeatType;
        ILocalNotifications localNotifications;
        List<AlarmData> listAlarmData;
        #endregion

        public AlarmPage()
        {
            #region for Local Variables
            listAlarmData = new List<AlarmData>();
            #endregion

            InitializeComponent();
            localNotifications = DependencyService.Get<ILocalNotifications>();
            string[] pickerItems = new string[] { "Don't Repeat", "Select Date", "Repeat Every Day", "Start in 6 sec and repeat every sec" };
            foreach (var item in pickerItems)
            {
                pickerAlarm.Items.Add(item);
            }
            datePickerAlarm.MinimumDate = DateTime.Today;
        }

        #region for Back Button Clicked
        void BackClicked(object sender, EventArgs e)
        {
            try
            {
                stackAlarmPopup.IsVisible = true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        #endregion

        #region for Time Selection
        void TimeSelected(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
                {
                    isTimeSelected = true;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        #endregion

        #region for Alarm Repetition selected
        void ItemSelected(object sender, EventArgs e)
        {
            try
            {
                var owner = ((Picker)sender);
                if (owner.SelectedIndex == -1)
                {
                    return;
                }
                else
                {
                    repeatType = (owner.Items[owner.SelectedIndex]);
                    switch (owner.Items[owner.SelectedIndex])
                    {
                        case "Don't Repeat":
                            datePickerAlarm.IsVisible = false;
                            StackDaysSelection.IsVisible = false;
                            isDateSelected = false;
                            break;
                        case "Select Date":
                            datePickerAlarm.IsVisible = true;
                            datePickerAlarm.Date = DateTime.Today;
                            lblSun.BackgroundColor = lblMon.BackgroundColor = lblTue.BackgroundColor = lblWed.BackgroundColor = lblThu.BackgroundColor = lblFri.BackgroundColor = lblSat.BackgroundColor = Color.Green;
                            StackDaysSelection.IsVisible = false;
                            break;
                        case "Repeat Every Day":
                            datePickerAlarm.IsVisible = false;
                            StackDaysSelection.IsVisible = true;
                            isDateSelected = false;
                            break;
                        case "Start in 6 sec and repeat every sec":
                            datePickerAlarm.IsVisible = false;
                            StackDaysSelection.IsVisible = false;
                            isDateSelected = false;
                            break;
                        default:
                            datePickerAlarm.IsVisible = false;
                            StackDaysSelection.IsVisible = false;
                            isDateSelected = false;
                            break;
                    }
                    isRepititionConfirmed = true;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        #endregion

        #region for Date Selected
        void alarmDateSelected(object sender, DateChangedEventArgs e)
        {
            try
            {
                isDateSelected = true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        #endregion

        #region for Repeat Days Selected
        void DaySelected(object sender, EventArgs e)
        {
            try
            {
                var owner = ((Label)sender);
                //owner.BackgroundColor = (owner.BackgroundColor == Color.Green) ? Color.Gray : Color.Green;
                if (owner.BackgroundColor == Color.Green)
                {
                    owner.BackgroundColor = Color.Gray;
                }
                else
                {
                    owner.BackgroundColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        #endregion

        #region for Cancel the larm Befor it is Created
        void CancelAlarm(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            stackAlarmPopup.IsVisible = false;
        }
        #endregion

        #region to submit the alarm
        void SubmitAlarm(object sender, EventArgs e)
        {
            lvAlarmData.BeginRefresh();
            try
            {
                if (listAlarmData.Count() > 0)
                {
                    var data = listAlarmData.Max(x => x.alarmId);
                }
                switch (repeatType)
                {
                    case "Don't Repeat":

                        break;
                    case "Select Date":

                        break;
                    case "Repeat Every Day":

                        break;
                    case "Start in 6 sec and repeat every sec":
                        localNotifications.GetNotificationImmediately();
                        break;
                    default:

                        break;
                }

                listAlarmData.Add(new AlarmData() { });
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            lvAlarmData.EndRefresh();
            stackAlarmPopup.IsVisible = false;
        }
        #endregion

    }

    public class AlarmData
    {
        public string alarmId { get; set; }

        public string alarmName { get; set; }

        public string alarmTime { get; set; }

        public string alarmType { get; set; }

        public string alarmCreatedOn { get; set; }

    }
}
