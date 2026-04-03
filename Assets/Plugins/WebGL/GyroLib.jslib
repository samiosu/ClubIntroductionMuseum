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
    },
    // モバイル端末（iOS/Android）かどうかを判定して 0 か 1 を返す
    IsMobileDevice: function () {
        var ua = navigator.userAgent.toLowerCase();
        // 基本的なスマホ・タブレット判定
        var isMobile = /iphone|ipad|ipod|android/.test(ua);
        
        // iPad Proなどの「デスクトップ用サイトを表示」モード対策（タッチポイントがあるか）
        if (!isMobile && ua.indexOf("macintosh") !== -1 && navigator.maxTouchPoints > 0) {
            isMobile = true;
        }
        
        return isMobile ? 1 : 0;
    }
});