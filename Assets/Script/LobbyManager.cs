using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public Text Gold;
    public List<int> NeedGold = new List<int>();

    private void Update()
    {
        Gold.text = DataManager.instance.Gold + "G";
    }

    public void BuyAir(int AirLevel)
    {
        if (DataManager.instance.Gold >= NeedGold[AirLevel-2])
        {
            if (DataManager.instance.AirLevel == AirLevel - 1)
            {
                DataManager.instance.Gold -= NeedGold[AirLevel-2];
                DataManager.instance.AirLevel++;
                DelayText.instance.DelayTexting("산소통을 업그레이드하였습니다.");
            }
            else
            {
                DelayText.instance.DelayTexting("해당 아이템을 구매할 수 없습니다.");
            }
        }
        else
        {
            DelayText.instance.DelayTexting("골드가 읎어요");
        }
    }

    public void BuyBag(int BagLevel)
    {
        if (DataManager.instance.Gold >= NeedGold[BagLevel+1])
        {
            if (DataManager.instance.BagLevel == BagLevel - 1)
            {
                DataManager.instance.Gold -= NeedGold[BagLevel+1];
                DataManager.instance.BagLevel++;
                DelayText.instance.DelayTexting("가방을 업그레이드하였습니다.");
            }
            else
            {
                DelayText.instance.DelayTexting("해당 아이템을 구매할 수 없습니다.");
            }
        }
        else
        {
            DelayText.instance.DelayTexting("골드가 읎어요");
        }
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Stage" + DataManager.instance.Stage);
    }
}
