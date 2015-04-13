using System;
using Android.App;
using Android.Views;
using Android.OS;
using Android.Widget;

namespace LoginSystem {

    public class OnSignUpEventArgs : EventArgs {

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }

        public OnSignUpEventArgs(string firstName, string email, string password) : base() {
            Email = email;
            FirstName = firstName;
            Password = password;
        }
    }

    public class dialog_SignUp : DialogFragment {

        private EditText mTxtFirstName;
        private EditText mTxtEmail;
        private EditText mTxtPassword;
        private Button mBtnSignUp;

        public event EventHandler<OnSignUpEventArgs> mOnSignUpComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);

            mTxtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            mTxtFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            mTxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            mBtnSignUp = view.FindViewById<Button>(Resource.Id.btnDialogEmail);

            mBtnSignUp.Click += mBtnSignUp_Click;

            return view;
        }

        void mBtnSignUp_Click(object sender, EventArgs e) {
            //User has clicked sign up button
            mOnSignUpComplete.Invoke(this, new OnSignUpEventArgs(mTxtFirstName.Text, mTxtEmail.Text, mTxtPassword.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState) {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); // Sets the title bar to invisible
            
            base.OnActivityCreated(savedInstanceState);

            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation; // set the animate
        }
    }
}

