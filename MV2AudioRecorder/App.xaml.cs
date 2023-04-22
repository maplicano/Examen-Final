using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MV2AudioRecorder.Models;
using System.IO;

namespace MV2AudioRecorder
{
    public partial class App : Application
    {
        static AudioModelDB basedatos;
        public static AudioModelDB BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new AudioModelDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AudiosDB.db3"));
                }
                return basedatos;
            }
        }
        public App()
        {
            InitializeComponent();
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
