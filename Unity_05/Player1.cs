using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    public float moveSpeed = 3f; // �̵� �ӵ� ����
    CharacterController cc; // ĳ���� ��Ʈ�ѷ� ����


    float gravity = -20f; // �߷� ����
    float yVelocity = 0; // ���� �ӷ� ����

    //������ ����ϴ� ������
    public float jumpPower = 10f; // ������ ����
    public bool isJumping = false; // ���� ���� ����
    //public int itemCount;
    //public Text gameText;
    Animator anim;



    private void Start()
    {
        cc = GetComponent<CharacterController>(); // ĳ���� ��Ʈ�ѷ� ������Ʈ �޾ƿ���

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
 /*       if (itemCount == 6)
        {
            gameText.color = new Color32(255, 185, 0, 255);
            gameText.text = "Clear!";
            Destroy(gameText, 5);
            Invoke("LastScene", 3);
        }*/
    }
 /*   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "item")
        { //�浹 ������Ʈ�� �������϶�
            itemCount++; // ���� �ø��� 
            other.gameObject.SetActive(false); //������ ��Ȱ��ȭ 

        }
    }
    private void LastScene()
    {
        SceneManager.LoadScene(1);
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "goal")
        { //�浹 ������Ʈ�� �������϶�
            SceneManager.LoadScene(0);

        }
    }

}
