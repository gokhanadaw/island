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
            BMIResultLabel.Text = "Hata: L�tfen ge�erli bir de�er giriniz.";
        }
    }


    private string GetBMICategory(double bmi)
    {
        string category = "";

        if (bmi < 16.0)
        {
            category = "�iddetli Zay�f";
            return category + ". Kilo alman�z gerekebilir. Sa�l�kl� ya�lar ve protein a��s�ndan zengin yiyecekleri (�rne�in, avokado, ceviz, yumurta) diyetinize eklemeyi d���nebilirsiniz. Bir beslenme uzman�na dan��man�z faydal� olabilir.";
        }
        else if (bmi >= 16.0 && bmi < 16.9)
        {
            category = "Orta Derecede Zay�f";
            return category + ". Kilo alman�z �nerilebilir. Kalori bak�m�ndan zengin, besleyici yiyecekler t�ketmeye �zen g�sterin. Y�ksek proteinli g�dalar, tam tah�llar ve sa�l�kl� ya�lar yard�mc� olabilir.";
        }
        else if (bmi >= 17.0 && bmi < 18.4)
        {
            category = "Hafif Zay�f";
            return category + ". Kilo almak i�in dengeli bir diyet ve d�zenli egzersiz yapman�z faydal� olabilir. Protein a��rl�kl� ve karbonhidrat i�eri�i y�ksek yiyecekleri tercih edebilirsiniz.";
        }
        else if (bmi >= 18.5 && bmi < 24.9)
        {
            category = "Normal";
            return category + ". Sa�l�kl� bir kilodas�n�z. D�zenli egzersiz yapmaya devam edin ve dengeli bir diyetle sa�l���n�z� koruyun.";
        }
        else if (bmi >= 25.0 && bmi < 29.9)
        {
            category = "Fazla Kilolu";
            return category + ". Kilo kayb� i�in bir beslenme plan� ve egzersiz program� olu�turmak iyi bir fikir olabilir. Azalt�lm�� kalorili, besleyici yiyecekler t�ketmeye �zen g�sterin.";
        }
        else if (bmi >= 30.0 && bmi < 34.9)
        {
            category = "1. Derece Obez";
            return category + ". Kilo vermek i�in profesyonel bir diyetisyen veya sa�l�k uzman�ndan yard�m alman�z tavsiye edilir. D�zenli egzersiz yaparak ve sa�l�kl� beslenerek kilo kayb� hedefleyebilirsiniz.";
        }
        else if (bmi >= 35.0 && bmi < 39.9)
        {
            category = "2. Derece Obez";
            return category + ". Kilo kayb� i�in sa�l�k profesyonelleriyle �al��man�z �nemlidir. Diyet, egzersiz ve ya�am tarz� de�i�iklikleri ile obeziteyi y�netmek m�mk�nd�r.";
        }
        else
        {
            category = "3. Derece Obez (Morbid Obez)";
            return category + ". T�bbi m�dahale gerektirebilir. Sa�l�k uzman�n�zla bir an �nce g�r���p, ki�isel bir tedavi plan� olu�turman�z gereklidir.";
        }
    }

}