using System;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml;
using Intense.Presentation;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.ViewModels
{
    public class ShellViewModel : NotifyPropertyChanged
    {
        private readonly NavigationItemCollection _topItems = new NavigationItemCollection();
        private NavigationItem _selectedTopItem;
        private readonly NavigationItemCollection _bottomItems = new NavigationItemCollection();
        private NavigationItem _selectedBottomItem;
        private bool _isSplitViewPaneOpen;

        public ShellViewModel()
        {
            ToggleSplitViewPaneCommand = new RelayCommand(() => IsSplitViewPaneOpen = !IsSplitViewPaneOpen);

            // open splitview pane in wide state
            IsSplitViewPaneOpen = IsWideState();
        }

        public ICommand ToggleSplitViewPaneCommand { get; private set; }

        public bool IsSplitViewPaneOpen
        {
            get { return _isSplitViewPaneOpen; }
            set { Set(ref _isSplitViewPaneOpen, value); }
        }

        public NavigationItem SelectedTopItem
        {
            get { return _selectedTopItem; }
            set
            {
                if (Set(ref _selectedTopItem, value) && value != null)
                {
                    OnSelectedItemChanged(true);
                }
            }
        }

        public NavigationItem SelectedBottomItem
        {
            get { return _selectedBottomItem; }
            set
            {
                if (Set(ref _selectedBottomItem, value) && value != null)
                {
                    OnSelectedItemChanged(false);
                }
            }
        }

        public NavigationItem SelectedItem
        {
            get { return _selectedTopItem ?? _selectedBottomItem; }
            set
            {
                SelectedTopItem = _topItems.FirstOrDefault(m => m == value);
                SelectedBottomItem = _bottomItems.FirstOrDefault(m => m == value);
            }
        }

        public Type SelectedPageType
        {
            get
            {
                return SelectedItem?.PageType;
            }
            set
            {
                // select associated menu item
                SelectedTopItem = _topItems.FirstOrDefault(m => m.PageType == value);
                SelectedBottomItem = _bottomItems.FirstOrDefault(m => m.PageType == value);
            }
        }

        public NavigationItemCollection TopItems
        {
            get { return _topItems; }
        }

        public NavigationItemCollection BottomItems
        {
            get { return _bottomItems; }
        }

        private void OnSelectedItemChanged(bool top)
        {
            if (top)
            {
                SelectedBottomItem = null;
            }
            else
            {
                SelectedTopItem = null;
            }
            OnPropertyChanged("SelectedItem");
            OnPropertyChanged("SelectedPageType");

            // auto-close split view pane (only when not in widestate)
            if (!IsWideState())
            {
                IsSplitViewPaneOpen = false;
            }
        }

        // a helper determining whether we are in a wide window state
        // mvvm purists probably don't appreciate this approach
        private bool IsWideState()
        {
            return Window.Current.Bounds.Width >= 1024;
        }
    }
}
