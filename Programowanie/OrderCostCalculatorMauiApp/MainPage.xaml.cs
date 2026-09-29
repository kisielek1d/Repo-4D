/*
 Zadanie – Kalkulator kosztu zamówienia
Napisz aplikację w .NET MAUI, która pozwala obliczyć koszt prostego zamówienia.

Aplikacja powinna zawierać:
- pole Nazwa produktu (Entry),
- pole Cena za sztukę (Entry),
- wybór liczby sztuk za pomocą kontrolki Stepper (od 1 do 10),
- Label wyświetlający aktualnie wybraną liczbę sztuk,
- przełącznik Dostawa ekspresowa (Switch),
- przycisk Oblicz,
- Label wyświetlający podsumowanie zamówienia i końcową cenę.

Zasady obliczeń:
Koszt zamówienia oblicz według wzoru:
cena za sztukę × liczba sztuk
Jeśli użytkownik włączy dostawę ekspresową, do ceny zamówienia należy doliczyć 15 zł.

Przykład:
Produkt: Słuchawki
Cena za sztukę: 120 zł
Liczba sztuk: 3
Dostawa ekspresowa: TAK  
Wynik: 375 zł



Dla chętnych: zamiast przełącznika dostawy ekspresowej dodaj Picker, który pozwala wybrać sposób dostawy:
- Odbiór osobisty – 0 zł
- Kurier – 12 zł
- Paczkomat – 10 zł
Wybrany sposób dostawy uwzględnij podczas obliczania końcowej ceny zamówienia.
*/

namespace OrderCostCalculatorMauiApp
{
    public partial class MainPage : ContentPage
    {
        private int stepperValue;

        public int StepperValue
        {
            get { return stepperValue; }
            set { stepperValue = value; OnPropertyChanged();}
        }


        public bool IsOn { get; set; } = false;

        public string Result { get; set; } = "";

        public Command Oblicz { get; }

        public MainPage()
        {
            InitializeComponent();

            Oblicz = new Command(ObliczZamowienie);
        }

        private void ObliczZamowienie()
        {
            string productName = ProductEntry.Text;

            if (!decimal.TryParse(PriceEntry.Text, out decimal price))
            {
                Result = "Podaj prawidłową cenę.";
                OnPropertyChanged(nameof(Result));
                return;
            }

            int quantity = StepperValue;

            decimal total = price * quantity;

            if (IsOn)
            {
                total += 15;
            }

            Result =
                $"Produkt: {productName}\n" +
                $"Cena za sztukę: {price:F2} zł\n" +
                $"Liczba sztuk: {quantity}\n" +
                $"Dostawa ekspresowa: {(IsOn ? "TAK" : "NIE")}\n" +
                $"Końcowa cena: {total:F2} zł";

            OnPropertyChanged(nameof(Result));
        }
        
    }
}
