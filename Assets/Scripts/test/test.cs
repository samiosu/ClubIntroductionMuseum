using UnityEngine;
using TMPro;

public class test : MonoBehaviour
{
    public void Start()
    {
        TextMeshProUGUI TMP = GetComponent<TextMeshProUGUI>();
        if (Application.isMobilePlatform)
        {
            TMP.text = "スマホでアクセスしています";
        }
        else
        {
            TMP.text = "PCでアクセスしています";
        }
    }
}