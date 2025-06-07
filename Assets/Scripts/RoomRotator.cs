using UnityEngine;

public class RoomRotator : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!GameManager.Instance.IsPreparationPhase())
            return;

        RotateRoom();
    }

    private void RotateRoom()
    {
        transform.Rotate(0f, 0f, 90f);
    }
}
