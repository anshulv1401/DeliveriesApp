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

namespace DeliveriesApp.Droid
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        EditText emailEditText, passwordEditText, confirmPasswordEditText;
        Button registerButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_register);

            emailEditText = FindViewById<EditText>(Resource.Id.registerEmailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.registerPasswordEditText);
            confirmPasswordEditText = FindViewById<EditText>(Resource.Id.confirmPasswordEditText);
            registerButton = FindViewById<Button>(Resource.Id.registerUserButton);

            registerButton.Click += RegisterButton_Click;

            string email = Intent.GetStringExtra("Email");
            emailEditText.Text = email;
        }

        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            var result = await User.Register(emailEditText.Text, passwordEditText.Text, confirmPasswordEditText.Text);

            if (result)
                Toast.MakeText(this, "Success", ToastLength.Short).Show();
            else
                Toast.MakeText(this, "Try again", ToastLength.Short).Show();
        }
    }
}