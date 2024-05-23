using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolumeController : MonoBehaviour
{
    public Slider volumeSlider;

    public void OnVolumeChanged()
    {
        EventBus.OnVolumeChange.Invoke(volumeSlider.value);
    }
}
