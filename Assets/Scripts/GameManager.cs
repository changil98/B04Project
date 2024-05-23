using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject settingPanel;
    public GameObject endPanel;
    public GameObject gordo;
    public GameObject chibi;

    public float timeRemaining = 1.0f;
    private bool timerIsRunning = false;

    static int stage = 0;

    static int level = 5;

    public GameObject apple;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite normalImage;
    [SerializeField] private Sprite speedUpImage;
    [SerializeField] private Sprite ChurnOutImage;
    [SerializeField] private Sprite AggreGateImage;
    [SerializeField] private TextMeshProUGUI timeText;
    public SpriteRenderer[] itemImages; // ���� �� UI�� �ִ� ������ �̹��� �迭

    public Reward reward;
    public UseItems useItems;

    public static int Stage
    {
        get { return stage; }
        set { stage = value; }
    }

    public static int Level
    {
        get { return level; }
        set { level = value; }
    }

    private void Awake()
    {
        GameManager.Instance = this;
        Time.timeScale = 1.0f;
       
    }
   
    

    public void ResetGame()
    {
        Rigidbody2D rb = apple.GetComponent<Rigidbody2D>();
        switch (stage)
        {
            case 0:
                InvokeRepeating("MakeVegetable", 0, 1f);
                rb.gravityScale = 0.5f;
                spriteRenderer.sprite = normalImage;
                break;
            case 1:
                InvokeRepeating("MakeVegetable", 0, 1f);
                rb.gravityScale = 1f;
                spriteRenderer.sprite = speedUpImage;
                break;
            case 2:
                InvokeRepeating("MakeVegetable", 0, 0.7f);
                rb.gravityScale = 0.5f;
                spriteRenderer.sprite = ChurnOutImage;
                break;
            case 3:
                InvokeRepeating("MakeVegetable", 0, 0.7f);
                rb.gravityScale = 1f;
                spriteRenderer.sprite = AggreGateImage;
                break;
        }
    }
    public void MakeVegetable()
    {
        Instantiate(apple);
    }

    private void Start()
    {
        timerIsRunning = true;

        ResetGame();
        if (DataManager.instance.characterNum == 0)
        {
            gordo.SetActive(true);
            chibi.SetActive(false);
        }
        else if (DataManager.instance.characterNum == 1)
        {
            gordo.SetActive(false);
            chibi.SetActive(true);
        }

        switch (stage)
        {
            case 0:
                timeRemaining = 30;
                break;
            case 1:
                timeRemaining = 45;
                break;
            case 2:
                timeRemaining = 45;
                break;
            case 3:
                timeRemaining = 60;
                break;
        }

        RandomItem.instance.InitializeItemStates(reward); 
    }


    private void Update()
    {
        
        if (timerIsRunning)
        {
            if (timeRemaining > 0 )
            {
                timeRemaining -= Time.deltaTime;
                timeText.text = timeRemaining.ToString("N2");
            }

            else if(timeRemaining <= 0.0f)
            {
                switch (stage) // �������� �ر�
                {
                    case 0:
                        if (level < 6)
                        {
                            level = 6;
                        }
                        break;
                    case 1:
                        if (level < 7)
                        {
                            level = 7;
                        }
                        break;
                    case 2:
                        level = 8;
                        break;
                }

                Time.timeScale = 0f;
                timeRemaining = 0;
                timerIsRunning = false;
                timeText.text = timeRemaining.ToString("N2");
                // �ϴ� 0�ʰ� �Ǹ� Ŭ����ϱ� ���� �ǳ� �߰� 
                if (reward != null)
                {
                    reward.ActivePanel(); // ���� �г� Ȱ��ȭ
                }
                else
                {
                    Debug.LogError("���̷���");
                }
            }
        }

        if (Time.timeScale == 0 && DataManager.instance.panel == 1)
        {
            endPanel.SetActive(true);
            DataManager.instance.panel = 0;
        }

        // ������ ��� �ٵ� ���� ���� �������� true �϶��� ��� ���� 
        if (RandomItem.instance.itemStates[0] && Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseItems.instance.StopVegetables();
            RandomItem.instance.itemStates[0] = false;
            Debug.Log("������ ���");
        }
        else if (RandomItem.instance.itemStates[3] && Input.GetKeyDown(KeyCode.Alpha4))
        {
            UseItems.instance.StopVegetables();
            RandomItem.instance.itemStates[3] = false;
            Debug.Log("������ ���");
        }
        else if (RandomItem.instance.itemStates[2] && Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseItems.instance.RemoveVegetables();
            RandomItem.instance.itemStates[2] = false;
            Debug.Log("������ ���");
        }
        else if (RandomItem.instance.itemStates[1] && Input.GetKeyDown(KeyCode.Alpha2))
        {

            UseItems.instance.SuperPower();
            RandomItem.instance.itemStates[1] = false;
            Debug.Log("������ ���");
        }
        else if (RandomItem.instance.itemStates[4]  && Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseItems.instance.SuperPower();
            RandomItem.instance.itemStates[4] = false;
            Debug.Log("������ ���");
        }
    }
}
