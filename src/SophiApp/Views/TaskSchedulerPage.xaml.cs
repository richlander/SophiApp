﻿// <copyright file="TaskSchedulerPage.xaml.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Views;

using Microsoft.UI.Xaml.Controls;
using SophiApp.Extensions;
using SophiApp.Helpers;
using SophiApp.Models;
using SophiApp.ViewModels;

/// <summary>
/// Implements the <see cref="TaskSchedulerPage"/> class.
/// </summary>
public sealed partial class TaskSchedulerPage : Page
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TaskSchedulerPage"/> class.
    /// </summary>
    public TaskSchedulerPage()
    {
        InitializeComponent();
        ViewModel = App.GetService<ShellViewModel>();
        Models = ViewModel.JsonModels.FilterByTag(UICategoryTag.TaskScheduler);
    }

    /// <summary>
    /// Gets view model for task scheduler page.
    /// </summary>
    public ShellViewModel ViewModel { get; }

    /// <summary>
    /// Gets <see cref="UIModel"/> collection.
    /// </summary>
    public List<UIModel> Models { get; }
}
