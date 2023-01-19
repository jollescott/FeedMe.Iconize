﻿using System;
using System.ComponentModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconToolbarItem" /> control.
    /// </summary>
    /// <seealso cref="ToolbarItem" />
    public class IconToolbarItem : ToolbarItem
    {
        /// <summary>
        /// The update toolbar items message
        /// </summary>
        public const String UpdateToolbarItemsMessage = "Iconize.UpdateToolbarItems";

        /// <summary>
        /// Backing store for the <see cref="IconColor" /> property.
        /// </summary>
        public static BindableProperty IconColorProperty = BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(IconToolbarItem));

        /// <summary>
        /// Backing store for the <see cref="IsVisible" /> property.
        /// </summary>
        public static BindableProperty IsVisibleProperty = BindableProperty.Create(nameof(IsVisible), typeof(Boolean), typeof(IconToolbarItem), true);

        public static BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(String), typeof(IconToolbarItem), String.Empty);
        
        /// <summary>
        /// Gets or sets the color of the icon.
        /// </summary>
        /// <value>
        /// The color of the icon.
        /// </value>
        public Color IconColor
        {
            get => (Color)GetValue(IconColorProperty);
            set => SetValue(IconColorProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this toolbar item is visible.
        /// </summary>
        /// <value>
        /// <c>true</c> if this toolbar item is visible; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsVisible
        {
            get => (Boolean)GetValue(IsVisibleProperty);
            set => SetValue(IsVisibleProperty, value);
        }

        public new String IconImageSource
        {
            get => (String)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IconToolbarItem" /> class.
        /// </summary>
        public IconToolbarItem()
        {
            PropertyChanged += OnPropertyChanged;
        }

        /// <summary>
        /// Called when [can execute changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnCanExecuteChanged(object sender, EventArgs e)
        {
            MessagingCenter.Send(sender, UpdateToolbarItemsMessage);
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void OnPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            MessagingCenter.Send(sender, UpdateToolbarItemsMessage);

            if (e.PropertyName == nameof(Command) && Command != null)
            {
                Command.CanExecuteChanged += OnCanExecuteChanged;
            }
        }
    }
}