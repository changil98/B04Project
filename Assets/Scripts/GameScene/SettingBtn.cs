using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingBtn : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;


    public void SetActivePanel()
    {
        Time.timeScale = 0f;
        settingPanel.SetActive(true);
    }

    public void ExitPanel()
    {
        Time.timeScale = 1f;
        settingPanel.SetActive(false);
    }

    public void ReGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StageScene");
    }
}
