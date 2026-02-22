using UnityEngine;

public class Goal : MonoBehaviour
{
    public string nextSceneName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelManager.Instance.LoadNextLevel(nextSceneName);
        }
    }
}