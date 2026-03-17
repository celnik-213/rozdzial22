using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MauiApp3;

public partial class NewPage2 : ContentPage

{

    public NewPage2()

    {

        InitializeComponent();

    }



    private List<string> ValidateRegistrationForm()

    {

        var errors = new List<string>();



        string email = EmailEntry?.Text ?? string.Empty;

        string password = PasswordEntry?.Text ?? string.Empty;

        string confirmPassword = ConfirmPasswordEntry?.Text ?? string.Empty;

        string ageText = AgeEntry?.Text ?? string.Empty;

        bool termsAccepted = TermsCheckBox?.IsChecked ?? false;



        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))

            errors.Add("Email jest wymagany i musi zawierać '@' oraz '.'.");



        if (string.IsNullOrEmpty(password))

            errors.Add("Hasło jest wymagane.");

        else if (!IsPasswordStrong(password))

            errors.Add("Hasło musi mieć min. 8 znaków, zawierać co najmniej jedną cyfrę i jedną wielką literę.");



        if (string.IsNullOrEmpty(confirmPassword))

            errors.Add("Potwierdzenie hasła jest wymagane.");

        else if (password != confirmPassword)

            errors.Add("Potwierdzenie hasła nie zgadza się z hasłem.");



        if (string.IsNullOrWhiteSpace(ageText) || !int.TryParse(ageText, out int age))

            errors.Add("Wiek musi być podany jako liczba.");

        else if (age < 13 || age > 120)

            errors.Add("Wiek musi być między 13 a 120 lat.");



        if (!termsAccepted)

            errors.Add("Należy zaakceptować regulamin.");



        return errors;

    }



    private bool IsPasswordStrong(string password)

    {

        if (string.IsNullOrEmpty(password))

            return false;



        if (password.Length < 8)

            return false;



        bool hasDigit = password.Any(char.IsDigit);

        bool hasUpper = password.Any(char.IsUpper);



        return hasDigit && hasUpper;

    }



    private void OnRegisterClicked(object sender, EventArgs e)

    {

        List<string> errors = ValidateRegistrationForm();



        if (errors.Count > 0)

        {

            string errorMessage = string.Join("\n• ", errors);

            DisplayAlert("Błędy walidacji", "• " + errorMessage, "OK");

        }

        else

        {

            DisplayAlert("Sukces", "Rejestracja zakończona pomyślnie!", "OK");



            // Czyszczenie pól 

            EmailEntry.Text = string.Empty;

            PasswordEntry.Text = string.Empty;

            ConfirmPasswordEntry.Text = string.Empty;

            AgeEntry.Text = string.Empty;

            if (TermsCheckBox != null) TermsCheckBox.IsChecked = false;

        }

    }
    
    private void UpdatePasswordStrength(object sender, TextChangedEventArgs e)
    {
        string text = e?.NewTextValue ?? string.Empty;
        int score = 0;

        if (string.IsNullOrEmpty(text))
        {
            StrengthLabel.Text = "";
            return;
        }

        if (text.Length >= 8) score++;
        if (text.Any(c => char.IsDigit(c))) score++;
        if (text.Any(c => char.IsUpper(c))) score++;

        switch (score)
        {
            case 0:
            case 1:
                StrengthLabel.Text = "Słabe";
                StrengthLabel.TextColor = Colors.Red;
                break;
            case 2:
                StrengthLabel.Text = "Średnie";
                StrengthLabel.TextColor = Colors.Orange;
                break;
            default:
                StrengthLabel.Text = "Silne";
                StrengthLabel.TextColor = Colors.Green;
                break;
        }
    }

}