namespace EventVsBindingMauiApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if(rotationSlider is not null)
            {
                rotationLabel.Rotation = rotationSlider.Value;
            }
        }
        private void Slider_ValueChanged2(object sender, ValueChangedEventArgs e)
        {
            if (rotationSlider2 is not null)
            {
                rotationLabel.Rotation = rotationSlider2.Value;
            }
        }
    }
}
