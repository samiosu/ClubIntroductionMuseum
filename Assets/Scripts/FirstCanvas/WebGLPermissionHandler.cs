using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class WebGLPermissionHandler : MonoBehaviour
{
    // JSの関数をインポート
    [DllImport("__Internal")]
    private static extern void RequestGyroPermission();
    // UIのButtonのOnClickからこれを呼ぶ
    public void OnStartButtonClick()
    {
        // 1. ブラウザへの許可申請（iOS対策）
        #if !UNITY_EDITOR && UNITY_WEBGL
            RequestGyroPermission();
        #endif

        // 2. Input System側のセンサー有効化
        var sensor = AttitudeSensor.current;
        if (sensor != null && !sensor.enabled)
        {
            InputSystem.EnableDevice(sensor);
            Debug.Log("Attitude Sensor has been ENABLED!"); 
            // これで、有効化した瞬間の一回だけログが出ます
        }
    }
}