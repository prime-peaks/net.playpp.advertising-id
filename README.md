# Play Advertising ID Client Wrapper for Unity

This wrapper is for the [Play Advertising ID Client](https://developers.google.com/android/reference/com/google/android/gms/ads/identifier/AdvertisingIdClient). It provides a C# API for accessing advertising ID and related information from a Unity app running on Android.

## Usage

Add this repository URL to the Unity Package Manager.

```csharp
var advertisingIdClient = new AdvertisingIdClient();
var advertisingIdTask = advertisingIdClient.GetAdvertisingIdInfoAsync();
await advertisingIdTask.ContinueWith(task => {
    if (!task.IsCompletedSuccessfully) return;
    var details = task.Result;
    Debug.Log($"Advertising ID: {details.Id}");
    Debug.Log($"Is Limit Ad Tracking Enabled: {details.IsLimitAdTrackingEnabled}");
});
```

## How to Modify This Package

These instructions are for macOS. Additional research is required for other platforms.

### Steps

1. Check out the package from the remote repository. For convenience, use the package name as the folder name.
2. Open Terminal.
3. Change the current working directory to the `Packages` folder in the Unity project where you've used this package.
```
cd /path/to/UnityProject/Packages
```
4. Create a symbolic link to the package folder.
```
ln -s /path/to/net.playpp.advertising-id .
```
5. Open the Unity project to allow Unity to recognize the changes.
6. Modify the package and test it in the Unity project.
7. Commit and push the changes to the remote repository.
8. Remove the symbolic link.
```
rm net.playpp.advertising-id
```
9. Open the Unity project again so Unity can recognize the changes.
10. Commit the updated `packages-lock.json` in the Unity project.
