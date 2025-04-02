using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icons : MonoBehaviour
{
    public List<string> icon = new List<string>();
    public Text ItemName;
    public GameObject LockImage;
    public bool isLock = false;

    private void Start()
    {
        ItemName = this.transform.Find("Text").GetComponent<Text>();
        LockImage = this.transform.Find("Lock").gameObject;
    }

    private void Update()
    {
        LockIObj();
    }

    void LockIObj()
    {
        
        if(!isLock)
        {
            LockImage.SetActive(false);
        } else
        {
            LockImage.SetActive(true);
        }
    }

}
