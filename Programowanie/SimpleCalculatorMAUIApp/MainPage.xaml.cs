namespace SimpleCalculatorMAUIApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //pobranie danych
            //pobranie pierwszej liczby
            //pobranie drugiej liczby
            //obliczanie wyniku
            //pokazanie wyniku

            //int firstNumber = int.Parse(firstNumberEntry.Text);

            //int firstNumber, secondNumber;
            if (int.TryParse(firstNumberEntry.Text, out int firstNumber) && (int.TryParse(secondNumberEntry.Text, out int secondNumber)))
            {
                int result = firstNumber + secondNumber;
                resultLabel.Text = "Wynik to: " + result;
            }
            else
            {
                resultLabel.Text = "Podałeś nieprawidłowe dane";
            }
        }

    }
}
