using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UseItems : MonoBehaviour
{
    public static UseItems instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(gameObject);
        }
    }
    public void InvokeVege()
    {
        GameManager.Instance.MakeVegetable();
    }
   public void StopVegetables()
    {
        // ���⼭ 1,4 �� ������ 2�� 5�� ���� ��ä�� ����
        if (RandomItem.instance.itemStates[0])
        {
            Invoke("InvokeVege", 2);
            Debug.Log("������ ���");
        }
        else if (RandomItem.instance.itemStates[3])
        {
            Invoke("InvokeVege", 5);
            Debug.Log("������ ���");
        }
    }

    public void RemoveVegetables()
    {
        if (RandomItem.instance.itemStates[2])
        // 3�� ��ä�� 2�ʵ��� ���������
        StartCoroutine(RemoveVegetablesCoroutine());

    }

        private IEnumerator RemoveVegetablesCoroutine()
    {
        // ��ä ��Ȱ��ȭ
        GameManager.Instance.apple.SetActive(false);

        // 2�� ���� ���
        yield return new WaitForSeconds(2);

        // ��ä �ٽ� Ȱ��ȭ
        GameManager.Instance.apple.SetActive(true);
    }

    public void SuperPower()
    {
        // 2�� , 5�� ������ 2�� 5�� �������°� ��
        // ĳ���Ϳ� ��Ƶ� ������ ��� ����� 
        if (RandomItem.instance.itemStates[1])
        {
            Vegetable.instance.SuperPowerUse(2f);
            Debug.Log("������ ���");
        }
        else if (RandomItem.instance.itemStates[4])
        {
            Vegetable.instance.SuperPowerUse(5f);
            Debug.Log("������ ���");
        } 

    }
}