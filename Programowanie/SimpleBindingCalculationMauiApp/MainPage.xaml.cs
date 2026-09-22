namespace SimpleBindingCalculationMauiApp
{
    public partial class MainPage : ContentPage
    {
        public string FirstNumber { get; set; }
        public string SecondNumber { get; set; }
        public string ResultMessage { get; set; }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(FirstNumber, out int firstNumber) && int.TryParse(SecondNumber, out int secondNumber))
            {
                int result = firstNumber + secondNumber;
                ResultMessage = "Wynik to: " + result;
            }
            else
            {
                ResultMessage = "Podałeś nieprawidłowe dane";
            }

            OnPropertyChanged(nameof(ResultMessage));
        }
    }
}