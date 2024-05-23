using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Util : MonoBehaviour
{
    [SerializeField] private GameObject invenPanel;
    [SerializeField] private GameObject exitBtn;
    [SerializeField] private GameObject invenText;

    //[SerializeField] private Text money;


    public void SetActivePanel()
    {
        invenPanel.SetActive(true);
        exitBtn.SetActive(true);
        invenText.SetActive(true);
    }

    public void ExitPanel()
    {
        invenPanel.SetActive(false);
        exitBtn.SetActive(false);
        invenText.SetActive(false);
    }

}
