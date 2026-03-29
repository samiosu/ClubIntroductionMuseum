using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private float sensitivity = 0.1f;
    private InputSystem_Actions inputActions; 

    void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
        inputActions.Player.Look.performed += OnLook;
        inputActions.Player.Look.canceled += OnLook;
    }
    // Lookアクションに紐づけたメソッド
    void OnLook(InputAction.CallbackContext context)
    {
        // 1. 入力データがどの型かチェックして処理を分ける
        object rawValue = context.ReadValueAsObject();

        if (rawValue is Quaternion attitude)
        {
            // AttitudSensorの処理
            Quaternion correction = Quaternion.Euler(90f, 0f, 180f);
            Quaternion flippedAttitude = new Quaternion(-attitude.x, -attitude.y, attitude.z, attitude.w);
            transform.localRotation = correction * flippedAttitude;
        }
        else if (rawValue is Vector2 delta)
        {
            // マウス(Delta)の処理
            float rotX = delta.y * sensitivity;
            float rotY = delta.x * sensitivity;
            transform.Rotate(Vector3.up, rotY, Space.World);
            transform.Rotate(Vector3.left, rotX, Space.Self);
        }
    }
    void Update()
    {
        InputSurveillance.AttitudeSensorEnable();
    }
}