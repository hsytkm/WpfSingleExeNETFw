﻿using System.Windows;

namespace WpfOldCsproj.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        assembliesTextBlock.Text = Program.LoadedAssemblies.ToString();
    }
}
