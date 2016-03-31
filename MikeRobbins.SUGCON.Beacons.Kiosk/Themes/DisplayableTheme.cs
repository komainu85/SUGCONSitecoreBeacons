using Windows.UI.Xaml;
using Intense.Presentation;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Themes
{
    /// <summary>
    /// Represents a displayable theme.
    /// </summary>
    public class DisplayableTheme : Displayable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayableTheme"/>.
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="theme"></param>
        public DisplayableTheme(string displayName, ApplicationTheme theme)
        {
            DisplayName = displayName;
            Theme = theme;
        }

        /// <summary>
        /// Gets the them.
        /// </summary>
        public ApplicationTheme Theme { get; }
    }
}
