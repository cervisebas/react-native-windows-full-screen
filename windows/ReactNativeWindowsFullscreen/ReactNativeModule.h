#pragma once

#include "JSValue.h"
#include "NativeModules.h"

using namespace winrt;
using namespace Microsoft::ReactNative;
using namespace Windows::UI::ViewManagement;

namespace winrt::ReactNativeWindowsFullscreen
{

REACT_MODULE(ReactNativeModule, L"ReactNativeWindowsFullscreen")
struct ReactNativeModule
{
    // See https://microsoft.github.io/react-native-windows/docs/native-modules for details on writing native modules

    REACT_INIT(Initialize)
    void Initialize(ReactContext const &reactContext) noexcept
    {
        m_reactContext = reactContext;
    }
    
    REACT_METHOD(sampleMethod)
    void sampleMethod(std::string stringArgument, int numberArgument, std::function<void(std::string)> &&callback) noexcept
    {
        // TODO: Implement some actually useful functionality
        callback("Received numberArgument: " + std::to_string(numberArgument) + " stringArgument: " + stringArgument);
    }

    REACT_METHOD(enterFullscreen)
    void enterFullscreen() noexcept
    {
        auto view = ApplicationView::GetForCurrentView();
        if (view->IsFullScrenMode)
        {
            if (view->TryEnterFullScreenMode())
            {
                view->FullScreenSystemOverlayMode = FullScreenSystemOverlayMode::Minimal;
            }
        }
    }

    REACT_METHOD(exitFullscreen)
    void exitFullscreen() noexcept
    {
        auto view = ApplicationView::GetForCurrentView();
        view->ExitFullScreenMode();
        view->FullScreenSystemOverlayMode = FullScreenSystemOverlayMode::Standard;
    }

    REACT_METHOD(isActive)
    void isActive(std::function<void(bool)> &&callback) noexcept
    {
        auto view = ApplicationView::GetForCurrentView();
        callback(view->IsFullScrenMode);
    }

    private:
        ReactContext m_reactContext{nullptr};
};

} // namespace winrt::ReactNativeWindowsFullscreen
