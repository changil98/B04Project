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

    private List<Item> items; // 아이템 리스트
    public Item currentRewardItem; // 현재 보상 아이템 
    public int randomIndex;

    public void Awake()
    {

        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject); // 씬 전환 시에도 오브젝트 유지
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


    // 아이템 랜덤으로 띄우기 
    public Item GetRandomItem()
    {

        inventory.init();
        InitializeItems();
        //inventory = Inventory.instance;
        if (items == null || items.Count == 0)
        {
            Debug.LogWarning("아이템 리스트가 비어있습니다.");
            return null;
        }
        randomIndex = Random.Range(0, items.Count);
        return items[randomIndex];
    }

    public void ActivePanel()
    {

        currentRewardItem = GetRandomItem();
        // 보상 팝업에 아이템 정보 표시
        rewardImage.sprite = currentRewardItem.image;
        rewardImage.color = new Color(1, 1, 1, 1);
        rewardItemDes.text = currentRewardItem.description;
        rewardPanel.SetActive(true);
        RandomItem.instance.GetItem();

    }


    void InitializeItems()
    {
        items = new List<Item>();
        // 아이템 생성 및 리스트에 추가
        Item item1 = new Item(Resources.Load<Sprite>("food_01"), "야채가 2초동안 없어집니다.");
        Item item2 = new Item(Resources.Load<Sprite>("food_02"), "무적 상태가 2초동안 지속됩니다.");
        Item item3 = new Item(Resources.Load<Sprite>("food_03"), "모든 야채가 사라집니다.");
        Item item4 = new Item(Resources.Load<Sprite>("food_04"), "야채가 5초동안 없어집니다.");
        Item item5 = new Item(Resources.Load<Sprite>("food_05"), "무적 상태가 5초동안 지속됩니다.");

        // 리스트에 아이템 추가
        items.Add(item1);
        items.Add(item2);
        items.Add(item3);
        items.Add(item4);
        items.Add(item5);
    }


    // 인벤토리에 넣기 
    public void ApplyReward()
    {
        // 보상 아이템을 인벤토리에 추가
        inventory.itemSprites.Add(rewardImage.sprite);
        Debug.Log(rewardImage.sprite);

        inventory.AddItem(inventory.itemSprites.Count-1);
        // 보상 팝업 창 비활성화
        rewardPanel.SetActive(false);
        Time.timeScale = 1f;

        SceneManager.LoadScene("StageScene");
    }

    

}
