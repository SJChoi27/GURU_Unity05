using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Payer2 : MonoBehaviour
{
    public float moveSpeed = 3f; // 이동 속도 변수
    CharacterController cc; // 캐릭터 콘트롤러 변수
    public GameObject other1;
    public GameObject other1_1;
    public GameObject other2;
    public GameObject other2_2;
    public GameObject other3;
    public GameObject other3_3;

    public GameObject Other1;
    public GameObject Other1_1;
    public GameObject Other2;
    public GameObject Other2_2;
    public GameObject Other3;
    public GameObject Other3_3;

    float gravity = -20f; // 중력 변수
    float yVelocity = 0; // 수직 속력 변수

    //점프에 사용하는 변수들
    public float jumpPower = 10f; // 점프력 변수
    public bool isJumping = false; // 점프 상태 변수
    public int itemCount;
    public Text gameText;
    Animator anim;

    public UnityEngine.UI.Text text_Timer;
    private float time_current;
    private float time_Max = 100f;
    private bool isEnded;
    int book1 = 0;
    int book2 = 0;
    int book3 = 0;

    private void Start()
    {
        other1.gameObject.SetActive(false);
        other1_1.gameObject.SetActive(false);
        other2.gameObject.SetActive(false);
        other2_2.gameObject.SetActive(false);
        other3.gameObject.SetActive(false);
        other3_3.gameObject.SetActive(false);

        Other1.gameObject.SetActive(true);
        Other1_1.gameObject.SetActive(true);
        Other2.gameObject.SetActive(true);
        Other2_2.gameObject.SetActive(true);
        Other3.gameObject.SetActive(true);
        Other3_3.gameObject.SetActive(true);
        cc = GetComponent<CharacterController>(); // 캐릭터 콘트롤러 컴포넌트 받아오기
        Reset_Timer();
        anim = GetComponentInChildren<Animator>();
    }
    /*    private void OncollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "door")
                transform.position = new Vector3(58, 1, 0);
        }*/
    void Update()
    {
        //TryCrouch();
        // 키보드 [W], [A], [S], [D] 버튼을 입력하면 캐릭터를 그 방향으로 이동시키고 싶다
        float h = Input.GetAxis("Horizontal"); // 1. 사용자의 입력을 받는다.
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // 2. 이동 방향을 설정한다.
        dir = dir.normalized;

        dir = Camera.main.transform.TransformDirection(dir); // 2-1. 메인 카메라를 기준으로 방향을 변환한다.

        transform.position += dir * moveSpeed * Time.deltaTime; // 3. 이동 속도에 맞춰 이동한다, p = p0 + vt

        anim.SetFloat("MoveMotion", dir.magnitude);

        // 플레이어에 중력 적용하기
        yVelocity += gravity * Time.deltaTime; // 2-3. 캐릭터 수직 속도에 중력 값을 적용한다.
        dir.y = yVelocity;
        cc.Move(dir * moveSpeed * Time.deltaTime); // 3. 이동 속도에 맞춰 이동한다.
                                                   //점프                                                                                           
                                                   // 2-2. 만일, 점프 중이었고, 다시 바닥에 착지했다면...

        if (isJumping && cc.collisionFlags == CollisionFlags.Below)
        {
            // 점프 전 상태로 초기화한다.
            isJumping = false;
            // 캐릭터 수직 속도를 0으로 만든다.
            yVelocity = 0;
        }
        // 2-3. 만일, 키보드 [Spacebar] 키를 입력했고, 점프를 하지 않은 상태라면...
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            // 캐릭터 수직 속도에 점프력을 적용하고 점프 상태로 변경한다.
            yVelocity = jumpPower;
            isJumping = true;
        }
        if(itemCount==6)
        {
            gameText.color = new Color32(255, 185, 0, 255);
            gameText.text = "안내데스크로 이동하라";
            //Invoke("LastScene", 3);
        }
        if (isEnded)
            return;
        Check_Timer();
    }
    private void Check_Timer()
    {
        if (0 < time_current)
        {
            time_current -= Time.deltaTime;
            text_Timer.text = $"{time_current:N1}" +" s";
            Debug.Log(time_current);
            if (time_current < 0.01)
            {
                gameText.color = new Color32(255, 185, 0, 255);
                gameText.text = "GAME OVER";
                Invoke("LastScene5", 4);
                SceneManager.LoadScene(5);
            }
        }
        else if (!isEnded)
        {
            End_Timer();
        }
    }
    private void End_Timer()
    {
        Debug.Log("End");
        time_current = 0;
        text_Timer.text = $"{time_current:N1}"+" s";
        isEnded = true;
    }

    private void Reset_Timer()
    {
        time_current = time_Max;
        text_Timer.text = $"{time_current:N1}"+" s";
        isEnded = false;
        Debug.Log("Start");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "item1")
        { //충돌 오브젝트가 아이템일때
            itemCount++; // 점수 올리기 
            other.gameObject.SetActive(false); //아이템 비활성화 
            book1++;
            if(book1==1)
            {
                other1.gameObject.SetActive(true);
                Other1.gameObject.SetActive(false);
            }
            if (book1 == 2)
            {
                other1_1.gameObject.SetActive(true);
                Other1_1.gameObject.SetActive(false);
            }
                
        }
        else if (other.gameObject.name == "item2")
        { //충돌 오브젝트가 아이템일때
            itemCount++; // 점수 올리기 
            other.gameObject.SetActive(false); //아이템 비활성화 
            book2++;
            if (book2 == 1)
            {
                other2.gameObject.SetActive(true);
                Other2.gameObject.SetActive(false);
            }
                
            if (book2 == 2)
            {
                other2_2.gameObject.SetActive(true);
                Other2_2.gameObject.SetActive(false);
            }
                
        }
        else if (other.gameObject.name == "item3")
        { //충돌 오브젝트가 아이템일때
            itemCount++; // 점수 올리기 
            other.gameObject.SetActive(false); //아이템 비활성화 
            book3++;
            if (book3 == 1)
            {
                other3.gameObject.SetActive(true);
                Other3.gameObject.SetActive(false);
            }
                
            if (book3 == 2)
            {
                other3_3.gameObject.SetActive(true);
                Other3_3.gameObject.SetActive(false);
            }
                
        }
        if (other.gameObject.name == "desk")
        { //충돌 오브젝트가 아이템일때
            print("도착");
            if(itemCount==6)
            {
                SceneManager.LoadScene(3);
            }

        }
    }
    private void LastScene()
    {
        SceneManager.LoadScene(1);
    }
    private void LastScene5()
    {
        SceneManager.LoadScene(5);
    }
    /*    private void FinishScene()
        {
            SceneManager.LoadScene(1);
        }*/

    
}
