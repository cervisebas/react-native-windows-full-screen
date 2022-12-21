using System;
using Microsoft.ReactNative.Managed;
using Windows.UI.ViewManagement;

namespace ReactNativeWindowsFullScreen
{
    [ReactModule("ReactNativeWindowsFullScreen")]
    internal sealed class ReactNativeModule
    {
        // See https://microsoft.github.io/react-native-windows/docs/native-modules for details on writing native modules

        private ReactContext _reactContext;

        [ReactInitializer]
        public void Initialize(ReactContext reactContext) {
            _reactContext = reactContext;
        }
        [ReactMethod]
        public void enterFullScreen() {
            var view = ApplicationView.GetForCurrentView();
            if (!view.IsFullScreenMode) view.TryEnterFullScreenMode();
        }
        [ReactMethod]
        public void exitFullScreen() {
            var view = ApplicationView.GetForCurrentView();
            if (view.IsFullScreenMode) view.ExitFullScreenMode();
        }
        [ReactMethod]
        public void isActive(Action<bool> callback) {
            var view = ApplicationView.GetForCurrentView();
            callback(!!view.IsFullScreenMode);
        }
    }
}
