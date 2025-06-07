using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public float roomSize = 10f; // Dimenzija sobe
    public float transitionTime = 0.5f; // Trajanje tranzicije

    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        if (player != null)
        {
            targetPosition = GetRoomCenter(player.position);
            transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 newTarget = GetRoomCenter(player.position);

        if (newTarget != targetPosition)
        {
            targetPosition = newTarget;
        }

        // Glatko pomeri kameru ka targetu u roku od 0.5 sekundi
        transform.position = Vector3.SmoothDamp(
            transform.position,
            new Vector3(targetPosition.x, targetPosition.y, transform.position.z),
            ref velocity,
            transitionTime
        );
    }

    Vector3 GetRoomCenter(Vector3 playerPos)
    {
        int roomX = Mathf.FloorToInt(playerPos.x / roomSize);
        int roomY = Mathf.FloorToInt(playerPos.y / roomSize);

        float centerX = roomX * roomSize + roomSize / 2f;
        float centerY = roomY * roomSize + roomSize / 2f;

        return new Vector3(centerX, centerY, 0f);
    }
}
