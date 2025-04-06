using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventorys : MonoBehaviour
{
    public static Inventorys Instance;

    public List<GameObject> inventory = new List<GameObject>();
    public List<int> itemNums = new List<int>();
    public List<bool> BoxLock = new List<bool>();
    public List<int> ItemWeight = new List<int>();
    public float CurrentWeight = 0f;
    public float MaxWeight = 100f;
    public Text WeightText;
    public bool VeryWeight = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ListInBox();
        MaxWeight += (DataManager.instance.BagLevel - 1) * 150;
        WeightTextChange();
        
    }

    private void Update()
    {
        GetItem();
        GetTreaser();
    }

    public void WeightTextChange()
    {
        Debug.Log("무게 확인");
        int Weight = 0;
        for(int i = 0; i < 8; i++)
        {
            if (!BoxLock[i])
            {
                Weight += ItemWeight[itemNums[i]];
            } else
            {
                break;
            }
        }
        
        CurrentWeight = Weight;
        WeightText.text = "무게 : " + Weight + " / " + MaxWeight;

        if( Weight >= MaxWeight )
        {
            Debug.Log("보물이 너무 많습니다.");
            VeryWeight = true;
        } else
        {
            VeryWeight = false;
        }
    }

    void ListInBox()
    {
        Debug.Log(4 + ((DataManager.instance.BagLevel - 1) * 2));
        for(int i = 0; i < 8; i++)
        {
            inventory.Add(this.transform.GetChild(0).transform.GetChild(i).gameObject);
            itemNums.Add(0);
            if(i >= 4 + ((DataManager.instance.BagLevel - 1) * 2))
            {
                BoxLock.Add(true);
            } else
            {
                BoxLock.Add(false);
            }
        }
    }
    

    void GetItem()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            int rand = Random.Range(1, 7);
            AddItem(rand);
        }
    }

    void GetTreaser()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            int rand = 7;
            AddItem(rand);
        }
    }

    public bool AddItem(int num)
    {
        bool itemGet = false;
        for(int i = 0; i < 8; i++)
        {
            if (itemNums[i] == 0 && !BoxLock[i])
            {

                itemNums[i] = num;
                Debug.Log("아이템 획득");
                itemGet = true;
                WeightTextChange();
                return true;
            }
        }
        if(!itemGet)
        {
            Debug.Log("배낭이 꽉 찼습니다.");
            return false;
        }
        return false;

    }

    public void ItemSelling()
    {
        int GetGold = 0;
        for(int i = 0;i < 8;i++)
        {
            if (itemNums[i] == 7)
            {
                GetGold += 300;
            }
        }
        DataManager.instance.Gold += GetGold;
        SceneManager.LoadScene("Lobby");
    }
}
