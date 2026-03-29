using UnityEngine;
using UnityEngine.InputSystem;

public class InputSurveillance: MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject); // シーンを跨いで存在し続けるオブジェクトにする
    }
    public static void AttitudeSensorEnable()
    {
        var sensor = AttitudeSensor.current;
        
        // 1. センサーが存在し、かつ「まだ有効化（enabled）されていない」時だけ実行
        if (sensor != null && !sensor.enabled)
        {
            InputSystem.EnableDevice(sensor);
            Debug.Log("Attitude Sensor has been ENABLED!"); 
            // これで、有効化した瞬間の一回だけログが出ます
        }
    }
}