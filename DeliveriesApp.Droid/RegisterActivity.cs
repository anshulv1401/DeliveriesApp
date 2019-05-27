﻿using System;
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
            if (!string.IsNullOrEmpty(passwordEditText.Text))
            {
                if (passwordEditText.Text == confirmPasswordEditText.Text)
                {
                    var user = new User()
                    {
                        Email = emailEditText.Text,
                        Password = passwordEditText.Text
                    };
                    await MainActivity.MobileService.GetTable<User>().InsertAsync(user);
                    Toast.MakeText(this, "Success", ToastLength.Short).Show();
                    return;
                }
                Toast.MakeText(this, "Password don't match", ToastLength.Short).Show();
                return;
            }
            Toast.MakeText(this, "Password can not be empty", ToastLength.Short).Show();
        }
    }
}