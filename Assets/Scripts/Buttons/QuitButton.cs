using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void OnMouseDown()
    {
        Debug.Log("Quit Game Pressed");

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}