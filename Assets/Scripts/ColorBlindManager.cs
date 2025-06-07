using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ColorBlindManager : MonoBehaviour
{
    public PostProcessVolume colorBlindVolume;

    public void EnableColorBlind(bool enabled)
    {
        colorBlindVolume.enabled = enabled;
    }
}
