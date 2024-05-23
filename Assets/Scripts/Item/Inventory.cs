using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public GameObject inventoryContainerPrefab; // �κ��丮 �����̳� ������
    public GameObject inventoryContainer;
    public GameObject inventoryPanel; // 
    public GameObject slotPrefab; // ���� ������
    private List<GameObject> slots = new List<GameObject>(); // ������ ������ ������ ����Ʈ
    public List<Sprite> itemSprites; // ������ �̹��� ����Ʈ


    public void init()
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
    void Start()
    {
        InitializeInventory(20); // 20ĭ¥�� �κ��丮 �ʱ�ȭ
        AddItem(0);
    }

    void InitializeInventory(int slotCount)
    {
        for (int i = 0; i < slotCount; i++)
        {
            GameObject slot = Instantiate(slotPrefab, inventoryPanel.transform);
            slots.Add(slot);
        }
    }

    public void AddItem(int index)
    {
        Debug.Log(index);
        Debug.Log(slots.Count);
        foreach (GameObject slot in slots)
        {
            Image slotImage = slot.transform.Find("ItemImage").GetComponent<Image>();
            if (slotImage.sprite == null)
            {
                Debug.Log("Item added to slot: " + index);
                slotImage.sprite = itemSprites[index];
                // �������Ѱ� �ٽ� ��Ÿ���� 
                slotImage.color = new Color(1, 1, 1, 1);
                break;
            }
        }
    }

}
