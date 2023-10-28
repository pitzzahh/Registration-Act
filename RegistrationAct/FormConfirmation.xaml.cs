using System.Windows;

namespace RegistrationAct;

public partial class FormConfirmation
{
    public FormConfirmation()
    {
        InitializeComponent();
    }

    private void OnSubmit(object sender, RoutedEventArgs e)
    {
    }

    private void FormConfirmation_OnLoaded(object sender, RoutedEventArgs e)
    {
        LblStudentNo.Text = FormRegistration.StudentInformationClass.SetStudNo.ToString();
        LblName.Text = FormRegistration.StudentInformationClass.SetFullName;
        LblProgram.Text = FormRegistration.StudentInformationClass.SetProgram;
        LblBirthDay.Text = FormRegistration.StudentInformationClass.SetBirthDay;
        LblGender.Text = FormRegistration.StudentInformationClass.SetGender;
        LblContactNo.Text = FormRegistration.StudentInformationClass.SetContactNo.ToString();
        LblAge.Text = FormRegistration.StudentInformationClass.SetAge.ToString();
    }
}