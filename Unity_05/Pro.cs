using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pro : MonoBehaviour
{

    /*private float time;
    public Text timeText;
    // 플레이어 트랜스폼
    Transform player;
    // 캐릭터 콘트롤러 컴포넌트
    CharacterController cc;

    // 에너미 상태 상수
    enum EnemyState
    {
        Idle,
        Move,
        Return
    }
    // Start is called before the first frame update
    void Start()
    {
        // 최초의 에너미 상태는 대기로 한다.
        m_State = EnemyState.Idle;
        // 플레이어의 트랜스폼 컴포넌트 받아오기
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
        // 만일, 플레이어와의 거리가 액션 시작 범위 이내라면 Move 상태로 전환한다.
        if (time > 10)
        {
            m_State = EnemyState.Move;
            print("상태 전환: Idle -> Move");
        }
    }

    void Move()
    {
        time = 0;
        print("교수님회전!");

        if (time > 5)
        {
            m_State = EnemyState.Return;
            print("상태 전환: Move -> Return");
        }
    }

    void Return()
    {
        time = 0;
        m_State = EnemyState.Idle;
        print("상태 전환: Return -> Idle");
    }*/
}
