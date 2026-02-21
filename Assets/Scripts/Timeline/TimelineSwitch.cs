using UnityEngine;

public class TimelineSwitch : MonoBehaviour
{
    public static TimelineSwitch Instance;

    [Header("Timeline Objects")]
    public GameObject[] pastObjects;
    public GameObject[] futureObjects;

    [Header("Settings")]
    public KeyCode switchKey = KeyCode.E;

    public bool isInPast = true;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ApplyTimeline();
    }

    void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            Switch();
        }
    }

    public void Switch()
    {
        isInPast = !isInPast;
        ApplyTimeline();
    }

    void ApplyTimeline()
    {
        foreach (GameObject obj in pastObjects)
            if (obj != null) obj.SetActive(isInPast);

        foreach (GameObject obj in futureObjects)
            if (obj != null) obj.SetActive(!isInPast);
    }

    public bool IsInPast() => isInPast;
}
