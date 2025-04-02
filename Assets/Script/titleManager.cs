using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleManager : MonoBehaviour
{

    public GameObject SelectStage;
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

    public void GoToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
