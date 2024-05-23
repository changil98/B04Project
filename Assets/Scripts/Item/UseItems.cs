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
        // 여기서 1,4 번 누르면 2초 5초 동안 야채가 멈춤
        if (RandomItem.instance.itemStates[0])
        {
            Invoke("InvokeVege", 2);
            Debug.Log("아이템 사용");
        }
        else if (RandomItem.instance.itemStates[3])
        {
            Invoke("InvokeVege", 5);
            Debug.Log("아이템 사용");
        }
    }

    public void RemoveVegetables()
    {
        if (RandomItem.instance.itemStates[2])
        // 3번 야채가 2초동안 사라져야함
        StartCoroutine(RemoveVegetablesCoroutine());

    }

        private IEnumerator RemoveVegetablesCoroutine()
    {
        // 야채 비활성화
        GameManager.Instance.apple.SetActive(false);

        // 2초 동안 대기
        yield return new WaitForSeconds(2);

        // 야채 다시 활성화
        GameManager.Instance.apple.SetActive(true);
    }

    public void SuperPower()
    {
        // 2번 , 5번 누르면 2초 5초 무적상태가 됨
        // 캐릭터에 닿아도 게임이 계속 실행됨 
        if (RandomItem.instance.itemStates[1])
        {
            Vegetable.instance.SuperPowerUse(2f);
            Debug.Log("아이템 사용");
        }
        else if (RandomItem.instance.itemStates[4])
        {
            Vegetable.instance.SuperPowerUse(5f);
            Debug.Log("아이템 사용");
        } 

    }
}