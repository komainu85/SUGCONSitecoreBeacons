using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Intense.Presentation;
using Intense.UI;
using MikeRobbins.SUGCON.Beacons.Kiosk.Themes;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.ViewModels
{
    /// <summary>
    /// A sample settings view model.
    /// </summary>
    public class SettingsViewModel
        : NotifyPropertyChanged
    {
        private DisplayableTheme _selectedTheme;
        private SolidColorBrush _selectedBrush;
        private bool _useSystemAccentColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsViewModel"/>.
        /// </summary>
        public SettingsViewModel()
        {
            Brushes = AccentColors.Windows10.Select(c => new SolidColorBrush(c)).ToImmutableList();
            Themes = ImmutableList.Create(
                new DisplayableTheme("Dark", ApplicationTheme.Dark),
                new DisplayableTheme("Light", ApplicationTheme.Light));

            // ensure viewmodel state reflects actual appearance
            var manager = AppearanceManager.GetForCurrentView();
            _selectedTheme = Themes.FirstOrDefault(t => t.Theme == manager.Theme);

            if (AppearanceManager.AccentColor == null)
            {
                _useSystemAccentColor = true;
            }
            else
            {
                _selectedBrush = Brushes.FirstOrDefault(b => b.Color == AppearanceManager.AccentColor);
            }
        }

        /// <summary>
        /// Gets the brushes.
        /// </summary>
        public IReadOnlyList<SolidColorBrush> Brushes { get; }

        /// <summary>
        /// Gets or sets the selected brush.
        /// </summary>
        public SolidColorBrush SelectedBrush
        {
            get { return _selectedBrush; }
            set
            {
                if (Set(ref _selectedBrush, value) && !_useSystemAccentColor && value != null)
                {
                    AppearanceManager.AccentColor = value.Color;
                }
            }
        }

        /// <summary>
        /// Gets the collection of themes.
        /// </summary>
        public IReadOnlyList<DisplayableTheme> Themes { get; }
        /// <summary>
        /// Gets or sets the selected theme.
        /// </summary>
        public DisplayableTheme SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                if (Set(ref _selectedTheme, value) && value != null)
                {
                    AppearanceManager.GetForCurrentView().Theme = value.Theme;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use the system accent color.
        /// </summary>
        public bool UseSystemAccentColor
        {
            get { return _useSystemAccentColor; }
            set
            {
                if (Set(ref _useSystemAccentColor, value))
                {
                    if (value)
                    {
                        AppearanceManager.AccentColor = null;
                    }
                    else if (SelectedBrush != null) 
                    {
                        AppearanceManager.AccentColor = SelectedBrush.Color;
                    }
                }
            }
        }
    }
}
