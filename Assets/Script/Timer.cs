using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
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


    void Start()
    {
        //�ɱ� �ʱ�ȭ
        //originPosY = theCamera.transform.localPosition.y;
        //applyCrouchPosY = originPosY;

        StartCoroutine(Example());
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
    IEnumerator Example()
    {
        while (true)
        {
            Debug.Log("3�ʸ��� ȸ��");
            proturn = true;
            check();
            yield return new WaitForSeconds(3);
            transform.eulerAngles = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(3);
        }
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
