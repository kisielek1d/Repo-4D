/*
Zadanie – Wypożyczalnia sprzętu sportowego

Napisz aplikację w .NET MAUI, która oblicza koszt wypożyczenia
wybranego sprzętu. Całość umieść na jednej stronie MainPage,
bez nawigacji.

Przygotuj w programie kolekcję sprzętu:
- Rower – 40 zł za dzień,
- Hulajnoga – 30 zł za dzień,
- Rolki – 20 zł za dzień,
- Kajak – 50 zł za dzień.

Aplikacja powinna zawierać:
- listę sprzętu – CollectionView z możliwością wyboru jednej pozycji;
  każdy element wyświetla nazwę sprzętu i cenę za dzień,
- imię i nazwisko klienta – Entry,
- liczbę dni wypożyczenia – Stepper od 1 do 7,
- Label pokazujący aktualną liczbę dni,
- ubezpieczenie – CheckBox,
- przycisk „Oblicz koszt”,
- Label wyświetlający podsumowanie.

Aktualna liczba dni powinna być wyświetlana za pomocą bindingu,
tak aby zmieniała się automatycznie wraz z wartością Steppera.

Ubezpieczenie kosztuje dodatkowo 5 zł za każdy dzień wypożyczenia.

Po naciśnięciu przycisku oblicz koszt i wyświetl:
- imię i nazwisko klienta,
- nazwę wybranego sprzętu,
- liczbę dni,
- informację o ubezpieczeniu,
- łączny koszt wypożyczenia.

Przed obliczeniem sprawdź, czy podano imię i nazwisko oraz wybrano
sprzęt. W razie brakujących danych wyświetl odpowiedni komunikat.

Przykład:
Klient: Jan Kowalski
Sprzęt: Rower
Liczba dni: 3
Ubezpieczenie: TAK
Koszt sprzętu: 3 × 40 zł = 120 zł
Ubezpieczenie: 3 × 5 zł = 15 zł
Łącznie: 135 zł
*/

using System.Collections.ObjectModel;

namespace SportsEquipmentRentalMauiApp
{
    public class Equipment
    {
        public string Name { get; set; } = string.Empty;
        public decimal PricePerDay { get; set; }
    }

    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Equipment> EquipmentList { get; set; }

        public MainPage()
        {
            InitializeComponent();

            EquipmentList = new ObservableCollection<Equipment>
            {
                new Equipment { Name = "Rower", PricePerDay = 40 },
                new Equipment { Name = "Hulajnoga", PricePerDay = 30 },
                new Equipment { Name = "Rolki", PricePerDay = 20 },
                new Equipment { Name = "Kajak", PricePerDay = 50 }
            };

            BindingContext = this;
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            string fullName = NameEntry.Text?.Trim() ?? string.Empty;
            Equipment? selectedEquipment = EquipmentCollectionView.SelectedItem as Equipment;

            if (string.IsNullOrWhiteSpace(fullName))
            {
                SummaryLabel.Text = "Błąd: Proszę podać imię i nazwisko.";
                return;
            }

            if (selectedEquipment == null)
            {
                SummaryLabel.Text = "Błąd: Proszę wybrać sprzęt z listy.";
                return;
            }

            int days = (int)DaysStepper.Value;
            bool hasInsurance = InsuranceCheckBox.IsChecked;

            decimal equipmentCost = days * selectedEquipment.PricePerDay;
            decimal insuranceCost = hasInsurance ? days * 5 : 0;
            decimal totalCost = equipmentCost + insuranceCost;

            string insuranceText = hasInsurance ? "TAK" : "NIE";

            string summary = $"Klient: {fullName}\n" +
                             $"Sprzęt: {selectedEquipment.Name}\n" +
                             $"Liczba dni: {days}\n" +
                             $"Ubezpieczenie: {insuranceText}\n" +
                             $"Koszt sprzętu: {days} × {selectedEquipment.PricePerDay} zł = {equipmentCost} zł\n";

            if (hasInsurance)
            {
                summary += $"Ubezpieczenie: {days} × 5 zł = {insuranceCost} zł\n";
            }

            summary += $"Łącznie: {totalCost} zł";

            SummaryLabel.Text = summary;
        }
    }
}