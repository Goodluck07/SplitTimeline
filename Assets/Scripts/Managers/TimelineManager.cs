using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    [Header("Timeline Objects")]
    public GameObject pastBackground;
    public GameObject futureBackground;

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
        // Press TAB to switch timelines
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchTimeline();
        }
    }

    public void SwitchTimeline()
    {
        isPast = !isPast;
        ApplyTimeline();
    }

    void ApplyTimeline()
    {
        pastBackground.SetActive(isPast);
        futureBackground.SetActive(!isPast);
    }
}