using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3f; // �̵� �ӵ� ����
    CharacterController cc; // ĳ���� ��Ʈ�ѷ� ����


    float gravity = -20f; // �߷� ����
    float yVelocity = 0; // ���� �ӷ� ����

    //������ ����ϴ� ������
    public float jumpPower = 10f; // ������ ����
    public bool isJumping = false; // ���� ���� ����

    public Transform other2;
    public Transform other3;
    public Transform other4;
    public Transform other5;
    public Transform other6;
    public int a = 0;
    public int itemCount;

    Timer script;
    HeartManager script2;

    Animator anim;
    // ���� ���� UI ������Ʈ ����
    // ���� ���� UI �ؽ�Ʈ ������Ʈ ����
    public Text gameText;
    //public Text StartText;

    private void Awake()
    {
        script = GameObject.Find("Professor").GetComponent<Timer>();
        script2 = GameObject.Find("Player").GetComponent<HeartManager>();
    }

    private void Start()
    {
        cc = GetComponent<CharacterController>(); // ĳ���� ��Ʈ�ѷ� ������Ʈ �޾ƿ���

        anim = GetComponentInChildren<Animator>();
        //Destroy(StartText, 6);
    }
    /*    private void OncollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "door")
                transform.position = new Vector3(58, 1, 0);
        }*/
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
            //while(script.proturn) // 3�ʵ��� �� if���� ��� �����ؼ� �˻縦 �ް� ������ while������ �ϸ� ���ѹݺ��� �Ǵ��� ��������� ��ϴ�. �ذ��� �˷��ּ���.

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space))
            {
                moveSpeed = 0f;
                a += 1;
                if (a == 1)
                {
                    print("����");
                    script2.hp -= 1;
                }
                print("��������");
                
            }
        }
        /*void OnCollisionEnter(Collision myCollision)
        {
            if (myCollision.tag == goal)
                transform.position = nextPosition;
        }*/

    }
    void SecondScene()
    {
        SceneManager.LoadScene(2);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "item")
        { //�浹 ������Ʈ�� �������϶�
            itemCount++; // ���� �ø��� 
            other.gameObject.SetActive(false); //������ ��Ȱ��ȭ 
        }
        if (other.gameObject.name == "goal")
        { //�浹 ������Ʈ�� �������϶�
            gameText.color = new Color32(255, 185, 0, 255);
            gameText.text = "Clear!";
            Destroy(gameText, 4);
            other3.gameObject.SetActive(false);
            other4.gameObject.SetActive(false);
            other5.gameObject.SetActive(false);
            other6.gameObject.SetActive(false);
            Invoke("SecondScene", 3f);
        }
    }
}
