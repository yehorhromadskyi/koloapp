using System;
using System.Collections.Generic;
using koloapp.ViewModels;
using Xamarin.Forms;

namespace koloapp.Views
{
    public partial class ProjectsPage : ContentPage
    {
        private ProjectsViewModel viewModel;

        public ProjectsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ProjectsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Projects.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}
