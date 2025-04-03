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
            Inventorys.Instance.ItemSelling();
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}
