using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerObject; 
    public float roomxSize = 14f;
    public float roomySize = 15f;
    public float transitionTime = 0.5f;
    public float coridor_len = 5f;
    public float coridor_width = 3f;

    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;

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

        if (newTarget != targetPosition)
        {
            targetPosition = newTarget;
        }

        transform.position = Vector3.SmoothDamp(
            transform.position,
            new Vector3(targetPosition.x, targetPosition.y, transform.position.z),
            ref velocity,
            transitionTime
        );
    }

    Vector3 GetRoomCenter(Vector3 playerPos)
    {
        float stepx = roomxSize + coridor_len / 2;
        float stepy = roomySize + coridor_len / 2;
        int roomX = Mathf.FloorToInt(playerPos.x / stepx);
        int roomY = Mathf.FloorToInt(playerPos.y / stepy);


        
        float centerX = roomX * stepx + roomxSize / 2f + (coridor_len / 2) * roomX;
        float centerY = roomY * stepy + roomySize / 2f + (coridor_len / 2) * roomY;
        Debug.Log($"RoomX: {roomX}, RoomY: {roomY}, CenterX: {centerX}, CenterY: {centerY}");


        return new Vector3(centerX, centerY, 0f);
    }
}