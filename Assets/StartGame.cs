using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartGamePress()
    {
        SceneManager.LoadScene("GameScene");
    }
}
