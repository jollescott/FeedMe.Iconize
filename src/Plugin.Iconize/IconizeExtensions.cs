﻿using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace Plugin.Iconize
{
    /// <summary>
    /// Global extension methods for Iconize
    /// </summary>
    public static class IconizeExtensions
    {
        /// <summary>
        /// Adds the icon to the list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="key">The key.</param>
        /// <param name="character">The character.</param>
        public static void Add(this IList<IIcon> list, String key, Char character) => list.Add(new Icon(key, character));

        /// <summary>
        /// Gets the toolbar items.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public static IList<ToolbarItem> GetToolbarItems(this Page page)
        {
            var list = new List<ToolbarItem>(page.ToolbarItems);

            if (page is FlyoutPage masterDetailPage)
            {
                if (masterDetailPage.IsPresented && masterDetailPage.Flyout != null)
                {
                    list.AddRange(masterDetailPage.Flyout.GetToolbarItems());
                }
                else if (masterDetailPage.Detail != null)
                {
                    list.AddRange(masterDetailPage.Detail.GetToolbarItems());
                }
            }
            else if (page is IPageContainer<Page> pageContainer && pageContainer.CurrentPage != null)
            {
                list.AddRange(pageContainer.CurrentPage.GetToolbarItems());
            }

            return list;
        }
    }
}