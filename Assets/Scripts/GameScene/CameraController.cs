using UnityEngine;
using UnityEngine.InputSystem;
using System.Runtime.InteropServices;

public class CameraController : MonoBehaviour
{

    // JSの関数をインポート
    [DllImport("__Internal")]
    private static extern void RequestGyroPermission();
    private float sensitivity = 0.1f;
    private float moveSpeed = 10000f;
    private InputSystem_Actions inputActions;
    private Rigidbody rb;
    private Vector3 movePerSecond;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
        inputActions.Player.Look.performed += OnLook;
        inputActions.Player.Look.canceled += OnLook;
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        rb = GetComponent<Rigidbody>();
    }
    // Moveアクションに紐づけたメソッド
    void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        Vector3 moveDirection = transform.forward * input.y + transform.right * input.x;
        movePerSecond = new Vector3(moveDirection.x, 0, moveDirection.z) * moveSpeed;
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
        rb.linearVelocity = new Vector3(movePerSecond.x, rb.linearVelocity.y, movePerSecond.z) * Time.deltaTime;
    }
}