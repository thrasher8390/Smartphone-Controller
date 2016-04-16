using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Controller.Modules.Bluetooth;
using Controller.Modules.Joystick;

namespace Controller.Modules.Main
{
    [Activity(Label = "Controller", MainLauncher = true, Icon = "@drawable/icon")]
    public class ActivityMain : Activity
    {
        private ControllerMain controllerMain;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            this.controllerMain = new ControllerMain(this);

            // Get our button from the layout resource,
            // and attach an event to it
            Button bluetooth = FindViewById<Button>(Resource.Id.btnBluetooth);

            bluetooth.Click += delegate
            {
                StartActivity(typeof(ActivityBluetooth));
            };
            // Get our button from the layout resource,
            // and attach an event to it
            Button joystick = FindViewById<Button>(Resource.Id.btnJoystick);

            joystick.Click += delegate {
                StartActivity(typeof(ActivityJoystick));
            };
        }
    }
}

