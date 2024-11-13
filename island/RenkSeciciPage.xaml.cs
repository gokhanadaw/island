using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
namespace island;
public partial class RenkSeciciPage : ContentPage
{
	public RenkSeciciPage()
	{
		InitializeComponent();
	}
    private void OnCopyColorCode(object sender, EventArgs e)
    {
        
        var colorCode = ColorCodeLabel.Text.Replace("Renk Kodu: ", ""); 
        Clipboard.SetTextAsync(colorCode);
        DisplayAlert("Kopyalandý", "Renk kodu panoya kopyalandý: " + colorCode, "Tamam");
    }
    private void OnRandomColor(object sender, EventArgs e)
    {
        Random random = new Random();
        RedSlider.Value = random.Next(0, 256);
        GreenSlider.Value = random.Next(0, 256);
        BlueSlider.Value = random.Next(0, 256);
    }


    private void OnColorSliderChanged(object sender, ValueChangedEventArgs e)
    {

        int red = (int)RedSlider.Value;
        int green = (int)GreenSlider.Value;
        int blue = (int)BlueSlider.Value;


        var selectedColor = new Color(Convert.ToSingle(red) / 255, Convert.ToSingle(green) / 255, Convert.ToSingle(blue) / 255);


        ColorDisplayFrame.BackgroundColor = selectedColor;


        ColorCodeLabel.Text = $"Renk Kodu: #{red:X2}{green:X2}{blue:X2}";
    }


}