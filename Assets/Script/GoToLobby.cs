using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLobby : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            if (DataManager.instance.Stage < 1)
            {
                DataManager.instance.Stage++;
                Inventorys.Instance.ItemSelling();
            } else
            {
                Debug.Log("클리어 했습니다.!");
                DataManager.instance.Reset();
            }
        }
    }
}
