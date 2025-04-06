using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float WaitTime = 5f;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(SpkieAnime());
    }

    IEnumerator SpkieAnime()
    {
        while (true)
        {
            yield return new WaitForSeconds(WaitTime);
            Debug.Log("วิมค UP");
            animator.SetTrigger("Up");
            yield return new WaitForSeconds(1.5f);
            animator.SetTrigger("Down");
        }
    }
}
