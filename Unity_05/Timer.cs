using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour
{
    PlayerMove script;
    HeartManager script2;
    Rigidbody2D rigid;
/*    private bool isCrouch = false;
    private float applySpeed;
    private float crouchSpeed;
    private float walkSpeed;
    // 앉았을 때 얼마나 앉을지 결정하는 변수
    private float crouchPosY;
    private float originPosY;
    private float applyCrouchPosY;
    private Camera theCamera;*/
    //private Rigidbody professor;
    Transform professor;
    public bool proturn=false;
    float time = 0;
    private void Awake()
    {
        script = GameObject.Find("Player").GetComponent<PlayerMove>();
        script2 = GameObject.Find("Player").GetComponent<HeartManager>();
    }
    void Start()
    {
        proturn = false;
        //앉기 초기화
        //originPosY = theCamera.transform.localPosition.y;
        //applyCrouchPosY = originPosY;
    }
    /*    private void TryCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
    }
    // 앉기 동작
    private void Crouch()
    {
        isCrouch = !isCrouch;
        if (isCrouch)
        {
            applySpeed = crouchSpeed;
            applyCrouchPosY = crouchPosY;
        }
        else
        {
            applySpeed = walkSpeed;
            applySpeed = walkSpeed;
            applyCrouchPosY = originPosY;
        }

        StartCoroutine(CrouchCoroutine());
    }
    // 부드러운 앉기 동작
    IEnumerator CrouchCoroutine()
    {
        float _posY = theCamera.transform.localPosition.y;
        int count = 0;

        while (_posY != applyCrouchPosY)
        {
            count++;
            _posY = Mathf.Lerp(_posY, applyCrouchPosY, 0.2f);
            theCamera.transform.localPosition = new Vector3(0, _posY, 0);
            if (count > 15)
                break;
            yield return null;
        }
        theCamera.transform.localPosition = new Vector3(0, applyCrouchPosY, 0);
    }*/


    void Update()
    {
        time += Time.deltaTime;

        if (time > 6)
        {
           
            proturn = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
            time = 0;
            script.a = 0;
            script.moveSpeed = 3f;
        }
        else if (time > 3)
        {
            check();
            //yield return new WaitForSeconds(3);
            //yield return null;
            //yield return new WaitForEndOfFrame();
        }

/*        if (script.a == 1)
        {
            print("감소");
            script2.hp -= 1;
        }*/

        //else if (time < 3)
        //{
        //    transform.eulerAngles = new Vector3(0, 0, 0);
        //}

    }

    void check()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
        proturn = true;
        print("ㅇㅇ");
/*        if(turn)
        {
            if(//앉는키를 누른다면)
                {
                //pass
            }
            else
            {
                //하트하나 사망
            }
        }*/
        
    }

    
    /*    float LimitTime = 0;
        Transform Professor;
        CharacterController cc;

        // 에너미 상태 상수
        enum ProState
        {
            Idle,
            Move,
            Return
        }

        ProState m_State;

        // Start is called before the first frame update
        void Start()
        {
            // 최초의 에너미 상태는 대기로 한다.
            m_State = ProState.Idle;
            // 플레이어의 트랜스폼 컴포넌트 받아오기
            Professor = GameObject.Find("Professor").transform;
        }

        // Update is called once per frame
        void Update()
        {
            LimitTime += Time.deltaTime;
            switch (m_State)
            {
                case ProState.Idle:
                    Idle();
                    break;
                case ProState.Move:
                    Move();
                    break;
                case ProState.Return:
                    Return();
                    break;
            }
        }

        void Idle()
        {
            // 만일, 플레이어와의 거리가 액션 시작 범위 이내라면 Move 상태로 전환한다.
            if (LimitTime == 3)
            {
                m_State = ProState.Move;
                print("상태 전환: Idle -> Move");
            }
        }

        void Move()
        {
            print("교수님회전!");

            m_State = ProState.Return;
            print("상태 전환: Move -> Return");
        }

        void Return()
        {
            LimitTime = 3;
            m_State = ProState.Idle;
            print("상태 전환: Return -> Idle");
        }*/
}
