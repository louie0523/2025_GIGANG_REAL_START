using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayText : MonoBehaviour
{
    public static DelayText instance;

    public Text Texts;

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
        Texts = this.GetComponent<Text>();
    }

    public void DelayTexting(string text)
    {
        Texts.text = text;
        Invoke("TextClear", 1f);

    }

    void TextClear()
    {
        Texts.text = "";
    }


}
