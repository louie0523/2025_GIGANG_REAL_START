using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventorys : MonoBehaviour
{
    public static Inventorys Instance;

    public List<GameObject> inventory = new List<GameObject>();
    public List<int> itemNums = new List<int>();
    public List<bool> BoxLock = new List<bool>();
    public float CurrentWeight = 0f;
    public float MaxWeight = 250f;

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
    }

    private void Update()
    {
        GetItem();
    }

    void ListInBox()
    {
        for(int i = 0; i < 8; i++)
        {
            inventory.Add(this.transform.GetChild(0).transform.GetChild(i).gameObject);
            itemNums.Add(0);
            if(i >= 4 + (DataManager.instance.BagLevel-1 * 2))
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

    public void AddItem(int num)
    {
        bool itemGet = false;
        for(int i = 0; i < 8; i++)
        {
            if (itemNums[i] == 0 && !BoxLock[i])
            {

                itemNums[i] = num;
                itemGet = true;
                break;
            }
        }
        if(!itemGet)
        {
            Debug.Log("배낭이 꽉 찼습니다.");
        }

    }
}
