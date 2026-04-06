using UnityEngine;
using UnityEngine.InputSystem;
using System.Runtime.InteropServices;

public class CameraController : MonoBehaviour
{

    // JSの関数をインポート
    [DllImport("__Internal")]
    private static extern void RequestGyroPermission();
    private float sensitivity = 0.1f;
    private float moveSpeed = 250f;
    private InputSystem_Actions inputActions;
    private Rigidbody rb;
    private Vector2 moveVector;
    private bool isPressedAlt = false;

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
    void OnDestroy()
    {
        inputActions.Player.Look.performed -= OnLook;
        inputActions.Player.Look.canceled -= OnLook;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Disable();
    }
    // Moveアクションに紐づけたメソッド
    void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
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
    void OnCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPressedAlt = true;
    }
    void RemoveCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPressedAlt = false;
    }
    void Update()
    {
        // 移動処理
        Vector3 moveDirection = transform.forward * moveVector.y + transform.right * moveVector.x;
        Vector3 movePerSecond = new Vector3(moveDirection.x, 0, moveDirection.z) * moveSpeed * Time.deltaTime;
        rb.linearVelocity = new Vector3(movePerSecond.x, rb.linearVelocity.y, movePerSecond.z);
    }
    public void EnableInputSystem()
    {
        inputActions.Enable();
    }
    public void DisableInputSystem()
    {
        inputActions.Disable();
    }
}