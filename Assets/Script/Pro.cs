using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pro : MonoBehaviour
{

    /*private float time;
    public Text timeText;
    // �÷��̾� Ʈ������
    Transform player;
    // ĳ���� ��Ʈ�ѷ� ������Ʈ
    CharacterController cc;

    // ���ʹ� ���� ���
    enum EnemyState
    {
        Idle,
        Move,
        Return
    }
    // Start is called before the first frame update
    void Start()
    {
        // ������ ���ʹ� ���´� ���� �Ѵ�.
        m_State = EnemyState.Idle;
        // �÷��̾��� Ʈ������ ������Ʈ �޾ƿ���
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeText.text = string.Format("{0:N2}", time);

        EnemyState m_State;
        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Return:
                Return();
                break;
        }
    }

    void Idle()
    {
        // ����, �÷��̾���� �Ÿ��� �׼� ���� ���� �̳���� Move ���·� ��ȯ�Ѵ�.
        if (time > 10)
        {
            m_State = EnemyState.Move;
            print("���� ��ȯ: Idle -> Move");
        }
    }

    void Move()
    {
        time = 0;
        print("������ȸ��!");

        if (time > 5)
        {
            m_State = EnemyState.Return;
            print("���� ��ȯ: Move -> Return");
        }
    }

    void Return()
    {
        time = 0;
        m_State = EnemyState.Idle;
        print("���� ��ȯ: Return -> Idle");
    }*/
}
