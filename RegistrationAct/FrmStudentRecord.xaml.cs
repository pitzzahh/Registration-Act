using System.ComponentModel;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace RegistrationAct;

public partial class FrmStudentRecord
{
    public FrmStudentRecord()
    {
        InitializeComponent();
    }

    private void OpenRegister(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
    
    private void OnFind(object sender, RoutedEventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            InitialDirectory = @"C:\",
            Title = "Browse Text Files",
            DefaultExt = "txt",
            Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
        };
        
        if (openFileDialog.ShowDialog() != true) return;

        var streamReader = File.OpenText(openFileDialog.FileName);
        while (streamReader.ReadLine() is { } content)
        {
            VListView.Items.Add(content);
        }
    }
    
    private void OnUpload(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Successfully Uploaded!");
        VListView.Items.Clear();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        DialogResult = true;
    }
}