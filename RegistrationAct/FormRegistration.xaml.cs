using System;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace RegistrationAct;

/// <summary>
/// Interaction logic for FormRegistration.xaml
/// </summary>
public partial class FormRegistration
{
    private string _fullName = null!;
    private byte _age;
    private long _studentNo;
    private long _contactNo;
    private FrmStudentRecord _frmStudentRecord = new();


    public FormRegistration()
    {
        InitializeComponent();
    }

    private void FormRegistration_OnLoaded(object sender, RoutedEventArgs e)
    {
        var listOfPrograms = new[]
        {
            "BS Information Technology",
            "BS Computer Science",
            "BS Information Systems",
            "BS in Accountancy",
            "BS in Hospitality Management",
            "BS in Tourism Management"
        };

        foreach (var t in listOfPrograms)
        {
            CbPrograms.Items.Add(t);
        }

        foreach (var gender in new[] { "Male", "Female", "Non-Binary" })
        {
            CbGender.Items.Add(gender);
        }
    }

    private long StudentNumber(string studNum)
    {
        if (Regex.IsMatch(studNum, @"[0-9]"))
        {
            if (studNum.Length is < 10 or > 11)
            {
                throw new OverflowException("Student Number should be 10 or 11 digits!");
            }

            _studentNo = long.Parse(studNum);
        }
        else
        {
            throw new FormatException("Student Number should be a number!");
        }

        return _studentNo;
    }

    private long ContactNo(string contact)
    {
        if (Regex.IsMatch(contact, @"[0-9]"))
        {
            if (contact.Length is < 10 or > 11)
            {
                throw new OverflowException("Contact Number should be 10 or 11 digits!");
            }

            _contactNo = long.Parse(contact);
        }
        else
        {
            throw new FormatException("Contact Number should be a number!");
        }

        return _contactNo;
    }

    private string FullName(string lastName, string firstName, string middleInitial)
    {
        if (Regex.IsMatch(lastName, @"^[a-zA-Z]+$") || Regex.IsMatch(firstName, @"^[a-zA-Z]+$") ||
            Regex.IsMatch(middleInitial, @"^[a-zA-Z]+$"))
        {
            _fullName = middleInitial != string.Empty
                ? lastName + ", " + firstName + ", " + middleInitial
                : lastName + ", " + firstName;
        }
        else
        {
            throw new FormatException("Name should be a string!");
        }

        return _fullName;
    }

    private byte Age(string age)
    {
        if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
        {
            _age = byte.Parse(age);
        }
        else if (age == string.Empty)
        {
            throw new ArgumentNullException(nameof(age), "Age should not be empty!");
        }
        else
        {
            throw new FormatException("Age should be a number!");
        }

        return _age;
    }

    public static class StudentInformationClass
    {
        public static long SetStudNo { get; set; }
        public static long SetContactNo { get; set; }
        public static byte SetAge { get; set; }
        public static string SetProgram { get; set; } = string.Empty;
        public static string SetGender { get; set; } = string.Empty;
        public static string SetBirthDay { get; set; } = string.Empty;
        public static string SetFullName { get; set; } = string.Empty;
    }

    private void OnRegister(object sender, RoutedEventArgs e)
    {
        try
        {
            StudentInformationClass.SetStudNo = StudentNumber(TxtStudentNo.Text);
            StudentInformationClass.SetProgram = CbPrograms.Text;
            if (StudentInformationClass.SetProgram == string.Empty)
            {
                throw new IndexOutOfRangeException("Program should not be empty!");
            }

            StudentInformationClass.SetFullName = FullName(TxtLastName.Text, TxtFirstName.Text, TxtMiddleInitial.Text);
            StudentInformationClass.SetAge = Age(TxtAge.Text);
            StudentInformationClass.SetGender = CbGender.Text;
            if (StudentInformationClass.SetGender == string.Empty)
            {
                throw new IndexOutOfRangeException("Gender should not be empty!");
            }

            if (DatePickerBirthday.SelectedDate == null)
            {
                throw new ArgumentNullException(nameof(DatePickerBirthday.SelectedDate),
                    "Birthday should not be empty!");
            }

            StudentInformationClass.SetBirthDay = DatePickerBirthday.SelectedDate.Value.ToString("yyyy-M-d dd");
            StudentInformationClass.SetContactNo = ContactNo(TxtContactNo.Text);
            var student = new Student
            {
                StudentNumber = StudentInformationClass.SetStudNo,
                FullName = StudentInformationClass.SetFullName,
                Program = StudentInformationClass.SetProgram,
                Gender = StudentInformationClass.SetGender,
                Age = StudentInformationClass.SetAge,
                BirthDay = StudentInformationClass.SetBirthDay,
                ContactNumber = StudentInformationClass.SetContactNo
            };
            var fileInfo = new FileInfo
            {
                FileContent = student.ToString(),
                FileName = student.StudentNumber + ".txt"
            };

            using var streamWriter =
                new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    fileInfo.FileName));
            streamWriter.WriteLine(fileInfo.FileContent);
            Console.WriteLine(fileInfo.FileContent);
        }
        catch (FormatException formatException)
        {
            MessageBox.Show(formatException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (ArgumentNullException argumentNullException)
        {
            MessageBox.Show(argumentNullException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (OverflowException overflowException)
        {
            MessageBox.Show(overflowException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (IndexOutOfRangeException outOfRangeException)
        {
            MessageBox.Show(outOfRangeException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void FormRegistration_OnClosing(object? sender, CancelEventArgs e)
    {
        Environment.Exit(0);
        Application.Current.Shutdown(0);
    }

    private void OpenRecords(object sender, RoutedEventArgs e)
    {
        if (!_frmStudentRecord.IsVisible)
        {
            _frmStudentRecord = new FrmStudentRecord();
        }
        Hide();
        _frmStudentRecord.ShowDialog();
        if (_frmStudentRecord.DialogResult == true)
        {
            Show();
        }
    }
}