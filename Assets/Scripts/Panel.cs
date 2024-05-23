using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public static Panel instance;   
    public GameObject inventoryContainer;
    public GameObject inventoryPanel; // 
    public GameObject slotPrefab; // ���� ������
    private List<GameObject> slots = new List<GameObject>(); // ������ ������ ������ ����Ʈ
    public List<Sprite> itemSprites; // ������ �̹��� ����Ʈ

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        InitializeInventory(20); // 20ĭ¥�� �κ��丮 �ʱ�ȭ
        inventoryPanel.SetActive(true);
        SceneManager.sceneLoaded += OnSceneLoaded;
        AddItem(0);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    void InitializeInventory(int slotCount)
    {
        for (int i = 0; i < slotCount; i++)
        {
            GameObject slot = Instantiate(slotPrefab, inventoryPanel.transform);
            slots.Add(slot);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null && inventoryContainer != null)
        {
            inventoryPanel.transform.SetParent(canvas.transform, false);
            inventoryContainer.SetActive(true);
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