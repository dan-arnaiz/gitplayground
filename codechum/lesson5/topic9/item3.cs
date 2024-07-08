using System;
using System.Linq;

public class InputElement
{
    private int maxLength;
    private string value;

    public InputElement(int maxLength)
    {
        this.maxLength = maxLength;
        this.value = string.Empty;
    }

    public string GetValue()
    {
        return value;
    }

    public void SetValue(char c)
    {
        if (c == '/' && value.Length > 0)
        {
            value = value.Substring(0, value.Length - 1);
        }
        else if (value.Length < maxLength)
        {
            value += c;
        }
    }

    public virtual bool Validate()
    {
        return value.Length >= 1 && value.Length <= maxLength;
    }
}

public class PasswordInputElement : InputElement
{
    private char[] allowedCharacters;

    public PasswordInputElement(int maxLength, char[] allowedCharacters) : base(maxLength)
    {
        this.allowedCharacters = allowedCharacters;
    }

    public override bool Validate()
    {
        return base.Validate() && GetValue().All(c => allowedCharacters.Contains(c));
    }
}

public class CustomPasswordInputElement : PasswordInputElement
{
    public CustomPasswordInputElement(int maxLength) : base(maxLength, new char[] { 'J', 'r', 'v', 'D' })
    {
    }
}

public class PasswordField
{
    public void Validate(string password, PasswordInputElement passwordInputElement)
    {
        foreach (char c in password)
        {
            passwordInputElement.SetValue(c);
        }

        bool isValid = passwordInputElement.Validate();
        Console.WriteLine($"Password validation result: {isValid}");
    }
}