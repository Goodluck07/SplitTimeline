using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public string nextSceneName = "level1";
    private Animator anim;
    private bool isOpen = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (Key.isCollected && !isOpen)
        {
            isOpen = true;
            anim.SetTrigger("Open");
            Invoke("LoadNextLevel", 1.5f);
            UnityEngine.Debug.Log("Door opened — loading Level 2!");
        }
        else if (!Key.isCollected)
        {
            UnityEngine.Debug.Log("Need a key to open this door!");
        }
    }

    void LoadNextLevel()
    {
        LevelManager.Instance.LoadNextLevel(nextSceneName);
    }
}