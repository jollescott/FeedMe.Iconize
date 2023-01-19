using System;
using System.ComponentModel;
using Android.Content;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Platform;
using Plugin.Iconize;
#if USE_FASTRENDERERS
using Microsoft.Maui.Controls.Compatibility.Platform.Android.FastRenderers;
#else
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

[assembly: ExportRenderer(typeof(IconLabel), typeof(IconLabelRenderer))]

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconLabel" /> renderer.
    /// </summary>
#if USE_FASTRENDERERS
    /// <seealso cref="Xamarin.Forms.Platform.Android.FastRenderers.LabelRenderer" />
#else
    /// <seealso cref="Xamarin.Forms.Platform.Android.LabelRenderer" />
#endif
    public class IconLabelRenderer : LabelRenderer
    {
        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        private IconLabel Label => Element as IconLabel;

        /// <summary>
        /// Initializes a new instance of the <see cref="IconLabelRenderer"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public IconLabelRenderer(Context context)
            : base(context)
        {
            // Intentionally left blank
        }

        /// <inheritdoc />
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Label is null)
                return;

            UpdateText();
        }

        /// <inheritdoc />
        protected override void OnElementPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Label is null)
                return;

            switch (e.PropertyName)
            {
                case nameof(IconLabel.FontSize):
                case nameof(IconLabel.TextColor):
                    UpdateText();
                    break;
            }
        }

        /// <inheritdoc />
        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

#if USE_FASTRENDERERS
            TextChanged += OnTextChanged;
#else
            if (!(Control is null))
            {
                Control.TextChanged += OnTextChanged;
            }
#endif
        }

        /// <inheritdoc />
        protected override void OnDetachedFromWindow()
        {
#if USE_FASTRENDERERS
            TextChanged -= OnTextChanged;
#else
            if (!(Control is null))
            {
                Control.TextChanged -= OnTextChanged;
            }
#endif

            base.OnDetachedFromWindow();
        }

        private void OnTextChanged(Object sender, Android.Text.TextChangedEventArgs e)
        {
            UpdateText();
        }

        private void UpdateText()
        {
#if USE_FASTRENDERERS
            TextChanged -= OnTextChanged;

            var icon = Iconize.FindIconForKey(Label.Text);
            if (!(icon is null))
            {
                Text = $"{icon.Character}";
                Typeface = Iconize.FindModuleOf(icon).ToTypeface(Context);
            }

            TextChanged += OnTextChanged;
#else
            if (!(Control is null))
            {
                Control.TextChanged -= OnTextChanged;

                var icon = Iconize.FindIconForKey(Label.Text);
                if (!(icon is null))
                {
                    Control.Text = $"{icon.Character}";
                    Control.Typeface = Iconize.FindModuleOf(icon).ToTypeface(Context);
                }

                Control.TextChanged += OnTextChanged;
            }
#endif
        }
    }
}