using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedUp : MonoBehaviour
{
    public GameObject speedUpBtn;
    public GameObject speedUpLock;

    private void Start()
    {
        speedUpBtn.SetActive(false);
        speedUpLock.SetActive(true);
    }

    private void Update()
    {
        if (GameManager.Level >= 6)
        {
            speedUpBtn.SetActive(true);
            speedUpLock.SetActive(false);
        }
    }
}
