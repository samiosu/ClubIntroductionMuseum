using TMPro;
using UnityEngine;

public class SwitchCanvas : MonoBehaviour
{
    [SerializeField] private GameObject canvasVertical;
    [SerializeField] private GameObject canvasHorizontal;
    [SerializeField] private TMP_Dropdown dropdown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Screen.width > Screen.height)
        {
            canvasVertical.SetActive(false);
            canvasHorizontal.SetActive(true);
            dropdown.value = 1;
        }
        else
        {
            canvasVertical.SetActive(true);
            canvasHorizontal.SetActive(false);
            dropdown.value = 0;
        }
    }
    void Update()
    {
        if(dropdown.value == 1)
        {
            canvasVertical.SetActive(false);
            canvasHorizontal.SetActive(true);
        }
        else
        {
            canvasVertical.SetActive(true);
            canvasHorizontal.SetActive(false);
        }
    }

}
