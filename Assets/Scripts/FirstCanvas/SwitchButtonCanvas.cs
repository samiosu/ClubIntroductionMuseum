using TMPro;
using UnityEngine;

public class SwitchButtonCanvas : MonoBehaviour
{
    [SerializeField] private GameObject canvasFirst;
    [SerializeField] private GameObject canvasVertical;
    [SerializeField] private GameObject canvasHorizontal;
    [SerializeField] private GameObject canvasConfig;
    [SerializeField] private GameObject cameraFirst;
    [SerializeField] private GameObject cameraMain;
    [SerializeField] private TMP_Dropdown dropdown;
    public void OnButtonClick()
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
        canvasFirst.SetActive(false);
        cameraFirst.SetActive(false);
        cameraMain.SetActive(true);
        canvasController.isFirstCanvas = false;
        Debug.Log("Switching to GameScene Canvas");
    }
}
