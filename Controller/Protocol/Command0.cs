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

namespace Controller.Protocol
{
    public static class Command0
    {
        public static readonly byte[] UP = new byte[] { 0x00, 0x05, 0x00 };
        public static readonly byte[] OFF = new byte[] { 0x00, 0x09, 0x00 };
    }
}