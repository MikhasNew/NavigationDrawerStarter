using Android.OS;

using Android.Views;

using AndroidX.Fragment.App;

namespace NavigationDrawerStarter.Fragments
{
    public class RightMenu : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.right_menu, container, false);
        }
    }
}
