﻿using Plugin.AudioRecorder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MV2AudioRecorder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarAudioPage : ContentPage
    {
        private readonly AudioPlayer audioPlayer = new AudioPlayer();
        Models.AudioModel audio;


        public ListarAudioPage()
        {
            InitializeComponent();
        }

        private void listaAudios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
              audio = (Models.AudioModel)e.Item;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listaAudios.ItemsSource = await App.BaseDatos.ObtenerListaAudios();
        }

        private async void btndelete_Invoked(object sender, EventArgs e)
        {
            
            if(await DisplayAlert("Eliminar nota", "¿Esta seguro de eliminar nota seleccionada: " + audio.Descripcion+" ?", "SI", "NO"))
            {
                await App.BaseDatos.EliminarAudio(audio);
                await Navigation.PopAsync();
            }
            
               
        }

        private async void btnplay_Invoked(object sender, EventArgs e)
        {
            if(audio != null)
            {
                var ruta = await App.BaseDatos.ObtenerAudio(audio.Id);
                audioPlayer.Play(ruta.Url);
            }
            else
            {
                await DisplayAlert("Notificación", "Haga clic sobre el elemento que desea reproducir o eliminar", "OK");
            }

        }

 
    }
}