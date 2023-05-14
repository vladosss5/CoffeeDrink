﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CoffeeDrink4.ViewModels;

namespace CoffeeDrink4.Views;

public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainVM();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}