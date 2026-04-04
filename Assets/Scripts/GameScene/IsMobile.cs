using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class IsMobile : MonoBehaviour
{
    [SerializeField] private GameObject[] Stick = new GameObject[2];
    [SerializeField] private GameObject verticalText;
    [SerializeField] private Toggle toggle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bool isMobile = Application.isMobilePlatform;
        SwitchUI(isMobile);
        toggle.isOn = isMobile;
    }
    void Update()
    {
        if(toggle.isOn)
        {
            SwitchUI(true);
        }
        else
        {
            SwitchUI(false);
        }
    }
    void SwitchUI(bool isMobile)
    {
        if(isMobile)
        {
            foreach (GameObject stick in Stick)
            {
                stick.SetActive(true);
            }
            verticalText.transform.position = new Vector3(verticalText.transform.position.x, 170, verticalText.transform.position.z);
        }
        else
        {
            foreach (GameObject stick in Stick)
            {
                stick.SetActive(false);
            }
            verticalText.transform.position = new Vector3(verticalText.transform.position.x, 0, verticalText.transform.position.z);
        }
    }
}
