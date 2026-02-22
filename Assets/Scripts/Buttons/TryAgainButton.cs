using UnityEngine;

public class TryAgainButton : MonoBehaviour
{
    public GameOverButtons manager;

    public void OnMouseDown()
    {
        manager.TryAgain();
    }
}
