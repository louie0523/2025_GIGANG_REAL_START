using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour
{
    public static ClearManager instance;

    public List<Statue> statueList = new List<Statue>();

    public bool isClear = false;

    public GameObject ClearDoor;
    public BoxCollider boxCollider;
    public Animator animator;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        boxCollider = ClearDoor.GetComponent<BoxCollider>();
        animator = ClearDoor.GetComponent<Animator>();
    }


    public void ClearTest()
    {
        if(!isClear)
        {
            int NeedCount = statueList.Count;
            int CurrentCount = 0;
            foreach (Statue statue in statueList)
            {
                if (statue.isTrue)
                {
                    CurrentCount++;
                }
            }
            if (CurrentCount >= NeedCount)
            {
                Debug.Log("퍼즐 클리어!");
                isClear = true;
                animator.SetTrigger("Open");
                boxCollider.enabled = false;

            }
            else
            {
                Debug.Log("조건 만족 못했어용");
            }
        }
    }
}
