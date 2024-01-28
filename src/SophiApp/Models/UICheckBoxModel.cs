﻿// <copyright file="UICheckBoxModel.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Models
{
    /// <inheritdoc/>
    public class UICheckBoxModel : UIModel
    {
        private readonly Func<bool> accessor;
        private readonly Action<bool> mutator;
        private bool isChecked;

        /// <summary>
        /// Initializes a new instance of the <see cref="UICheckBoxModel"/> class.
        /// </summary>
        /// <param name="dto">Dto for <see cref="UICheckBoxModel"/> initialization.</param>
        /// <param name="title">Model title.</param>
        /// <param name="description">Model description.</param>
        /// <param name="accessor">Method that sets the IsEnabled state.</param>
        /// <param name="mutator">Method that changes OS settings.</param>
        public UICheckBoxModel(UIModelDto dto, string title, string description, Func<bool> accessor, Action<bool> mutator)
            : base(dto, title)
        {
            this.accessor = accessor;
            this.mutator = mutator;
            Description = description;
        }

        /// <summary>
        /// Gets model description.
        /// </summary>
        public string Description { get; init; }

        /// <summary>
        /// Gets a value indicating whether model checked state.
        /// </summary>
        public bool IsChecked
        {
            get => isChecked;
            private set
            {
                isChecked = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc/>
        public override void GetState()
        {
            try
            {
                IsChecked = accessor.Invoke();
                App.Logger.LogModelState(Name, IsChecked);

                // TODO: For debug only!
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                IsEnabled = false;
                App.Logger.LogModelGetStateException(Name, ex);
            }
        }
    }
}
