using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public float Hp;
    public float MaxHp;
    public float Air;

    public float RotSpeed = 2.0f;
    public float rotationX = 0f;
    public float rotationY = 0f;

    public Camera Mcamera;

    Animator animator;
    bool isAttack = false;

    private void Start()
    {
        Mcamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Rotation();
        Attack();
    }

    void Move()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveZ = Input.GetAxis("Vertical");

        Vector3 Move = transform.forward * MoveZ + transform.right * MoveX;
        
        transform.Translate(Move.normalized * speed * Time.deltaTime, Space.World);
        Mcamera.transform.position = transform.position + new Vector3(0, 0.5f, 0);

    }

    void Rotation()
    {
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");

        rotationX -= MouseY;
        rotationY += MouseX;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        Mcamera.transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
        transform.rotation = Quaternion.Euler(0, rotationY, 0f);
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !isAttack)
        {
            animator.SetTrigger("Attack");
            isAttack = true;
            Invoke(("AttackFalse"), 0.5f);
        }
    }

    void AttackFalse()
    {
        isAttack = false;
    }
}
