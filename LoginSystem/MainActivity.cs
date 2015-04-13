using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;

namespace LoginSystem {
    [Activity(Label = "Крутое приложение", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity {

        private Button mBtnSignUp;
        private ProgressBar mProgressWait;

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mBtnSignUp = FindViewById<Button>(Resource.Id.btnSignUpWithEmail);
            mProgressWait = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            mBtnSignUp.Click += (object sender, EventArgs args) => { 
                //Pull up dialog
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                dialog_SignUp signUpDialog = new dialog_SignUp();
                signUpDialog.Show(transaction, "dialog_fragment");

                signUpDialog.mOnSignUpComplete += signUpDialog_mOnSignUpComplete;
            };
        }

        void signUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e) {
            
            Thread thread = new Thread(ActLikeARequest);

            thread.Start();
        }

        private void ActLikeARequest() {
            RunOnUiThread(() => { 
                mProgressWait.Visibility = ViewStates.Visible; 
            });
            
            Thread.Sleep(3000);
            
            RunOnUiThread(() => {
                mProgressWait.Visibility = ViewStates.Invisible;
            });
        }

    }
}

