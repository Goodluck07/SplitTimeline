using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -10);

    [Header("Follow Speed")]
    public float baseSmoothing = 5f;
    public float maxSmoothing = 15f;
    public float speedThreshold = 3f;

    [Header("Look Ahead")]
    public float lookAheadDistance = 2f;
    public float lookAheadSpeed = 4f;

    [Header("Camera Bounds")]
    public bool useBounds = false;
    public float minX, maxX, minY, maxY;

    private Vector3 lookAheadOffset;
    private float lastTargetX;
    private Rigidbody2D targetRb;

    void LateUpdate()
    {
        if (target == null) return;

        // Get target rigidbody if not cached
        if (targetRb == null)
            targetRb = target.GetComponent<Rigidbody2D>();

        // Match smoothing to player speed
        float playerSpeed = targetRb != null ? Mathf.Abs(targetRb.linearVelocity.x) : 0f;
        float smoothing = Mathf.Lerp(baseSmoothing, maxSmoothing, playerSpeed / speedThreshold);

        // Look ahead in direction of movement
        float moveDirection = target.position.x - lastTargetX;
        if (Mathf.Abs(moveDirection) > 0.01f)
        {
            lookAheadOffset = Vector3.Lerp(
                lookAheadOffset,
                new Vector3(Mathf.Sign(moveDirection) * lookAheadDistance, 0, 0),
                lookAheadSpeed * Time.deltaTime
            );
        }
        else
        {
            lookAheadOffset = Vector3.Lerp(
                lookAheadOffset,
                Vector3.zero,
                lookAheadSpeed * 0.5f * Time.deltaTime
            );
        }

        // Calculate desired position
        Vector3 desiredPosition = target.position + offset + lookAheadOffset;

        // Smooth follow — faster when player moves faster
        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothing * Time.deltaTime
        );

        // Apply bounds if enabled
        if (useBounds)
        {
            smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minX, maxX);
            smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minY, maxY);
        }

        smoothedPosition.z = -10f;
        transform.position = smoothedPosition;

        lastTargetX = target.position.x;
    }
}