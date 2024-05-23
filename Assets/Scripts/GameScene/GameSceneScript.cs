using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneScript : MonoBehaviour
{
    public GameObject gordo;
    public GameObject chibi;
    public GameObject menu;

    public void PlayerReSelect()
    {
        //DataManager.instance.characterNum = 0;
        gordo.SetActive(true);
        chibi.SetActive(false);
        menu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Player2ReSelect()
    {
        //DataManager.instance.characterNum = 1;
        gordo.SetActive(false);
        chibi.SetActive(true);
        menu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MenuBtn()
    {
        menu.SetActive(true);
    }

    public void BackBtn()
    {
        menu.SetActive(false);
    }

    public void RetryBtn()
    {
        SceneManager.LoadScene(2);
    }

    public void BackToStageBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
