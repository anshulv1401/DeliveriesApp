using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Microsoft.WindowsAzure.MobileServices;

namespace DeliveriesApp.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("Uri for Azure server");

        EditText emailEditText, passwordEditText;
        Button signinButton, registerButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_login);

            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            signinButton = FindViewById<Button>(Resource.Id.signinButton);
            registerButton = FindViewById<Button>(Resource.Id.registerButton);

            signinButton.Click += SigninButton_Click;

            registerButton.Click += RegisterButton_Click;
        }

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisterActivity));
            intent.PutExtra("Email",emailEditText.Text);
            StartActivity(intent);
        }

        private void SigninButton_Click(object sender, System.EventArgs e)
        {

        }
    }
}