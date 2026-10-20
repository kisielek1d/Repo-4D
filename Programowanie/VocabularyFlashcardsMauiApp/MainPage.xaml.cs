/*
Zadanie – Fiszki do nauki słówek

Napisz aplikację w .NET MAUI, która pomaga powtarzać angielskie
słówka. Całość umieść na jednej stronie MainPage, bez nawigacji.

Przygotuj w programie kolekcję fiszek. Każda fiszka powinna
przechowywać angielskie słowo i jego polskie tłumaczenie:
- apple – jabłko,
- house – dom,
- dog – pies,
- book – książka,
- bike – rower.

Aplikacja powinna zawierać:
- CarouselView wyświetlający angielskie słowo na każdej karcie,
- IndicatorView pokazujący aktualną pozycję wśród fiszek,
- przycisk „Pokaż tłumaczenie”,
- Label pod karuzelą, przeznaczony na polskie tłumaczenie,
- przycisk „Zacznij od początku”.

Działanie aplikacji:
- po uruchomieniu wyświetlana jest pierwsza fiszka,
- użytkownik przegląda fiszki, przesuwając karty,
- początkowo tłumaczenie jest ukryte,
- po naciśnięciu „Pokaż tłumaczenie” wyświetl tłumaczenie słowa
  z aktualnie widocznej karty,
- po zmianie fiszki wyczyść tłumaczenie, aby użytkownik mógł
  samodzielnie przypomnieć sobie znaczenie kolejnego słowa,
- przycisk „Zacznij od początku” wyświetla pierwszą fiszkę
  i również czyści tłumaczenie.

Angielskie słowo na karcie wyświetl za pomocą bindingu.

Przykład:
Aktualna karta: house
Przed naciśnięciem przycisku: tłumaczenie niewidoczne.
Po naciśnięciu „Pokaż tłumaczenie”: dom.
Po przejściu do kolejnej fiszki: tłumaczenie ponownie niewidoczne.
*/

using System.Collections.ObjectModel;

namespace VocabularyFlashcardsMauiApp
{
    public class Flashcard
    {
        public string English { get; set; } = string.Empty;
        public string Polish { get; set; } = string.Empty;
    }

    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Flashcard> Flashcards { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Flashcards = new ObservableCollection<Flashcard>
            {
                new Flashcard { English = "apple", Polish = "jabłko" },
                new Flashcard { English = "house", Polish = "dom" },
                new Flashcard { English = "dog", Polish = "pies" },
                new Flashcard { English = "book", Polish = "książka" },
                new Flashcard { English = "bike", Polish = "rower" }
            };

            BindingContext = this;
        }

        private void OnShowTranslationClicked(object? sender, EventArgs e)
        {
            if (FlashcardsCarousel.CurrentItem is Flashcard currentCard)
            {
                TranslationLabel.Text = currentCard.Polish;
            }
        }

        private void OnCurrentItemChanged(object? sender, CurrentItemChangedEventArgs e)
        {
            TranslationLabel.Text = string.Empty;
        }

        private void OnStartOverClicked(object? sender, EventArgs e)
        {
            if (Flashcards.Count > 0)
            {
                FlashcardsCarousel.Position = 0;
                TranslationLabel.Text = string.Empty;
            }
        }
    }
}