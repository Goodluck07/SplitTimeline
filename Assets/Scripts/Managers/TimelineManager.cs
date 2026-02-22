using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    [Header("Timeline Objects")]
    public GameObject pastBackground;
    public GameObject futureBackground;

    [Header("Character Switch")]
    public CharacterSwitch characterSwitch;

    [Header("Settings")]
    public bool startInPast = true;
    private bool isPast;

    void Start()
    {
        isPast = startInPast;
        ApplyTimeline();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchTimeline();
        }
    }

    public void SwitchTimeline()
    {
        isPast = !isPast;
        ApplyTimeline();

        if (characterSwitch != null)
            characterSwitch.SwitchCharacter(isPast);
    }

    void ApplyTimeline()
    {
        pastBackground.SetActive(isPast);
        futureBackground.SetActive(!isPast);
    }
}