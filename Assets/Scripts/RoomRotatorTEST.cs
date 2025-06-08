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

        // Save door active states, colors, and tags
        List<bool> activeDoors = new List<bool>();
        List<Color> doorColors = new List<Color>();
        List<string> doorTags = new List<string>();

        for (int i = 0; i < count; i++)
        {
            GameObject door = doors[i];

            activeDoors.Add(door.activeSelf);

            SpriteRenderer sr = door.GetComponent<SpriteRenderer>();
            doorColors.Add(sr.color);

            doorTags.Add(door.tag);
        }

        // Deactivate all doors and enable wallFills
        for (int i = 0; i < count; i++)
        {
            doors[i].SetActive(false);
            wallFills[i].SetActive(true);
        }

        // Rotate doors
        for (int i = 0; i < count; i++)
        {
            int newIndex = (i + 1) % count;

            if (activeDoors[i])
            {
                GameObject door = doors[newIndex];
                door.SetActive(true);
                wallFills[newIndex].SetActive(false);

                // Rotate color
                SpriteRenderer sr = door.GetComponent<SpriteRenderer>();
                sr.color = doorColors[i];

                // Rotate tag
                door.tag = doorTags[i];
            }
        }
    }
}
