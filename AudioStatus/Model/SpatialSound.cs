using Windows.Media.Audio;
using Windows.Media.Devices;
using System.ComponentModel;

namespace AudioStatus.Model
{
    public abstract class SpatialSound : INotifyPropertyChanged
    {
        #region Variables
        private SpatialAudioDeviceConfiguration deviceConfiguration;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion //Variables

        #region Protected Properties
        protected bool IsDolbyAtmosForHeadphones => deviceConfiguration.DefaultSpatialAudioFormat == SpatialAudioFormatSubtype.DolbyAtmosForHeadphones;
        protected bool IsDolbyAtmosForHomeTheater => deviceConfiguration.DefaultSpatialAudioFormat == SpatialAudioFormatSubtype.DolbyAtmosForHomeTheater;
        protected bool IsReadyToUse => IsDolbyAtmosForHeadphones || IsDolbyAtmosForHomeTheater;
        #endregion //Protected Properties

        #region Ctors
        protected SpatialSound()
        {
            MediaDevice.DefaultAudioRenderDeviceChanged += MediaDevice_DefaultAudioRenderDeviceChanged;
            SetDeviceConfiguration(MediaDevice.GetDefaultAudioRenderId(AudioDeviceRole.Default));
        }
        #endregion //Ctors

        #region Private Methods
        private void SetDeviceConfiguration(string deviceId)
        {
            if (deviceConfiguration != null)
                deviceConfiguration.ConfigurationChanged -= DeviceConfiguration_ConfigurationChanged;
            deviceConfiguration = SpatialAudioDeviceConfiguration.GetForDeviceId(deviceId);
            deviceConfiguration.ConfigurationChanged += DeviceConfiguration_ConfigurationChanged;
        }
        private void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }
        #endregion //Private Methods

        #region Events
        private void MediaDevice_DefaultAudioRenderDeviceChanged(object sender, DefaultAudioRenderDeviceChangedEventArgs args)
        {
            SetDeviceConfiguration(args.Id);
            OnPropertyChanged();
        }
        private void DeviceConfiguration_ConfigurationChanged(SpatialAudioDeviceConfiguration sender, object args)
        {
            OnPropertyChanged();
        }
        #endregion //Events
    }
}