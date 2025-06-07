using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerObject; 
    public float roomSize = 14f;
    public float transitionTime = 0.5f;
    public float coridor_len = 5f;
    public float coridor_width = 3f;

    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;
    private Vector2Int currentRoom;

    void Start()
    {
        if (playerObject != null)
        {
            targetPosition = GetRoomCenter(playerObject.transform.position);
            transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        }
    }

    void LateUpdate()
    {
        if (playerObject == null) return;

        Vector3 newTarget = GetRoomCenter(playerObject.transform.position);

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
        float step = roomSize + coridor_len / 2;
        int roomX = Mathf.FloorToInt(playerPos.x / step);
        int roomY = Mathf.FloorToInt(playerPos.y / step);


        
        float centerX = roomX * step + roomSize / 2f + (coridor_len / 2) * roomX;
        float centerY = roomY * step + roomSize / 2f + (coridor_len / 2) * roomY;


        Debug.Log($"[Camera] Camera seto to ({centerX}, {centerY})");
        Debug.Log($"[Camera] Player is at ({playerPos.x}, {playerPos.y})");
        Debug.Log($"[Camera] Player is in room ({roomX}, {roomY})");


        return new Vector3(centerX, centerY, 0f);
    }
}
