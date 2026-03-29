using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class WebGLPermissionHandler : MonoBehaviour
{
    // JSの関数をインポート
    [DllImport("__Internal")]
    private static extern void RequestGyroPermission();
    [SerializeField] private GoGameScene goGameScene; // ゲーム開始の処理を持つクラスへの参照

    // UIのButtonのOnClickからこれを呼ぶ
    public void OnStartButtonClick()
    {
        // 1. ブラウザへの許可申請（iOS対策）
        #if !UNITY_EDITOR && UNITY_WEBGL
            RequestGyroPermission();
        #endif

        // 2. Input System側のセンサー有効化
        InputSurveillance.AttitudeSensorEnable();

        // 3. ゲーム開始（例：タイトル画面を消すなど）
        goGameScene.GoGameSceneMethod();
    }
}