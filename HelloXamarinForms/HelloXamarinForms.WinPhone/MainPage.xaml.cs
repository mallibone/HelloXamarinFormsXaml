using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace HelloXamarinForms.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new HelloXamarinForms.App());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            const string helloParameter = "helloParemeter";
            const string secondParameter = "secondParameter";

            if (NavigationContext.QueryString.ContainsKey(helloParameter) && NavigationContext.QueryString.ContainsKey(secondParameter))
            {
                var message = string.Format("Received toast with HelloParameter {0} and SecondParemter {1}",
                    NavigationContext.QueryString[helloParameter], NavigationContext.QueryString[secondParameter]);
                MessageBox.Show(message);

            }
        }

    }
}
