using UnityEngine;
using System.Collections;

public class CharacterSwitch : MonoBehaviour
{
    public GameObject pastCharacter;
    public GameObject futureCharacter;
    public Camera mainCamera;
    public HealthUI healthUI;

    private Animator pastAnim;
    private Animator futureAnim;
    private CameraFollow cameraFollow;
    private bool isSwitching = false;

    void Awake()
    {
        pastAnim = pastCharacter.GetComponent<Animator>();
        futureAnim = futureCharacter.GetComponent<Animator>();
        cameraFollow = mainCamera.GetComponent<CameraFollow>();

        futureCharacter.SetActive(false);
        pastCharacter.SetActive(true);
        cameraFollow.target = pastCharacter.transform;
    }

    public void SwitchCharacter(bool isInPast)
    {
        if (isSwitching) return;

        if (healthUI != null && !healthUI.CanSwitch())
        {
            UnityEngine.Debug.Log("Cannot switch — characters are dead");
            return;
        }

        isSwitching = true;

        if (isInPast)
        {
            pastCharacter.transform.position = new Vector3(
                futureCharacter.transform.position.x,
                futureCharacter.transform.position.y + 0.5f,
                0
            );
            pastCharacter.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            pastCharacter.SetActive(true);
            futureCharacter.SetActive(false);
            cameraFollow.target = pastCharacter.transform;
            pastAnim.Play("Idle");
            isSwitching = false;
        }
        else
        {
            futureCharacter.transform.position = new Vector3(
                pastCharacter.transform.position.x,
                pastCharacter.transform.position.y + 0.5f,
                0
            );
            futureCharacter.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            futureCharacter.SetActive(true);
            pastCharacter.SetActive(false);
            cameraFollow.target = futureCharacter.transform;
            futureAnim.Play("Idle");
            StartCoroutine(ForceGroundCheck());
        }
    }

    private IEnumerator ForceGroundCheck()
    {
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();

        PlayerController futureController = futureCharacter.GetComponent<PlayerController>();
        if (futureController.IsGrounded())
            futureAnim.Play("Idle");
        else
            futureAnim.Play("Fall");

        isSwitching = false;
    }
}