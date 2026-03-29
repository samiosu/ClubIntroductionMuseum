using UnityEngine.SceneManagement;
using UnityEngine;

public class GoGameScene : MonoBehaviour
{
    public void GoGameSceneMethod()
    {
        SceneManager.LoadScene("GameScene");
    }
}