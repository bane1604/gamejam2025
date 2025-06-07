using UnityEngine;
using System.Collections.Generic;

public class RoomRotatorTEST : MonoBehaviour
{
    public List<GameObject> doors;     // Order: Top, Right, Bottom, Left
    public List<GameObject> wallFills; // Order: Top, Right, Bottom, Left

    private void OnMouseDown()
    {
        if (!GameManager.Instance.IsPreparationPhase())
            return;

        RotateDoorsClockwise();
    }

    private void RotateDoorsClockwise()
    {
        int count = doors.Count;

        // Save which doors are currently active
        List<bool> activeDoors = new List<bool>();
        for (int i = 0; i < count; i++)
        {
            activeDoors.Add(doors[i].activeSelf);
        }

        // Deactivate all doors and show wall fills
        for (int i = 0; i < count; i++)
        {
            doors[i].SetActive(false);
            wallFills[i].SetActive(true);
        }

        // Activate the new door position, hide its wall fill
        for (int i = 0; i < count; i++)
        {
            int newIndex = (i + 1) % count;
            if (activeDoors[i])
            {
                doors[newIndex].SetActive(true);
                wallFills[newIndex].SetActive(false);
            }
        }
    }
}
