using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.ReactNative;
using Microsoft.ReactNative.Managed;

using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;

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
            Console.WriteLine(reactContext);
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
        [ReactMethod]
        public void extendTitleBar(bool status) {
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = status;
        }
    }
}
