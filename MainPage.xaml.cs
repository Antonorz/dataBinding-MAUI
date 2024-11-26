﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;

namespace Ejercicio_dataBinding_MAUI
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

        private readonly HttpClient _httpClient = new HttpClient();
        private ObservableCollection<PersonaModel> _personas;
        public ObservableCollection<PersonaModel> Personas
        {
            get => _personas;
            set
            {
                _personas = value;
                OnPropertyChanged();
            }
        }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            GetData();
        }

        public async void GetData()
        {
            var response = await _httpClient
                .GetStringAsync("https://fi.jcaguilar.dev/v1/escuela/persona");
            var personas = JsonSerializer
                .Deserialize<ObservableCollection<PersonaModel>>(response);

            Personas = personas;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FormPage());
        }
    }

}
