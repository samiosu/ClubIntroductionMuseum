mergeInto(LibraryManager.library, {
    RequestGyroPermission: function () {
        if (typeof DeviceOrientationEvent !== 'undefined' && typeof DeviceOrientationEvent.requestPermission === 'function') {
            DeviceOrientationEvent.requestPermission()
                .then(permissionState => {
                    if (permissionState === 'granted') {
                        console.log("Gyroscope permission granted.");
                    }
                })
                .catch(console.error);
        } else {
            // iOS以外（Androidなど）は許可ダイアログ不要
            console.log("Gyroscope permission not required or not supported.");
        }
    }
});