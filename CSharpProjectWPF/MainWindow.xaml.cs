using System.Collections.ObjectModel;
using System.Windows;

namespace CSharpProjectWPF
{
    public partial class MainWindow : Window
    {
    private List<Shexs> shexsler = new List<Shexs>();
    private int totalPersonCount = 0;
    private int currentPersonIndex = 0;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        ErrorMessageBlock.Text = "";

        if (!int.TryParse(PersonCountTextBox.Text, out totalPersonCount) || totalPersonCount <= 0)
        {
            ErrorMessageBlock.Text = "Lütfən müsbət bir ədəd daxil edin.";
            return;
        }

        shexsler.Clear();
        currentPersonIndex = 0;
        InputPanel.Visibility = Visibility.Visible;
        ResultsPanel.Visibility = Visibility.Collapsed;
        ClearInputFields();
        ShowCurrentPerson();
    }

    private void ShowCurrentPerson()
    {
        PersonNumberLabel.Text = $"-- {currentPersonIndex + 1}-ci nəfər --";
    }

    private void ClearInputFields()
    {
        AdTextBox.Clear();
        AtaAdiTextBox.Clear();
        EmailTextBox.Clear();
        TelefonnomresiTextBox.Clear();
        YasTextBox.Clear();
        ErrorMessageBlock.Text = "";
    }

    private bool ValidateInputs(out Shexs? shexs)
    {
        shexs = null;
        ErrorMessageBlock.Text = "";

        // Ad validation
        if (string.IsNullOrEmpty(AdTextBox.Text) || !char.IsLetter(AdTextBox.Text[0]))
        {
            ErrorMessageBlock.Text = "Ad düzgün deyil.";
            return false;
        }

        // Ata adı validation
        if (string.IsNullOrEmpty(AtaAdiTextBox.Text) || !char.IsLetter(AtaAdiTextBox.Text[0]))
        {
            ErrorMessageBlock.Text = "Ata adı düzgün deyil.";
            return false;
        }

        // Email validation
        if (string.IsNullOrEmpty(EmailTextBox.Text) || !EmailTextBox.Text.Contains("@") || !EmailTextBox.Text.Contains("."))
        {
            ErrorMessageBlock.Text = "Düzgün e-poçt ünvanı daxil edin.";
            return false;
        }

        // Telefon validation
        if (TelefonnomresiTextBox.Text.Length != 10 || !long.TryParse(TelefonnomresiTextBox.Text, out long telefonNumre))
        {
            ErrorMessageBlock.Text = "Telefon nömrəsi düzgün deyil (10 rəqəm olmalıdır).";
            return false;
        }

        // Yaş validation
        if (!int.TryParse(YasTextBox.Text, out int yas) || yas <= 0)
        {
            ErrorMessageBlock.Text = "Yaşı düzgün daxil edin.";
            return false;
        }

        // Şəxs yaratma
        shexs = new Shexs
        {
            Ad = AdTextBox.Text,
            AtaAdi = AtaAdiTextBox.Text,
            Email = EmailTextBox.Text,
            Telefon = telefonNumre,
            Yas = yas
        };

        return true;
    }

    private void NextButton_Click(object sender, RoutedEventArgs e)
    {
        if (!ValidateInputs(out var shexs))
            return;

        shexsler.Add(shexs);
        currentPersonIndex++;

        if (currentPersonIndex < totalPersonCount)
        {
            ClearInputFields();
            ShowCurrentPerson();
        }
        else
        {
            ShowResults();
        }
    }

    private void FinishButton_Click(object sender, RoutedEventArgs e)
    {
        if (currentPersonIndex == 0)
        {
            ErrorMessageBlock.Text = "Ən azı bir şəxsin məlumatını daxil etməlisiniz.";
            return;
        }

        if (!ValidateInputs(out var shexs))
            return;

        shexsler.Add(shexs);
        ShowResults();
    }

    private void ShowResults()
    {
        InputPanel.Visibility = Visibility.Collapsed;
        ResultsPanel.Visibility = Visibility.Visible;

        ResultListBox.Items.Clear();
        foreach (var person in shexsler)
        {
            ResultListBox.Items.Add(person.ToString());
        }
    }

    private void RestartButton_Click(object sender, RoutedEventArgs e)
    {
        PersonCountTextBox.Clear();
        InputPanel.Visibility = Visibility.Collapsed;
        ResultsPanel.Visibility = Visibility.Collapsed;
        shexsler.Clear();
        currentPersonIndex = 0;
        ErrorMessageBlock.Text = "";
    }
    }
}
