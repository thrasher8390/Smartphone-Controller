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

namespace Controller.Modules.Joystick
{
    [Activity(Label = "ActivityJoystick")]
    public class ActivityJoystick : Activity
    {
        private ControllerJoystick ControllerJoystick;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Joystick_Simple);

            this.ControllerJoystick = new ControllerJoystick();

            Button btnUp = FindViewById<Button>(Resource.Id.btnConnandUp);

            //todo this does nothing
            btnUp.Click += btnUp_Click;

            Button btnOff = FindViewById<Button>(Resource.Id.btnCommandOff);

            //todo this does nothing
            btnOff.Click += btnOff_Click;
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            ControllerJoystick.Off();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            ControllerJoystick.Up();
        }
    }
}