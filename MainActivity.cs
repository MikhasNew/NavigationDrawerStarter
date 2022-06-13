﻿using System;
using Android;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;


using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.View;
using AndroidX.DrawerLayout.Widget;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Navigation;
using Google.Android.Material.Snackbar;
using NavigationDrawerStarter.Fragments;

namespace NavigationDrawerStarter
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        DrawerLayout drawer;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            //var welcomeTransaction = SupportFragmentManager.BeginTransaction();
            //welcomeTransaction.Add(Resource.Id.fragment_container, new Welcome(), "Welcome");
            //welcomeTransaction.Commit();


        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            if (id == Resource.Id.action_openRight)
            {
                var filterFragmentTransaction = SupportFragmentManager.BeginTransaction();
                filterFragmentTransaction.Add(Resource.Id.diagramEditorSlideInMenuFragmentHolder, new RightMenu(), "MENU");
                filterFragmentTransaction.Commit();

                drawer.OpenDrawer(GravityCompat.End);
                return true;
            }

                return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            //if (id == Resource.Id.nav_camera)
            //{
            //    // Handle the camera action
            //    var welcomeTransaction = SupportFragmentManager.BeginTransaction();
            //    welcomeTransaction.Replace(Resource.Id.fragment_container, new Welcome(), "Welcome");
            //    welcomeTransaction.Commit();
            //}
            //else if (id == Resource.Id.nav_gallery)
            //{
            //    var menuTransaction = SupportFragmentManager.BeginTransaction();
            //    menuTransaction.Replace(Resource.Id.fragment_container, new Fragment1(), "Fragment1");
            //    menuTransaction.Commit();
            //}
            //else if (id == Resource.Id.nav_slideshow)
            //{
            //    var menuTransaction = SupportFragmentManager.BeginTransaction();
            //    menuTransaction.Replace(Resource.Id.fragment_container, new Fragment2(), "Fragment2");
            //    menuTransaction.Commit();
            //}
            //else if (id == Resource.Id.nav_manage)
            //{
            //    var welcomeTransaction = SupportFragmentManager.BeginTransaction();
            //    welcomeTransaction.Replace(Resource.Id.fragment_container, new Welcome(), "Welcome");
            //    welcomeTransaction.Commit();
            //}
            //else if (id == Resource.Id.nav_share)
            //{
            //    var welcomeTransaction = SupportFragmentManager.BeginTransaction();
            //    welcomeTransaction.Replace(Resource.Id.fragment_container, new Welcome(), "Welcome");
            //    welcomeTransaction.Commit();
            //}
            //else if (id == Resource.Id.nav_send)
            //{
            //    var welcomeTransaction = SupportFragmentManager.BeginTransaction();
            //    welcomeTransaction.Replace(Resource.Id.fragment_container, new Welcome(), "Welcome");
            //    welcomeTransaction.Commit();
            //}

            //DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            //drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

