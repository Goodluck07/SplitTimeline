using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public static float sharedHealth = 100f;
    public static float maxHealth = 100f;

    private PlayerController playerController;

    void Start()
    {
        sharedHealth = maxHealth;
        playerController = GetComponent<PlayerController>();
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
        Invoke("Respawn", 1.5f);
    }

    void Respawn()
    {
        sharedHealth = maxHealth;
        LevelManager.Instance.ResetLevel();
    }

    public float GetHealth() => sharedHealth;
}