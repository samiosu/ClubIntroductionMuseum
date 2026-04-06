using TMPro;
using UnityEngine;

public class SwitchCanvas : MonoBehaviour
{
    [SerializeField] private GameObject canvasFirst;
    [SerializeField] private GameObject canvasVertical;
    [SerializeField] private GameObject canvasHorizontal;
    [SerializeField] private GameObject canvasConfig;
    [SerializeField] private GameObject cameraFirst;
    [SerializeField] private GameObject cameraMain;
    [SerializeField] private TMP_Dropdown dropdown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasFirst.SetActive(true);
        canvasVertical.SetActive(false);
        canvasHorizontal.SetActive(false);
        canvasConfig.SetActive(false);
        cameraFirst.SetActive(true);
        cameraMain.SetActive(false);
    }
    void Update()
    {
        if(!canvasController.isFirstCanvas)
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

}
