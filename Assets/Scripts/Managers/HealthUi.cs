using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public UnityEngine.UI.Image healthBarFill;
    public TextMeshProUGUI healthText;

    void Update()
    {
        if (healthBarFill == null) return;

        float fill = HealthSystem.sharedHealth / HealthSystem.maxHealth;
        healthBarFill.fillAmount = fill;

        if (healthText != null)
            healthText.text = Mathf.RoundToInt(HealthSystem.sharedHealth) + "%";

        if (fill > 0.5f)
            healthBarFill.color = Color.green;
        else if (fill > 0.25f)
            healthBarFill.color = Color.yellow;
        else
            healthBarFill.color = Color.red;
    }

    public bool CanSwitch()
    {
        return HealthSystem.sharedHealth > 0;
    }
}