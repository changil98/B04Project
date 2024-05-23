using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackStartScene : MonoBehaviour
{
    public void BackScene()
    {
        DataManager.instance.musicNum = 1;
        SceneManager.LoadScene("StartGameScene");
    }
}
