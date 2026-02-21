using UnityEngine;

public class Crate : MonoBehaviour
{
    private Vector3 pastPosition;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pastPosition = transform.position;
    }

    void Update()
    {
        if (TimelineSwitch.Instance.IsInPast())
        {
            pastPosition = transform.position;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
            transform.position = pastPosition;
        }
    }
}