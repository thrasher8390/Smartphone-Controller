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
using Android.Bluetooth;

namespace Controller.Modules.Bluetooth
{
    [Activity(Label = "ActivityBluetooth")]
    public class ActivityBluetooth : Activity
    {
        private ControllerBluetooth ControllerBluetooth;
        private ListView ConnectedBluetoothDevices;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Bluetooth);

            this.ControllerBluetooth = new ControllerBluetooth(this);

            ControllerBluetooth.OpenConnections();
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.ConnectToBluetooth);

            //todo this does nothing
            button.Click += delegate { button.Text = "You are connected"; };

            ConnectedBluetoothDevices = (ListView)FindViewById(Resource.Id.lvAvailableBlueToothDevices);
            ConnectedBluetoothDevices.ItemClick += connectedBluetoothDevices_ItemClick;
        }

        void connectedBluetoothDevices_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Get our item from the list adapter
            BluetoothDevice item = (BluetoothDevice)ConnectedBluetoothDevices.GetItemAtPosition(e.Position);

            //connect to device
            ControllerBluetooth.ConnectTtoDevice(item);

            //Make a toast with the item name just to show it was clicked
            Toast.MakeText(this, item.Name + " Clicked!", ToastLength.Short).Show();
        }
    }
}