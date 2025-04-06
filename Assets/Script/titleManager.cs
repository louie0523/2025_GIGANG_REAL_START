using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titleManager : MonoBehaviour
{

    public GameObject SelectStage;
    public GameObject Rank;
    public GameObject User;
    public InputField userName;
    
    public void GameQuit()
    {
        Application.Quit();
    }

    public void intoTheStageSelect()
    {
        SelectStage.SetActive(true);
    }

    public void QuitStageSelect()
    {
        SelectStage.SetActive(false);
    }

    public void OpenRank()
    {
        Rank.SetActive(true);
    }

    public void QuitRan()
    {
        Rank.SetActive(false);
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene("Lobby");
        DataManager.instance.TimeStart = true;
    }

    private void Start()
    {
        if(!DataManager.instance.isFristTIme)
        {
            User.SetActive(true);
            
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && !DataManager.instance.isFristTIme)
        {
            UserSer();
        }
    }

    public void UserSer()
    {
        string name = userName.text.Trim();

        if(!string.IsNullOrWhiteSpace(name))
        {
            Rank newrank = new Rank();
            newrank.UserName = name;
            newrank.ClearTime = 99999f;

            DataManager.instance.ranks.Add(newrank);
            Debug.Log("새 유저 투입 완료!");
            User.SetActive(false);
            DataManager.instance.isFristTIme = true;
            DataManager.instance.ListSet();
        } else
        {
            Debug.Log("올바른 이름을 적으세요.");
        }
    }
}
