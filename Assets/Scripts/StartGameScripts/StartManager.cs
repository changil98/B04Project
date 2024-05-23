using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class StartManager : MonoBehaviour
{
    public GameObject startUI;
    public GameObject characterSelect;

    public void GameStartBtn()
    {
        startUI.SetActive(false);
        characterSelect.SetActive(true);
    }

    public void GordoSelect()
    {
        DataManager.instance.characterNum = 0;
        SceneManager.LoadScene(1);
    }

    public void BoySelect()
    {
        DataManager.instance.characterNum = 1;
        SceneManager.LoadScene(1);
    }
}
