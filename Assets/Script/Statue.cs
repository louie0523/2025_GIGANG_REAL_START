using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public GameObject Lights;

    public bool isTrue = false;

    private void Start()
    {
        Lights = transform.Find("Light").gameObject;
    }

    private void Update()
    {
        Lights.SetActive(isTrue);
    }

}
