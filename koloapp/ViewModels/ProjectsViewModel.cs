using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using koloapp.Models;
using Xamarin.Forms;

namespace koloapp.ViewModels
{
    public class ProjectsViewModel : BaseViewModel
    {
        public Command LoadDataCommand { get; set; }

        public ObservableCollection<Project> Projects { get; set; }

        public ProjectsViewModel()
        {
            Projects = new ObservableCollection<Project>();
            LoadDataCommand = new Command(async () => await ExecuteLoadDataCommand());
        }

        private async Task ExecuteLoadDataCommand()
        {
            IsBusy = true;

            await Task.Delay(200);

            try
            {
                Projects.Clear();

                foreach (var proj in new Project[] {
                        new Project { Name = "Save the Earth", Image = "greta.jpg", W = 100 },
                        new Project { Name = "Anti COVID-19 program", Image = "covid.jpg", W = 300 },
                        new Project { Name = "Local school computer class", Image = "class.jpg", W = 320 },
                    })
                {
                    Projects.Add(proj);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
