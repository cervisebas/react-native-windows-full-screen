declare module "react-native-windows-full-screen" {
    function enterFullScreen(): void;
    function exitFullScreen(): void;
    function isActive(): Promise<boolean>;
}