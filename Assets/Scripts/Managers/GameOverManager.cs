using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class GameOverManager : MonoBehaviour
{
    public static int lastPlayedLevel = 2;

    public void TryAgain()
    {
        SceneManager.LoadScene(lastPlayedLevel);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}