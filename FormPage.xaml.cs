using System.ComponentModel;
using System.Text.Json;
using System.Text;

namespace Ejercicio_dataBinding_MAUI;

public partial class FormPage : ContentPage, INotifyPropertyChanged
{
    private readonly HttpClient _httpClient = new HttpClient();
    private string nombre = "";
    public string Nombre
    {
        get => nombre;
        set
        {
            nombre = value;
            OnPropertyChanged();
        }
    }
    private string apellido = "";
    public string Apellido
    {
        get => apellido;
        set
        {
            apellido = value;
            OnPropertyChanged();
        }
    }
    private string sexo = "";
    public string Sexo
    {
        get => sexo;
        set
        {
            sexo = value;
            OnPropertyChanged();
        }
    }
    private string id_rol = "";
    public string Id_rol
    {
        get => id_rol;
        set
        {
            id_rol = value;
            OnPropertyChanged();
        }
    }
    private DateTime fh_nac = DateTime.Now;
    public DateTime Fh_nac
    {
        get => fh_nac;
        set
        {
            fh_nac = value;
            OnPropertyChanged();
        }
    }
    public FormPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        PersonaModel persona = new PersonaModel();
        persona.nombre = Nombre;
        persona.apellido = Apellido;
        persona.fh_nac = Fh_nac.ToString("yyyy-MM-dd");
        persona.sexo = Sexo;
        persona.id_rol = int.Parse(Id_rol);

        string json = JsonSerializer.Serialize(persona);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://fi.jcaguilar.dev/v1/escuela/persona", content);

    }

    private async void Volver_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}