using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icons : MonoBehaviour
{
    public List<string> itemNames = new List<string>();
    public Text ItemName;
    public GameObject LockImage;
    public Text Weight;

    private void Start()
    {
        ItemName = this.transform.Find("Text").GetComponent<Text>();
        LockImage = this.transform.Find("Lock").gameObject;
        Weight = this.transform.Find("Weight").GetComponent<Text>();
    }

    private void Update()
    {
        LockIObj();
        ItemName.text = itemNames[Inventorys.Instance.itemNums[int.Parse(gameObject.name)]];
        Weight.text = Inventorys.Instance.ItemWeight[Inventorys.Instance.itemNums[int.Parse(gameObject.name)]].ToString();
    }

    void LockIObj()
    {
        if (!Inventorys.Instance.BoxLock[int.Parse(gameObject.name)])
        {
            LockImage.SetActive(false);
        } else
        {
            LockImage.SetActive(true);
        }
    }


}
