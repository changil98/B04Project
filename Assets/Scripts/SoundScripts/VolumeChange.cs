using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]

public class VolumeChange : UnityEvent<float> { }

public class EventBus : MonoBehaviour
{
    public static VolumeChange OnVolumeChange = new VolumeChange();
}
