using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levers : MonoBehaviour
{
    public List<Statue> statueOn = new List<Statue>();
    public List<Statue> statueOff = new List<Statue>();
    public bool isDown = false;
    public bool isChanging = false;
    Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void LeverTriiger()
    {
        isChanging = true;
        if(!isDown)
        {
            isDown = true;
            animator.SetTrigger("Down");
            if(statueOff.Count > 0)
            {
                foreach (Statue statue in statueOff)
                {
                    statue.isTrue = false;
                }
            }
            if(statueOn.Count > 0)
            {
                foreach (Statue statue in statueOn)
                {
                    statue.isTrue = true;
                }
            }
        } else
        {
            animator.SetTrigger("Up");
            isDown=false;
            if(statueOn.Count > 0)
            {
                foreach (Statue statue in statueOn)
                {
                    statue.isTrue = false;
                }
            }
            if (statueOff.Count > 0)
            {
                foreach (Statue statue in statueOff)
                {
                    statue.isTrue = true;
                }
            }
        }
        ClearManager.instance.ClearTest();
        StartCoroutine(ChangeEnd());
    }

    IEnumerator ChangeEnd()
    {
        yield return new WaitForSeconds(0.15f);
        isChanging = false;
    }
}
