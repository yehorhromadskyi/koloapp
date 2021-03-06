﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using koloapp.Services;
using koloapp.Views;

namespace koloapp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
