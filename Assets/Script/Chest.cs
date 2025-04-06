using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public enum ChestType
    {
        item,
        Treaser,
    };

    public ChestType Ctype;
    public bool isOpen = false;
}
