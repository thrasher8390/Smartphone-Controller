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
    public class ControllerBluetooth
    {
        private ActivityBluetooth activityBluetooth;
        private BluetoothAdapter myBluetoothAdapter;
        private ListView myListView;
        private ArrayAdapter<String> BTArrayAdapter;

        private ICollection<BluetoothDevice> pairedDevices;

        public ControllerBluetooth(ActivityBluetooth activityBluetooth)
        {
            this.activityBluetooth = activityBluetooth;

            myBluetoothAdapter = BluetoothAdapter.DefaultAdapter;
            myListView = (ListView)activityBluetooth.FindViewById(Resource.Id.lvAvailableBlueToothDevices);
            BTArrayAdapter = new ArrayAdapter<string>(activityBluetooth, Android.Resource.Layout.SimpleListItem1);
            myListView.Adapter = BTArrayAdapter;
        }

        internal void GetArrayAdapter()
        {
            pairedDevices = myBluetoothAdapter.BondedDevices;
            foreach(BluetoothDevice device in pairedDevices)
            {
                BTArrayAdapter.Add(device.Name + "\n" + device.Address);
            }

        }
    }
}