using UnityEngine;

public class PressureButton : MonoBehaviour
{
    public Door targetDoor;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Crate"))
        {
            if (targetDoor != null) targetDoor.Open();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Crate"))
        {
            if (targetDoor != null) targetDoor.Close();
        }
    }
}