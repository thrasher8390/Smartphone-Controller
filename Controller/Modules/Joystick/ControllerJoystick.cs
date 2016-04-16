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
using Controller.Modules.Bluetooth;
using Controller.Protocol;
namespace Controller.Modules.Joystick
{
    class ControllerJoystick
    {
        internal void Up()
        {
            ControllerBluetooth.Write(Command0.UP);
        }

        internal void Off()
        {
            ControllerBluetooth.Write(Command0.OFF);
        }
    }
}