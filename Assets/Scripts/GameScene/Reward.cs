using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Reward : MonoBehaviour
{
    //public static Reward instance;
    public Inventory inventory;
       
    [SerializeField] private GameObject rewardPanel;
    [SerializeField] private GameObject exitBtn;
    [SerializeField] private TextMeshProUGUI rewardItemDes;
    [SerializeField] private Image rewardImage;

    private List<Item> items; // ������ ����Ʈ
    public Item currentRewardItem; // ���� ���� ������ 
    public int randomIndex;

    public void Awake()
    {

        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject); // �� ��ȯ �ÿ��� ������Ʈ ����
        //}
        //else
        //{
        //    if(instance != this)
        //    Destroy(gameObject);
        //}

        //inventory.init();
        //InitializeItems();
        //gameObject.SetActive(false);
    }

    private void Start()
    {
       inventory = Inventory.instance;
    }


    // ������ �������� ���� 
    public Item GetRandomItem()
    {

        inventory.init();
        InitializeItems();
        //inventory = Inventory.instance;
        if (items == null || items.Count == 0)
        {
            Debug.LogWarning("������ ����Ʈ�� ����ֽ��ϴ�.");
            return null;
        }
        randomIndex = Random.Range(0, items.Count);
        return items[randomIndex];
    }

    public void ActivePanel()
    {

        currentRewardItem = GetRandomItem();
        // ���� �˾��� ������ ���� ǥ��
        rewardImage.sprite = currentRewardItem.image;
        rewardImage.color = new Color(1, 1, 1, 1);
        rewardItemDes.text = currentRewardItem.description;
        rewardPanel.SetActive(true);
        RandomItem.instance.GetItem();

    }


    void InitializeItems()
    {
        items = new List<Item>();
        // ������ ���� �� ����Ʈ�� �߰�
        Item item1 = new Item(Resources.Load<Sprite>("food_01"), "��ä�� 2�ʵ��� �������ϴ�.");
        Item item2 = new Item(Resources.Load<Sprite>("food_02"), "���� ���°� 2�ʵ��� ���ӵ˴ϴ�.");
        Item item3 = new Item(Resources.Load<Sprite>("food_03"), "��� ��ä�� ������ϴ�.");
        Item item4 = new Item(Resources.Load<Sprite>("food_04"), "��ä�� 5�ʵ��� �������ϴ�.");
        Item item5 = new Item(Resources.Load<Sprite>("food_05"), "���� ���°� 5�ʵ��� ���ӵ˴ϴ�.");

        // ����Ʈ�� ������ �߰�
        items.Add(item1);
        items.Add(item2);
        items.Add(item3);
        items.Add(item4);
        items.Add(item5);
    }


    // �κ��丮�� �ֱ� 
    public void ApplyReward()
    {
        // ���� �������� �κ��丮�� �߰�
        inventory.itemSprites.Add(rewardImage.sprite);
        Debug.Log(rewardImage.sprite);

        inventory.AddItem(inventory.itemSprites.Count-1);
        // ���� �˾� â ��Ȱ��ȭ
        rewardPanel.SetActive(false);
        Time.timeScale = 1f;

        SceneManager.LoadScene("StageScene");
    }

    

}
