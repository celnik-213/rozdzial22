namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            UpdateLoginButtonColor();
        }

        private void OnEmailTextChanged(object sender, TextChangedEventArgs e)
        {
            string email = e.NewTextValue ?? string.Empty;
            bool isValid = email.Contains("@") && email.Contains(".");
            EmailErrorLabel.IsVisible = !isValid;
            UpdateLoginButtonColor();
        }

        private void OnPasswordTextChanged(object sender, TextChangedEventArgs e)
        {
            string password = e.NewTextValue ?? string.Empty;
            bool isValid = password.Length >= 6;
            PasswordErrorLabel.IsVisible = !isValid;
            UpdateLoginButtonColor();
        }

        void OnLoginClicked(object sender, EventArgs e)
        {
            DisplayAlert("Zalogowano", "Zalogowałeś się pomyślnie", "OK");
        }

        void UpdateLoginButtonColor()
        {
            string email = EmailEntry.Text ?? "";
            string password = PasswordEntry.Text ?? "";

            bool emailValid = email.Contains("@") && email.Contains(".");
            bool passwordValid = password.Length >= 6;

            if (emailValid && passwordValid)
            {
                LoginButton.BackgroundColor = Color.FromArgb("#22B14C");
            }
            else
            {
                LoginButton.BackgroundColor = Colors.Gray;
            }
        }
    }
    
}
/*
***********************************************
    nazwa funkcji: OnEmailTextChanged
    opis funkcji: Funkcja sprawdza czy wszystkie wymogi w polu email są spełnionie jeżeli nie to wyświetla stosowny komunikat.
    parametry: Brak
    zwracany typ i opis: Brak
    autor: Wiktor
************************************************
***********************************************
    nazwa funkcji: OnPassworTextChanged
    opis funkcji: Funkcja sprawdza czy wszystkie wymogi w polu hasło są spełnionie jeżeli nie to wyświetla stosowny komunikat.
    parametry: Brak
    zwracany typ i opis: Brak
    autor: Wiktor
************************************************
***********************************************
    nazwa funkcji: OnLoginClicked
    opis funkcji: Funkcja wyświetla komunikat o pozytywnym zalogowaniu.
    parametry: Brak
    zwracany typ i opis: Brak
    autor: Wiktor
************************************************
***********************************************
    nazwa funkcji: UpdateLoginButtonColor
    opis funkcji: Funkcja sprawdza czy wszystkie pola zostały uzupełnione poprawnie a następnie zmienia kolor przycisku na zielony.
    parametry: Brak
    zwracany typ i opis: Brak
    autor: Wiktor
************************************************
*/
