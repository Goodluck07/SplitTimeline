using UnityEngine;

public class Key : MonoBehaviour
{
    public static bool isCollected = false;

    void Start()
    {
        isCollected = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCollected = true;
            UnityEngine.Debug.Log("Key collected!");
            gameObject.SetActive(false);
        }
    }
}