using System;
using System.Text.RegularExpressions;

public class Student
{
    public int idNumber { get; set; }
    public string name { get; set; }
    public string course { get; set; }

    public override string ToString()
    {
        return $"{idNumber} - {name} - {course}";
    }

    public void ValidateInfo()
    {
        bool isValidName = Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        bool isValidIdNumber = idNumber.ToString().Length == 9;

        if (isValidName && isValidIdNumber)
        {
            Console.WriteLine("Student information is valid.");
        }
        else
        {
            Console.WriteLine("Student information is not valid.");
        }
    }
}