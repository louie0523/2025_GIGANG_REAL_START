using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public int BagLevel = 1;
    public int AirLevel = 1;
    public int Gold = 500;
    public int Stage = 1;

    [SerializeField] public List<Rank> ranks = new List<Rank>();


    public bool isFristTIme = false;    
    public bool TimeStart = false;
    public float CurrentTime = 0f;
    public int CurrentNum = 0;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(TimeStart)
        {
            CurrentTime += Time.deltaTime;
        }
    }

    public void Reset()
    {
        BagLevel = 1;
        AirLevel = 1;
        Gold = 500;
        Stage = 1;
        isFristTIme = false;
        TimeStart = false;
        ranks[CurrentNum].ClearTime = CurrentTime;
        CurrentTime = 0f;
        CurrentNum++;
        SceneManager.LoadScene(0);
    }

    public void ListSet()
    {
        ranks.Sort((a,b) => a.ClearTime.CompareTo(b.ClearTime));
    }

}
