using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace RegistrationAct;

public partial class FrmOpenFileText
{
    public FrmOpenFileText()
    {
        InitializeComponent();
    }

    private void OnCreateFile(object sender, RoutedEventArgs e)
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
            Console.WriteLine(content);
            TxtShowText.Items.Add(content);
        }
    }
}