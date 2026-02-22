using UnityEngine;

public class TryAgainButton : MonoBehaviour
{
    public GameOverButtons manager;

    void OnMouseDown()
    {
        manager.TryAgain();
    }
}
