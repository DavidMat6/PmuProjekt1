using System;

namespace PmuProjekt1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        ModePicker.SelectedIndex = 0;
        OnModeChanged(null, EventArgs.Empty); 
    }

    
    private void OnModeChanged(object sender, EventArgs e)
    {
        
        if (ModePicker.SelectedIndex == 0) 
        {
            MagSilaLayout.IsVisible = true;
            ElEnergijaLayout.IsVisible = false;
        }
        else if (ModePicker.SelectedIndex == 1) 
        {
            MagSilaLayout.IsVisible = false;
            ElEnergijaLayout.IsVisible = true;
        }
    }

   
    private void OnCalculateSilaClicked(object sender, EventArgs e)
    {
        if (double.TryParse(Duljina.Text, out double duljina) &&
            double.TryParse(Struja.Text, out double struja) &&
            double.TryParse(Polje.Text, out double polje) &&
            double.TryParse(Kut.Text, out double kut))
        {
            double radiani = Math.PI * kut / 180; 
            double sila = struja * duljina * polje * Math.Sin(radiani);
            MagSilaRezultat.Text = $"Magnetska sila: {sila:F2} N";
        }
        else
        {
            MagSilaRezultat.Text = "Molimo unesite ispravne brojeve.";
        }
    }

    
    private void OnCalculateEnergijaClicked(object sender, EventArgs e)
    {
        if (double.TryParse(SnagaEntry.Text, out double snaga) &&
            double.TryParse(VrijemeEntry.Text, out double vrijeme))
        {
            double energija = snaga * vrijeme; 
            EnergijaRezultat.Text = $"Električna energija: {energija:F2} Wh";
        }
        else
        {
            EnergijaRezultat.Text = "Molimo unesite ispravne brojeve.";
        }
    }
}

