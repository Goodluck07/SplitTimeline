using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public static float sharedHealth = 100f;
    public static float maxHealth = 100f;
    private static bool initialized = false;

    private PlayerController playerController;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();

        if (!initialized)
        {
            sharedHealth = maxHealth;
            initialized = true;
        }
    }

    void OnDestroy()
    {
        initialized = false;
    }

    public void TakeDamage(float amount)
    {
        sharedHealth -= amount;
        sharedHealth = Mathf.Clamp(sharedHealth, 0, maxHealth);
        UnityEngine.Debug.Log("Shared Health: " + sharedHealth);

        if (sharedHealth <= 0)
            Die();
    }

    void Die()
    {
        playerController.Die();
        GameOverManager.lastPlayedLevel = SceneManager.GetActiveScene().buildIndex;
        Invoke("LoadGameOver", 1.5f);
    }

    void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }


    public float GetHealth() => sharedHealth;
}