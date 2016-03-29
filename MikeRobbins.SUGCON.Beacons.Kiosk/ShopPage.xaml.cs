﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MikeRobbins.SUGCON.Beacons.Kiosk.Data;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MikeRobbins.SUGCON.Beacons.Kiosk
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShopPage : Page
    {
        public ShopPage()
        {
            this.InitializeComponent();

            LoadVisitedAnimals();
        }

        public async void LoadVisitedAnimals()
        {
            var sitecoreApi = new SitecoreApi();

            var authCookie = await  sitecoreApi.Authenticate();

            var results = await sitecoreApi.GetUserDetails(authCookie, "test@test.com");
        }
    }
}
