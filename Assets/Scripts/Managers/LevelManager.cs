using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private Vector3 playerStartPosition;
    private GameObject player;

    void Awake()
    {
        Instance = this;
        player = GameObject.FindWithTag("Player");
        playerStartPosition = player.transform.position;
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel(string sceneName)
    {
        UnityEngine.Debug.Log("Loading scene: " + sceneName);
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetLevel();
        }
    }
}