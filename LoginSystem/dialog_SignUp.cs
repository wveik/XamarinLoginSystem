using System;
using Android.App;
using Android.Views;
using Android.OS;

namespace LoginSystem {
    public class dialog_SignUp : DialogFragment {

        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            
            
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);
            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState) {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); // Sets the title bar to invisible
            
            base.OnActivityCreated(savedInstanceState);

            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation; // set the animate
        }
    }
}

