namespace island;

public partial class KrediHesaplamaPage : ContentPage
{
	public KrediHesaplamaPage()
	{
		InitializeComponent();
	}
    private void OnCalculateClicked(object sender, EventArgs e)
    {
        try
        {
            double krediTutar = double.Parse(KrediTutarEntry.Text);
            double faizOrani = double.Parse(FaizOraniEntry.Text) / 100;
            int vadeAy = int.Parse(VadeEntry.Text);

            double aylikFaizOrani = faizOrani / 12;
            double aylikTaksit = (krediTutar * aylikFaizOrani) / (1 - Math.Pow(1 + aylikFaizOrani, -vadeAy));

            double toplamOdeme = aylikTaksit * vadeAy;
            double toplamFaiz = toplamOdeme - krediTutar;

            AylikTaksitLabel.Text = $"Ayl�k Taksit: {aylikTaksit:C2}";
            ToplamOdemeLabel.Text = $"Toplam �deme: {toplamOdeme:C2}";
            ToplamFaizLabel.Text = $"Toplam Faiz: {toplamFaiz:C2}";
        }
        catch (Exception ex)
        {
            DisplayAlert("Hata", "L�tfen ge�erli veriler giriniz.", "Tamam");
        }
    }

}