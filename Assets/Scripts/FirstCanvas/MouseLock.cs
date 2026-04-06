using UnityEngine;

public class MouseLock : MonoBehaviour
{
    // ToDo: WebGLにおいてマウスロックがボタンを押した後に一度クリックが必要になっている問題を修正する
    public void OnButtonClicked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}