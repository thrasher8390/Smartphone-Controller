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
    [Activity(Label = "ActivityBluetooth")]
    public class ActivityBluetooth : Activity
    {
        private ControllerBluetooth controllerBluetooth;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Bluetooth);

            this.controllerBluetooth = new ControllerBluetooth(this);

            controllerBluetooth.GetArrayAdapter();
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.ConnectToBluetooth);

            button.Click += delegate { button.Text = "You are connected"; };
        }
    }
}