using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum EnmeyType
    {
        Myway,
        iLoveYou,
    };
    
    public EnmeyType enemyType;

    NavMeshAgent agent;
    public float NavDistance = 15f;
    public GameObject Player;
    public Player player;
    public bool isAttack = false;

    public float moveSpeed = 2f;
   

    private void Start()
    {
        if(enemyType != EnmeyType.Myway)
        {
            agent = this.GetComponent<NavMeshAgent>();
        }
        Player = GameObject.Find("Player");
        player = Player.GetComponent<Player>();
    }

    private void Update()
    {
        if(enemyType != EnmeyType.Myway)
        {
            NavEnemy();
        } else
        {
            MyWayEnemy();
        }
    }

    void NavEnemy()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if(distance > NavDistance)
        {
            agent.isStopped = true;
            return;
        }
        if(distance < 2f)
        {
            agent.isStopped = true;
            StartCoroutine(DamagePlayer());
        } else
        {
            agent.isStopped = false;
        }

        agent.destination = Player.transform.position;
    }

    IEnumerator DamagePlayer()
    {
       if(!isAttack)
        {
            isAttack = true;
            Debug.Log(gameObject.name + "가 플레이어게 피해를 입힘");
            player.Damage(30);
            yield return new WaitForSeconds(2);
            isAttack = false;
            if(enemyType == EnmeyType.iLoveYou)
            {
                if (Vector3.Distance(transform.position, Player.transform.position) < 2f)
                {
                    agent.isStopped = true;
                    StartCoroutine(DamagePlayer());
                }
                else
                {
                    agent.isStopped = false;
                    
                }
            } else
            { 
                if((Vector3.Distance(transform.position, Player.transform.position) < 2f)) {
                    StartCoroutine(DamagePlayer());
                }
            }
        }
    }

    void MyWayEnemy()
    {
        float raydis = 1f;
        

        Ray ray = new Ray(transform.position + Vector3.up * 0.5f, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raydis)) {
            if (!hit.collider.CompareTag("Player")) {
                transform.Rotate(0, 180f, 0);
            }
        } else
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if(Vector3.Distance(transform.position, player.transform.position) < 2f)
        {
            StartCoroutine(DamagePlayer());
        }
    }
}
