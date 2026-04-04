using UnityEngine;

public class ManualButton : MonoBehaviour
{
    [SerializeField] private GameObject configCanvas;
    [SerializeField] private CameraController cameraController;
    public void OnButtonClick()
    {
        IsManual.isManual = !IsManual.isManual;
        if (IsManual.isManual)
        {
            configCanvas.SetActive(true);
            cameraController.DisableInputSystem();
        }
        else
        {
            configCanvas.SetActive(false);
            cameraController.EnableInputSystem();
        }
    }
}
