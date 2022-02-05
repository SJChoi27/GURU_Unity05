using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Payer2 : MonoBehaviour
{
    public float moveSpeed = 3f; // �̵� �ӵ� ����
    CharacterController cc; // ĳ���� ��Ʈ�ѷ� ����
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

    float gravity = -20f; // �߷� ����
    float yVelocity = 0; // ���� �ӷ� ����

    //������ ����ϴ� ������
    public float jumpPower = 10f; // ������ ����
    public bool isJumping = false; // ���� ���� ����
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
        cc = GetComponent<CharacterController>(); // ĳ���� ��Ʈ�ѷ� ������Ʈ �޾ƿ���
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
        if(itemCount==6)
        {
            gameText.color = new Color32(255, 185, 0, 255);
            gameText.text = "�ȳ�����ũ�� �̵��϶�";
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
        { //�浹 ������Ʈ�� �������϶�
            itemCount++; // ���� �ø��� 
            other.gameObject.SetActive(false); //������ ��Ȱ��ȭ 
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
        { //�浹 ������Ʈ�� �������϶�
            itemCount++; // ���� �ø��� 
            other.gameObject.SetActive(false); //������ ��Ȱ��ȭ 
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
        { //�浹 ������Ʈ�� �������϶�
            itemCount++; // ���� �ø��� 
            other.gameObject.SetActive(false); //������ ��Ȱ��ȭ 
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
        { //�浹 ������Ʈ�� �������϶�
            print("����");
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
