using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public float speedDown;

    public int Hp = 100;
    public int MaxHp = 100;
    public float Air = 100f;
    public float MaxAir = 100f;

    public float RotSpeed = 2.0f;
    public float rotationX = 0f;
    public float rotationY = 0f;

    public Camera Mcamera;

    Animator animator;
    bool isAttack = false;

    public bool JumpTrue = false;
    public float JumpPower = 5f;
    Rigidbody rigid;

    public Slider HpSlider;
    public Slider AirSlider;

    public bool IsAlive = true;

    public bool isInvisible = false;

    public GameObject GameOver;

    private void Start()
    {
        Mcamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        StartCoroutine(AirPerSentDown());
        MaxAir = 100f + ((DataManager.instance.AirLevel-1) * 40f);
        Air = MaxAir;
        GameOver.SetActive(false);
    }

    private void Update()
    {
        if(IsAlive)
        {
            Move();
            Rotation();
            Attack();
            Jump(); 
            UseItme();
            HpAndAirSlider();
            WeightSpeedDown();
        }

    }

    void Move()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * MoveZ + transform.right * MoveX;

        transform.Translate(move.normalized * (speed - speedDown) * Time.deltaTime, Space.World);
        Mcamera.transform.position = transform.position + new Vector3(0, 0.5f, 0);
    }

    void Rotation()
    {
        float MouseX = Input.GetAxis("Mouse X") * RotSpeed;
        float MouseY = Input.GetAxis("Mouse Y") * RotSpeed;

        rotationX -= MouseY;
        rotationY += MouseX;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        Mcamera.transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !isAttack)
        {
            animator.SetTrigger("Attack");
            isAttack = true;
            Invoke(("AttackFalse"), 0.25f);
        }
    }

    void AttackFalse()
    {
        isAttack = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            JumpTrue = false;
        } else if(collision.gameObject.CompareTag("Death"))
        {
            Damage(1000);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            JumpTrue = true;
        }
    }


    void Jump()
    {
        if(Input.GetKeyDown (KeyCode.Space) && !JumpTrue)
        {
            rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            JumpTrue = true;
        }
    }

    void HpAndAirSlider()
    {
        HpSlider.value = (float)(MaxHp / Hp);
        AirSlider.value = Air / MaxAir;
    }

    IEnumerator AirPerSentDown()
    {
        while(Air >= 0 )
        {
            yield return new WaitForSeconds(5f);
            Air -= 5f - (DataManager.instance.AirLevel-1);
        }
        Air = 0;
        Debug.Log("산소가 모두 떨어졌습니다.");
        Damage(10000);
    }

    public void Damage(int damage)
    {
        Hp -= damage;
        if(Hp <= 0  && IsAlive)
        {
            Hp = 0;
            Debug.Log("플레이어가 사망하였습니다. 게임 오버");
            IsAlive = false;
            GameOver.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public void Heal(int heal)
    {
        Hp += heal;
        if(Hp > MaxHp)
        {
            Hp = MaxHp;
        }
    }

    public void AirCharge(int air)
    {
        Air += air;
        if(Air > 100) { 
            Air = 100;
        }
    }

    public void SpeedUp(float UpSpeed)
    {
        float DownSpeed = UpSpeed;
        speed += UpSpeed;
        StartCoroutine(SpeedDown(DownSpeed));
    }

    void WeightSpeedDown()
    {
        if(Inventorys.Instance.VeryWeight)
        {
            speedDown = 3f;
        } else
        {
            speedDown = 0;
        }
    }

    IEnumerator SpeedDown(float DownSpeed)
    {
        yield return new WaitForSeconds(5f);
        speed -= DownSpeed;
    }

    void UseItme()
    {
        int SelectNum = 0;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectNum = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectNum = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectNum = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectNum = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectNum = 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectNum = 6;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SelectNum = 7;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SelectNum = 8;
        }
        if (SelectNum > 0)
        {
            SelectNum--;
            if(Inventorys.Instance.itemNums[SelectNum] != 0 && !Inventorys.Instance.BoxLock[SelectNum])
            {
                int UseItemNum = Inventorys.Instance.itemNums[SelectNum];
                Inventorys.Instance.itemNums[SelectNum] = 0;
                Inventorys.Instance.WeightTextChange();
                switch (UseItemNum - 1)
                {
                    case 0:
                        Debug.Log("Hp 물약 사용");
                        Heal(30);
                        break;
                    case 1:
                        Debug.Log("산소 추가 보급 사용");
                        AirCharge(30);
                        break;
                    case 2:
                        Debug.Log("보물 탐색기 사용");
                        break;
                    case 3:
                        Debug.Log("이동 속도 증가(하급) 사용");
                        SpeedUp(3f);
                        break;
                    case 4:
                        Debug.Log("이동 속도 증가(고급) 사용");
                        SpeedUp(5f);
                        break;
                    case 5:
                        Debug.Log("연막탄 사용");
                        break;
                    case 6:
                        Debug.Log("보물을 버립니다.");
                        break;
                }

            }
            
        }
    }

    public void RetryThisStage()
    {
        SceneManager.LoadScene("Stage" + DataManager.instance.Stage);
    }



}
