using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class churnOut : MonoBehaviour
{
    public GameObject churnOutBtn;
    public GameObject churnOutLock;

    private void Start()
    {
        churnOutBtn.SetActive(false);
        churnOutLock.SetActive(true);
    }

    private void Update()
    {
        if (GameManager.Level >= 7)
        {
            churnOutBtn.SetActive(true);
            churnOutLock.SetActive(false);
        }
    }
}
