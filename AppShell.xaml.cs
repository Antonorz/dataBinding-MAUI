﻿namespace Ejercicio_dataBinding_MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(FormPage), typeof(FormPage));
        }
    }
}
