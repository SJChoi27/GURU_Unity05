using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CamRotate : MonoBehaviour
{

    public float rotSpeed = 2f; // ȸ�� �ӵ� ����

    // ȸ�� �� ����
    float mx = 0;
    float my = 0;

    void Update()
    {
/*        if (GameManager.gm.gState != GameManager.GameState.Run) // ���� ���°� ������ �ߡ� ������ ���� ������ �� �ְ� �Ѵ�.
        {
            return;
        }*/
        // ������� ���콺 �Է��� �޾� ��ü�� ȸ����Ű�� �ʹ�.
        float mouse_X = Input.GetAxis("Mouse X");// 1. ���콺 �Է��� �޴´�.
        float mouse_Y = Input.GetAxis("Mouse Y");//float input.GetAxis (string axisName) --> axis �� ��ȯ

        mx += mouse_X * rotSpeed * Time.deltaTime; // 1-1 ȸ�� �� ������ ���콺 �Է� ��ŭ ������Ų��.
        my += mouse_Y * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90f); // 1-2 ���콺 ���� �̵� ȸ��(my)�� ���� ����

        transform.eulerAngles = new Vector3(-my, mx, 0); // 2. ��ü�� ȸ�� �������� ȸ����Ų��.


    }
}


