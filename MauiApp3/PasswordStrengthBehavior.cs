using System;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MauiApp3
{
    public class PasswordStrengthBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty StrengthLabelProperty =
            BindableProperty.Create(nameof(StrengthLabel), typeof(Label), typeof(PasswordStrengthBehavior), default(Label));

        public Label StrengthLabel
        {
            get => (Label)GetValue(StrengthLabelProperty);
            set => SetValue(StrengthLabelProperty, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnTextChanged;
        }

        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var text = e.NewTextValue ?? string.Empty;

            if (StrengthLabel == null)
                return;

            if (string.IsNullOrEmpty(text))
            {
                StrengthLabel.Text = string.Empty;
                return;
            }

            int score = 0;
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
}
