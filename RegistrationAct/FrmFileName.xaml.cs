using System.Windows;

namespace RegistrationAct;

public partial class FrmFileName
{
    public FrmFileName()
    {
        InitializeComponent();
    }

    private void OnChooseFileName(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}