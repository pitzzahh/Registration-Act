using System.Text.RegularExpressions;
using System.Windows;

namespace RegistrationAct;

/// <summary>
/// Interaction logic for OrganizationProfile.xaml
/// </summary>
public partial class OrganizationProfile
{
    private long _studentNo;
    private long _contactNo;
    private int _age;
    private string _fullName = null!;

    public OrganizationProfile()
    {
        InitializeComponent();
    }

    private void OrganizationProfile_OnLoaded(object sender, RoutedEventArgs e)
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
    }

    public long StudentNumber(string studNum)
    {
        _studentNo = long.Parse(studNum);

        return _studentNo;
    }

    public long ContactNo(string contact)
    {
        if (Regex.IsMatch(contact, @"^[0-9]{10,11}$"))
        {
            _contactNo = long.Parse(contact);
        }

        return _contactNo;
    }

    public string FullName(string lastName, string firstName, string middleInitial)
    {
        if (Regex.IsMatch(lastName, @"^[a-zA-Z]+$") || Regex.IsMatch(firstName, @"^[a-zA-Z]+$") ||
            Regex.IsMatch(middleInitial, @"^[a-zA-Z]+$"))
        {
            _fullName = lastName + ", " + firstName + ", " + middleInitial;
        }

        return _fullName;
    }

    public int Age(string age)
    {
        if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
        {
            _age = int.Parse(age);
        }

        return _age;
    }

    public class StudentInformationClass
    {
        public static int SetStudNo { get; } = 0;
        public static int ContactNumber { get; } = 0;
        public static string SetProgram { get; } = string.Empty;
        public static string SetBirthDay { get; } = string.Empty;
        public static string SetFullName { get; } = string.Empty;
    }

}