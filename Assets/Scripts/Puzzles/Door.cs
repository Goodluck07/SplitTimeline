using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;

    private BoxCollider2D col;
    private SpriteRenderer sr;

    void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void Open()
    {
        isOpen = true;
        col.enabled = false;
        sr.color = new Color(1, 1, 1, 0.2f); // fades out to show it's open
    }

    public void Close()
    {
        isOpen = false;
        col.enabled = true;
        sr.color = new Color(1, 1, 1, 1f);
    }
}