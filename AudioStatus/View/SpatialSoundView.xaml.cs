using AudioStatus.ViewModel;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using System;

namespace AudioStatus
{
    public sealed partial class MainPage : Page
    {
        #region Public Properties
        public SpatialSoundViewModel DefaulfViewModel { get; } = new SpatialSoundViewModel();
        #endregion //Public Properties

        #region Ctors
        public MainPage()
        {
            InitializeComponent();
            DefaulfViewModel.PropertyChanged += DefaulfViewModel_PropertyChanged;
            DataContext = DefaulfViewModel;
            Refresh();
        }
        #endregion //Ctors

        #region Private Methods
        private void Refresh()
        {
            DispatcherRunAsync(() => { btnSetup.Visibility = DefaulfViewModel.SetupButtonVisibility; });

            DispatcherRunAsync(() => { icnReadyToUse.Visibility = DefaulfViewModel.ReadyToUseVisibility; });
            DispatcherRunAsync(() => { txtReadyToUse.Visibility = DefaulfViewModel.ReadyToUseVisibility; });
            DispatcherRunAsync(() => { brdReadyToUse.Visibility = DefaulfViewModel.ReadyToUseVisibility; });

            DispatcherRunAsync(() => { txtHeadphone.Visibility = DefaulfViewModel.HeadphoneTextVisibility; });
            DispatcherRunAsync(() => { txtSpeaker.Visibility = DefaulfViewModel.SpeakerTextVisibility; });

            DispatcherRunAsync(() => { viewDolbyAtmosForHeadphones.Opacity = DefaulfViewModel.DolbyAtmosForHeadphonesOpacity; });
            DispatcherRunAsync(() => { viewDolbyAtmosForHomeTheater.Opacity = DefaulfViewModel.DolbyAtmosForHomeTheaterOpacity; });
        }
        private void DispatcherRunAsync(DispatchedHandler agileCallBack)
        {
            _ = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, agileCallBack);
        }
        #endregion //Private Methods

        #region Events
        private void DefaulfViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Refresh();
        }
        private void btnSetup_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            _ = Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:easeofaccess-audio")); ;
        }
        #endregion //Events
    }
}