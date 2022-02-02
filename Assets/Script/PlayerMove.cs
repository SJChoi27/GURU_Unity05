using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f; // 이동 속도 변수
    CharacterController cc; // 캐릭터 콘트롤러 변수


    float gravity = -20f; // 중력 변수
    float yVelocity = 0; // 수직 속력 변수

    //점프에 사용하는 변수들
    public float jumpPower = 10f; // 점프력 변수
    public bool isJumping = false; // 점프 상태 변수
    Timer script;
    HeartManager script2;


    Animator anim;


    private void Awake()
    {
        script = GameObject.Find("Professor").GetComponent<Timer>();
        script2 = GameObject.Find("Player").GetComponent<HeartManager>();
    }

    private void Start()
    {
        cc = GetComponent<CharacterController>(); // 캐릭터 콘트롤러 컴포넌트 받아오기

        anim = GetComponentInChildren<Animator>();
    }

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
        if (script.proturn)
        {
                print("false");
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space))
                {
                    script2.hp -= 1;
                    print("움직였다");
                }
                script.proturn = false;
        } 
    }   
}
