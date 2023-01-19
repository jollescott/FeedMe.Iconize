﻿using System;
using Microsoft.Maui.Controls;

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconNavigationPage" /> page.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.NavigationPage" />
    public class IconNavigationPage : NavigationPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IconNavigationPage" /> class.
        /// </summary>
        public IconNavigationPage()
        {
            InitListeners();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IconNavigationPage" /> class.
        /// </summary>
        /// <param name="root">The root page.</param>
        public IconNavigationPage(Page root)
            : base(root)
        {
            InitListeners();
        }

        /// <summary>
        /// Initializes the event listeners.
        /// </summary>
        private void InitListeners()
        {
            Popped += OnNavigation;
            PoppedToRoot += OnNavigation;
            Pushed += OnNavigation;
        }

        /// <summary>
        /// Called when [navigation].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NavigationEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void OnNavigation(Object sender, NavigationEventArgs e)
        {
            MessagingCenter.Send(sender, IconToolbarItem.UpdateToolbarItemsMessage);
        }
    }
}
