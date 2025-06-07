using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public float roomSize = 10f;

    public float coridorlen = 5f;
    public float transitionTime = 0.5f;

    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;
    private Vector2Int currentRoom;

    void Start()
    {
        if (player != null)
        {
            currentRoom = GetRoomCoords(player.position);
            targetPosition = GetRoomCenter(currentRoom);
            transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        Vector2Int newRoom = GetRoomCoords(player.position);

        if (newRoom != currentRoom)
        {
            currentRoom = newRoom;
            targetPosition = GetRoomCenter(currentRoom);
        }

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref velocity,
            transitionTime
        );
    }

    Vector2Int GetRoomCoords(Vector3 playerPos)
    {
        int roomX = Mathf.FloorToInt(playerPos.x / (roomSize + coridorlen));
        int roomY = Mathf.FloorToInt(playerPos.y / (roomSize + coridorlen));
        return new Vector2Int(roomX, roomY);
    }

    Vector3 GetRoomCenter(Vector2Int roomCoords)
    {
        float centerX = roomCoords.x * roomSize + (roomSize+coridorlen) / 2f;
        float centerY = roomCoords.y * roomSize + (roomSize+coridorlen) / 2f;
        return new Vector3(centerX, centerY, transform.position.z);
    }
}
