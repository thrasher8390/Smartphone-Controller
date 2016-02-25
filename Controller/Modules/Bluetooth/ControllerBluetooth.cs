using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Controller.Modules.Bluetooth
{
    public class ControllerBluetooth
    {
        private ActivityBluetooth activityBluetooth;
        public ControllerBluetooth(ActivityBluetooth activityBluetooth)
        {
            this.activityBluetooth = activityBluetooth;
        }
    }
}