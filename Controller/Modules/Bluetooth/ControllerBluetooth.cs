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
using System.IO;

namespace Controller.Modules.Bluetooth
{
    public class ControllerBluetooth
    {
        private ActivityBluetooth ActivityBluetooth;
        private BluetoothAdapter MyBluetoothAdapter;
        private ListView MyListView;
        private ArrayAdapter<BluetoothDevice> BTArrayAdapter;

        private ICollection<BluetoothDevice> PairedDevices;

        BluetoothSocket Socket;
        private static Stream OutputStream;
        private Stream InStream;

        public ControllerBluetooth(ActivityBluetooth activityBluetooth)
        {
            this.ActivityBluetooth = activityBluetooth;

            MyBluetoothAdapter = BluetoothAdapter.DefaultAdapter;
            MyListView = (ListView)activityBluetooth.FindViewById(Resource.Id.lvAvailableBlueToothDevices);
            BTArrayAdapter = new ArrayAdapter<BluetoothDevice>(activityBluetooth, Android.Resource.Layout.SimpleListItem1);
            MyListView.Adapter = BTArrayAdapter;
        }

        /// <summary>
        /// Find all devices to display
        /// </summary>
        internal void OpenConnections()
        {
            PairedDevices = MyBluetoothAdapter.BondedDevices;
            foreach(BluetoothDevice device in PairedDevices)
            {
                //TODO Only add HC05 to the list since this is what we support at the momment
                if (device.Name.Contains("HC"))
                {
                    BTArrayAdapter.Add(device);
                }
            }
        }

        /// <summary>
        /// When an item is selected we  should try to connect to the selected device
        /// </summary>
        /// <param name=""></param>
        internal void ConnectTtoDevice(BluetoothDevice device)
        {
            ParcelUuid[] uuids = device.GetUuids();
            Socket = device.CreateRfcommSocketToServiceRecord(uuids[0].Uuid);
            try
            { 
                Socket.Connect();
            }
            catch(IOException e)
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            OutputStream = Socket.OutputStream;
            InStream = Socket.InputStream;
        }

        //todo fix the static
        public static void Write(byte[] s)
        {
            OutputStream.Write(s,0,s.Count());
        }

        public void run()
        {
            const int BUFFER_SIZE = 1024;
            byte[] buffer = new byte[BUFFER_SIZE];
            int bytes = 0;
            int b = BUFFER_SIZE;

            while (true)
            {
                try
                {
                    bytes = InStream.Read(buffer, bytes, BUFFER_SIZE - bytes);
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
        }
    }
}