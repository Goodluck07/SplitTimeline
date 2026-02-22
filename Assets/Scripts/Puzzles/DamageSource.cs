using UnityEngine;

public class DamageSource : MonoBehaviour
{
    public enum DamageType
    {
        Spike,
        PoisonFlower
    }

    public DamageType damageType;
    public float damageCooldown = 3f;
    private float cooldownTimer = 0f;
    private bool onCooldown = false;

    void Update()
    {
        if (onCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
                onCooldown = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ApplyDamage(other);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        ApplyDamage(other);
    }

    void ApplyDamage(Collider2D other)
    {
        if (onCooldown) return;
        if (!other.CompareTag("Player")) return;

        HealthSystem health = other.GetComponent<HealthSystem>();
        PlayerController controller = other.GetComponent<PlayerController>();
        if (health == null) return;

        switch (damageType)
        {
            case DamageType.Spike:
                health.TakeDamage(100f);
                break;

            case DamageType.PoisonFlower:
                if (other.gameObject.name == "PlayerPast")
                    health.TakeDamage(50f);
                else if (other.gameObject.name == "PlayerFuture")
                    health.TakeDamage(25f);
                break;
        }

        if (controller != null)
            controller.TakeHit();

        onCooldown = true;
        cooldownTimer = damageCooldown;
    }
}