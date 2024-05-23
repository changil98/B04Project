using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomItem : MonoBehaviour
{
    public static RandomItem instance;
    public Reward reward;

    [SerializeField] private List<Item> items = new List<Item>(); // 아이템 리스트

    public bool[] itemStates; // 아이템 상태를 저장할 배열

    
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

    private void Update()
    {
   
    }

    public void InitializeItemStates(Reward _reward)
    {
        reward = _reward;
        if(itemStates.Length ==0)
        {
            itemStates = new bool[GameManager.Instance.itemImages.Length];
            LoadItemStates();
        }
        
        UpdateItemUI();
    }


    public void GetItem()
   {
        Debug.Log(itemStates.Length + " " + items.Count);
        for (int i = 0; i < items.Count; i++)
         {  
            if (items[i].image.name == reward.currentRewardItem.image.name)
            {
                    Debug.Log("아이템 적용" + i); 

                      itemStates[i] = true;
                // 해당 아이템의 이미지를 흰색으로 변경
                GameManager.Instance.itemImages[i].sprite = items[i].image;
                GameManager.Instance.itemImages[i].color = Color.white;
                        // 상태 저장
                       SaveItemStates();
             }  
          }
     }

    public void UpdateItemUI()
    {
        for(int i =0; i < items.Count; i++)
        {
            if (itemStates[i] == true)
            {
                // 해당 아이템의 이미지를 흰색으로 변경
                GameManager.Instance.itemImages[i].sprite = items[i].image;
                GameManager.Instance.itemImages[i].color = Color.white;
            }
            else if (itemStates[i] == false)
            {
                // 해당 아이템의 이미지를 검정으로 변경
                GameManager.Instance.itemImages[i].sprite = items[i].image;
                GameManager.Instance.itemImages[i].color = Color.black;
            }
          
        }
  
    }

    // 아이템 상태 저장
    private void SaveItemStates()
    {

        for (int i = 0; i < itemStates.Length; i++)
        {
            PlayerPrefs.SetInt("ItemState" + i, itemStates[i] ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    // 아이템 상태 로드
    public void LoadItemStates()
    {
        // 저장된 상태가 있다면 로드
        for (int i = 0; i < itemStates.Length; i++)
        { 
            // 저장된 상태가 있다면 불러오기
            if (PlayerPrefs.HasKey("ItemState" + i))
            {
                itemStates[i] = PlayerPrefs.GetInt("ItemState" + i, 0) == 1;
            }
        }
    }
}


