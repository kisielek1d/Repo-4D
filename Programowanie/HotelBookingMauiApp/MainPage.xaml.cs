/*
Zadanie – Rezerwacja pokoju hotelowego
Napisz aplikację w .NET MAUI, która pozwala przygotować prostą rezerwację pokoju hotelowego.

Użytkownik powinien podać następujące informacje:
- Imię i nazwisko – Entry,
- Adres e-mail – Entry,
- Data przyjazdu – DatePicker,
- Liczba nocy – Stepper (od 1 do 14),
- Liczba osób – Stepper (od 1 do 4),
- Rodzaj pokoju – Picker:
 - Pokój jednoosobowy – 200 zł / noc,
 - Pokój dwuosobowy – 300 zł / noc,
 - Apartament – 500 zł / noc,
- Śniadanie – Switch – dodatkowo 40 zł za osobę za każdą noc,
- Miejsce parkingowe – CheckBox – dodatkowo 30 zł za każdą noc,
- przycisk Oblicz koszt – Button,
- Label wyświetlający podsumowanie rezerwacji.

Aktualna liczba nocy oraz liczba osób powinna być wyświetlana obok odpowiednich kontrolek Stepper. Wykorzystaj do tego binding, tak aby wartości zmieniały się automatycznie.
Po naciśnięciu przycisku Oblicz koszt aplikacja powinna obliczyć całkowity koszt pobytu.

Przykład:
Imię i nazwisko: Jan Kowalski
Data przyjazdu: 15.10.2026
Liczba nocy: 3
Liczba osób: 2
Pokój: Pokój dwuosobowy
Śniadanie: TAK
Parking: TAK
Koszt pokoju: 3 × 300 zł = 900 zł
Śniadanie: 3 × 2 × 40 zł = 240 zł
Parking: 3 × 30 zł = 90 zł
Łącznie: 1230 zł
W podsumowaniu wyświetl imię i nazwisko klienta, datę przyjazdu, wybrany rodzaj pokoju, liczbę nocy, liczbę osób oraz całkowity koszt rezerwacji.

Dodatkowe wymagania:
- użytkownik nie może wybrać daty przyjazdu wcześniejszej niż dzisiejsza,
- przed wykonaniem obliczeń sprawdź, czy użytkownik podał imię i nazwisko oraz wybrał rodzaj pokoju,
- jeśli dane są niepoprawne lub niekompletne, wyświetl odpowiedni komunikat.

Dla chętnych: dodaj Slider pozwalający ustawić rabat od 0% do 20%. Aktualna wartość rabatu powinna być wyświetlana za pomocą Label i bindingu. Rabat należy uwzględnić w końcowej cenie rezerwacji.

*/
namespace HotelBookingMauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            string fullName = NameEntry.Text?.Trim();
            if (string.IsNullOrEmpty(fullName))
            {
                ResultLabel.Text = "Błąd: Proszę podać imię i nazwisko.";
                return;
            }

            if (RoomPicker.SelectedIndex == -1)
            {
                ResultLabel.Text = "Błąd: Proszę wybrać rodzaj pokoju.";
                return;
            }

            DateTime arrivalDate = ArrivalDatePicker.Date;
            int nights = (int)NightsStepper.Value;
            int guests = (int)GuestsStepper.Value;
            string roomTypeStr = RoomPicker.SelectedItem.ToString();

            decimal pricePerNight = 0;
            if (RoomPicker.SelectedIndex == 0) pricePerNight = 200;
            else if (RoomPicker.SelectedIndex == 1) pricePerNight = 300;
            else if (RoomPicker.SelectedIndex == 2) pricePerNight = 500;

            decimal roomCost = nights * pricePerNight;

            decimal breakfastCost = 0;
            if (BreakfastSwitch.IsToggled)
            {
                breakfastCost = nights * guests * 40;
            }

            decimal parkingCost = 0;
            if (ParkingCheckBox.IsChecked)
            {
                parkingCost = nights * 30;
            }

            decimal totalCost = roomCost + breakfastCost + parkingCost;

            ResultLabel.Text = $"--- PODSUMOWANIE REZERWACJI ---\n" +
                               $"Klient: {fullName}\n" +
                               $"Data przyjazdu: {arrivalDate:dd.MM.yyyy}\n" +
                               $"Pokój: {roomTypeStr} ({nights} nocy, {guests} os.)\n" +
                               $"Koszt pokoju: {roomCost} zł\n" +
                               (BreakfastSwitch.IsToggled ? $"Śniadanie: {breakfastCost} zł\n" : "") +
                               (ParkingCheckBox.IsChecked ? $"Parking: {parkingCost} zł\n" : "") +
                               $"Łącznie: {totalCost} zł";
        }
    }
}