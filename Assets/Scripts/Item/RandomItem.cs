using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomItem : MonoBehaviour
{
    public static RandomItem instance;
    public Reward reward;

    [SerializeField] private List<Item> items = new List<Item>(); // ������ ����Ʈ

    public bool[] itemStates; // ������ ���¸� ������ �迭

    
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
                    Debug.Log("������ ����" + i); 

                      itemStates[i] = true;
                // �ش� �������� �̹����� ������� ����
                GameManager.Instance.itemImages[i].sprite = items[i].image;
                GameManager.Instance.itemImages[i].color = Color.white;
                        // ���� ����
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
                // �ش� �������� �̹����� ������� ����
                GameManager.Instance.itemImages[i].sprite = items[i].image;
                GameManager.Instance.itemImages[i].color = Color.white;
            }
            else if (itemStates[i] == false)
            {
                // �ش� �������� �̹����� �������� ����
                GameManager.Instance.itemImages[i].sprite = items[i].image;
                GameManager.Instance.itemImages[i].color = Color.black;
            }
          
        }
  
    }

    // ������ ���� ����
    private void SaveItemStates()
    {

        for (int i = 0; i < itemStates.Length; i++)
        {
            PlayerPrefs.SetInt("ItemState" + i, itemStates[i] ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    // ������ ���� �ε�
    public void LoadItemStates()
    {
        // ����� ���°� �ִٸ� �ε�
        for (int i = 0; i < itemStates.Length; i++)
        { 
            // ����� ���°� �ִٸ� �ҷ�����
            if (PlayerPrefs.HasKey("ItemState" + i))
            {
                itemStates[i] = PlayerPrefs.GetInt("ItemState" + i, 0) == 1;
            }
        }
    }
}


