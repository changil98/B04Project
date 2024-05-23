using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggreGate : MonoBehaviour
{
    public GameObject AggreGateBtn;
    public GameObject AggreGateLock;

    private void Start()
    {
        AggreGateBtn.SetActive(false);
        AggreGateLock.SetActive(true);
    }

    private void Update()
    {
        if (GameManager.Level >= 8)
        {
            AggreGateBtn.SetActive(true);
            AggreGateLock.SetActive(false);
        }
    }
}
