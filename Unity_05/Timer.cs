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
    // �ɾ��� �� �󸶳� ������ �����ϴ� ����
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
        //�ɱ� �ʱ�ȭ
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
    // �ɱ� ����
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
    // �ε巯�� �ɱ� ����
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
            print("����");
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
        print("����");
/*        if(turn)
        {
            if(//�ɴ�Ű�� �����ٸ�)
                {
                //pass
            }
            else
            {
                //��Ʈ�ϳ� ���
            }
        }*/
        
    }

    
    /*    float LimitTime = 0;
        Transform Professor;
        CharacterController cc;

        // ���ʹ� ���� ���
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
            // ������ ���ʹ� ���´� ���� �Ѵ�.
            m_State = ProState.Idle;
            // �÷��̾��� Ʈ������ ������Ʈ �޾ƿ���
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
            // ����, �÷��̾���� �Ÿ��� �׼� ���� ���� �̳���� Move ���·� ��ȯ�Ѵ�.
            if (LimitTime == 3)
            {
                m_State = ProState.Move;
                print("���� ��ȯ: Idle -> Move");
            }
        }

        void Move()
        {
            print("������ȸ��!");

            m_State = ProState.Return;
            print("���� ��ȯ: Move -> Return");
        }

        void Return()
        {
            LimitTime = 3;
            m_State = ProState.Idle;
            print("���� ��ȯ: Return -> Idle");
        }*/
}
