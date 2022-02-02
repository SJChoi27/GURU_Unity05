using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f; // �̵� �ӵ� ����
    CharacterController cc; // ĳ���� ��Ʈ�ѷ� ����


    float gravity = -20f; // �߷� ����
    float yVelocity = 0; // ���� �ӷ� ����

    //������ ����ϴ� ������
    public float jumpPower = 10f; // ������ ����
    public bool isJumping = false; // ���� ���� ����
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
        cc = GetComponent<CharacterController>(); // ĳ���� ��Ʈ�ѷ� ������Ʈ �޾ƿ���

        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //TryCrouch();
        // Ű���� [W], [A], [S], [D] ��ư�� �Է��ϸ� ĳ���͸� �� �������� �̵���Ű�� �ʹ�
        float h = Input.GetAxis("Horizontal"); // 1. ������� �Է��� �޴´�.
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // 2. �̵� ������ �����Ѵ�.
        dir = dir.normalized;

        dir = Camera.main.transform.TransformDirection(dir); // 2-1. ���� ī�޶� �������� ������ ��ȯ�Ѵ�.

        transform.position += dir * moveSpeed * Time.deltaTime; // 3. �̵� �ӵ��� ���� �̵��Ѵ�, p = p0 + vt

        anim.SetFloat("MoveMotion", dir.magnitude);

        // �÷��̾ �߷� �����ϱ�
        yVelocity += gravity * Time.deltaTime; // 2-3. ĳ���� ���� �ӵ��� �߷� ���� �����Ѵ�.
        dir.y = yVelocity;
        cc.Move(dir * moveSpeed * Time.deltaTime); // 3. �̵� �ӵ��� ���� �̵��Ѵ�.
        //����                                                                                           
        // 2-2. ����, ���� ���̾���, �ٽ� �ٴڿ� �����ߴٸ�...
            
        if (isJumping && cc.collisionFlags == CollisionFlags.Below)   
        {
                // ���� �� ���·� �ʱ�ȭ�Ѵ�.
                isJumping = false;
                // ĳ���� ���� �ӵ��� 0���� �����.
                yVelocity = 0; 
        }
            // 2-3. ����, Ű���� [Spacebar] Ű�� �Է��߰�, ������ ���� ���� ���¶��...
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
                // ĳ���� ���� �ӵ��� �������� �����ϰ� ���� ���·� �����Ѵ�.
                yVelocity = jumpPower;
                isJumping = true;
        }
        if (script.proturn)
        {
                print("false");
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space))
                {
                    script2.hp -= 1;
                    print("��������");
                }
                script.proturn = false;
        } 
    }   
}
