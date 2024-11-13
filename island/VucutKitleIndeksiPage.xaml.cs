using Microsoft.Maui.Controls;
using System;

namespace island;

public partial class VucutKitleIndeksiPage : ContentPage
{
	public VucutKitleIndeksiPage()
	{
		InitializeComponent();
	}
    private void OnHeightEntryChanged(object sender, TextChangedEventArgs e)
    {
        if (double.TryParse(e.NewTextValue, out double height))
            HeightSlider.Value = height;
    }

    private void OnHeightSliderChanged(object sender, ValueChangedEventArgs e)
    {
        HeightEntry.Text = e.NewValue.ToString("F1");
    }


    private void OnWeightEntryChanged(object sender, TextChangedEventArgs e)
    {
        if (double.TryParse(e.NewTextValue, out double weight))
            WeightSlider.Value = weight;
    }

    private void OnWeightSliderChanged(object sender, ValueChangedEventArgs e)
    {
        WeightEntry.Text = e.NewValue.ToString("F1");
    }


    private void OnCalculateButtonClicked(object sender, EventArgs e)
    {
        try
        {
            double height = HeightSlider.Value / 100;
            double weight = WeightSlider.Value;

            double bmi = weight / (height * height);


            BMIResultLabel.Text = $"BMI: {bmi:F1}";

            string bmiCategory = GetBMICategory(bmi);
            BMIResultLabel.Text += $"\nKategori: {bmiCategory}";
        }
        catch (Exception)
        {
            BMIResultLabel.Text = "Hata: Lütfen geçerli bir deðer giriniz.";
        }
    }


    private string GetBMICategory(double bmi)
    {
        string category = "";

        if (bmi < 16.0)
        {
            category = "Þiddetli Zayýf";
            return category + ". Kilo almanýz gerekebilir. Saðlýklý yaðlar ve protein açýsýndan zengin yiyecekleri (örneðin, avokado, ceviz, yumurta) diyetinize eklemeyi düþünebilirsiniz. Bir beslenme uzmanýna danýþmanýz faydalý olabilir.";
        }
        else if (bmi >= 16.0 && bmi < 16.9)
        {
            category = "Orta Derecede Zayýf";
            return category + ". Kilo almanýz önerilebilir. Kalori bakýmýndan zengin, besleyici yiyecekler tüketmeye özen gösterin. Yüksek proteinli gýdalar, tam tahýllar ve saðlýklý yaðlar yardýmcý olabilir.";
        }
        else if (bmi >= 17.0 && bmi < 18.4)
        {
            category = "Hafif Zayýf";
            return category + ". Kilo almak için dengeli bir diyet ve düzenli egzersiz yapmanýz faydalý olabilir. Protein aðýrlýklý ve karbonhidrat içeriði yüksek yiyecekleri tercih edebilirsiniz.";
        }
        else if (bmi >= 18.5 && bmi < 24.9)
        {
            category = "Normal";
            return category + ". Saðlýklý bir kilodasýnýz. Düzenli egzersiz yapmaya devam edin ve dengeli bir diyetle saðlýðýnýzý koruyun.";
        }
        else if (bmi >= 25.0 && bmi < 29.9)
        {
            category = "Fazla Kilolu";
            return category + ". Kilo kaybý için bir beslenme planý ve egzersiz programý oluþturmak iyi bir fikir olabilir. Azaltýlmýþ kalorili, besleyici yiyecekler tüketmeye özen gösterin.";
        }
        else if (bmi >= 30.0 && bmi < 34.9)
        {
            category = "1. Derece Obez";
            return category + ". Kilo vermek için profesyonel bir diyetisyen veya saðlýk uzmanýndan yardým almanýz tavsiye edilir. Düzenli egzersiz yaparak ve saðlýklý beslenerek kilo kaybý hedefleyebilirsiniz.";
        }
        else if (bmi >= 35.0 && bmi < 39.9)
        {
            category = "2. Derece Obez";
            return category + ". Kilo kaybý için saðlýk profesyonelleriyle çalýþmanýz önemlidir. Diyet, egzersiz ve yaþam tarzý deðiþiklikleri ile obeziteyi yönetmek mümkündür.";
        }
        else
        {
            category = "3. Derece Obez (Morbid Obez)";
            return category + ". Týbbi müdahale gerektirebilir. Saðlýk uzmanýnýzla bir an önce görüþüp, kiþisel bir tedavi planý oluþturmanýz gereklidir.";
        }
    }

}