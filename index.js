// main index.js

import { NativeModules } from 'react-native';

const { ReactNativeWindowsFullScreen } = NativeModules;


function enterFullScreen() {
    ReactNativeWindowsFullScreen.enterFullScreen();
}
function exitFullScreen() {
    ReactNativeWindowsFullScreen.exitFullScreen();
}
function isActive() {
    return new Promise((resolve)=>ReactNativeWindowsFullScreen.isActive(resolve));
}

export {
    enterFullScreen,
    exitFullScreen,
    isActive
};
