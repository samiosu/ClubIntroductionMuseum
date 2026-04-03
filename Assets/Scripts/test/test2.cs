using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class test2 : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern int IsMobileDevice();

    public GameObject mobileUI; // ジャイロ許可ボタンなど
    public GameObject pcUI;     // キーボード操作説明など

    void Start()
    {
        bool isMobile = false;
        TextMeshProUGUI TMP = GetComponent<TextMeshProUGUI>();

        #if !UNITY_EDITOR && UNITY_WEBGL
            // JSからの戻り値が 1 ならモバイルと判断
            isMobile = (IsMobileDevice() == 1);
        #elif UNITY_EDITOR
            // エディタ上では開発用にどちらにするか手動で決めるか、
            // UnityRemoteを使っているならモバイル扱いにしてもOK
            isMobile = false; 
        #endif

        // UIの出し分け（バフ！）
        if (mobileUI != null) mobileUI.SetActive(isMobile);
        if (pcUI != null) pcUI.SetActive(!isMobile);
        
        TMP.text = "Is Mobile Platform: " + isMobile;
    }
}