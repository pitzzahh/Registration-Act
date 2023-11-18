using System;
using System.IO;
using System.Windows;

namespace RegistrationAct;

public partial class FrmLab1
{
    public FrmLab1()
    {
        InitializeComponent();
    }

    private void OnCreateFile(object sender, RoutedEventArgs e)
    {

        if (string.IsNullOrEmpty(TxtInput.Text))
        {
            MessageBox.Show("Please enter some text", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        FrmFileName frmFileName = new();
        var showDialog = frmFileName.ShowDialog();
        if (showDialog != true) return;
        if (string.IsNullOrEmpty(frmFileName.TxtFileName.Text))
        {
            MessageBox.Show("Please enter a file name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        var fileInfo = new FileInfo
        {
            FileContent = TxtInput.Text,
            FileName = frmFileName.TxtFileName.Text + ".txt"
        };
        
        // create to file using StreamWriter
        using var streamWriter = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileInfo.FileName));
        streamWriter.WriteLine(fileInfo.FileContent);
        Console.WriteLine(fileInfo.FileContent);
    }
}