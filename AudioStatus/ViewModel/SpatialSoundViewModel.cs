
using AudioStatus.Model;
using Windows.UI.Xaml;

namespace AudioStatus.ViewModel
{
    public class SpatialSoundViewModel : SpatialSound
    {
        public double DolbyAtmosForHomeTheaterOpacity
        {
            get
            {
                return IsDolbyAtmosForHomeTheater ? 1 : 0.5;
            }
        }
        public double DolbyAtmosForHeadphonesOpacity
        {
            get
            {
                return IsDolbyAtmosForHeadphones ? 1 : 0.5;
            }
        }   
        public Visibility SetupButtonVisibility
        {
            get
            {
                return IsReadyToUse ? Visibility.Collapsed : Visibility.Visible;
            }
        }
        public Visibility ReadyToUseVisibility
        {
            get 
            {
                return IsReadyToUse ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        public Visibility HeadphoneTextVisibility
        {
            get
            {
                return IsDolbyAtmosForHeadphones ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        public Visibility SpeakerTextVisibility
        {
            get
            {
                return IsDolbyAtmosForHomeTheater ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
}