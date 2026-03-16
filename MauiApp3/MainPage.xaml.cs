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