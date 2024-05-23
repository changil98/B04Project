using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public static Vegetable instance;

    private bool isSuper = false;
    private float superTimer = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != this)
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        float x = Random.Range(-2.8f, 2.5f);
        float y = 5f;

        transform.position = new Vector3(x, y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }

        // 무적 시간이 아닐때
        if (!isSuper)
        {
            if (collision.gameObject.CompareTag("Chibi"))
            {
                Time.timeScale = 0f;
                DataManager.instance.characterNum = 1;
                DataManager.instance.panel = 1;
            }
            if (collision.gameObject.CompareTag("Gordo"))
            {
                Time.timeScale = 0f;
                DataManager.instance.characterNum = 0;
                DataManager.instance.panel = 1;
            }
        }
    }

    public void SuperPowerUse(float duration)
    {
        if (isSuper)
        {
            superTimer -= Time.deltaTime;
            if (superTimer <= 0f)
            {
                isSuper = false;
            }
        }
        isSuper = true;
        superTimer = duration;
    }
}
