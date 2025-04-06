using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankGrid : MonoBehaviour
{
    public List<Text> textList = new List<Text>();

    private void Start()
    {
        RankText();
    }

    void RankText()
    {
        for(int i =0; i< 5; i++)
        {
            if (DataManager.instance.ranks[i] != null)
            {
                textList[i].text = i+1 + ". " + DataManager.instance.ranks[i].UserName + " - " + DataManager.instance.ranks[i].ClearTime;
            }
        }
    }

}
