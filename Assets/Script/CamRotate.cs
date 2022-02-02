using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CamRotate : MonoBehaviour
{

    public float rotSpeed = 2f; // 회전 속도 변수

    // 회전 값 변수
    float mx = 0;
    float my = 0;

    void Update()
    {
/*        if (GameManager.gm.gState != GameManager.GameState.Run) // 게임 상태가 ‘게임 중’ 상태일 때만 조작할 수 있게 한다.
        {
            return;
        }*/
        // 사용자의 마우스 입력을 받아 물체를 회전시키고 싶다.
        float mouse_X = Input.GetAxis("Mouse X");// 1. 마우스 입력을 받는다.
        float mouse_Y = Input.GetAxis("Mouse Y");//float input.GetAxis (string axisName) --> axis 값 반환

        mx += mouse_X * rotSpeed * Time.deltaTime; // 1-1 회전 값 변수에 마우스 입력 만큼 누적시킨다.
        my += mouse_Y * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90f); // 1-2 마우스 상하 이동 회전(my)의 값을 제한

        transform.eulerAngles = new Vector3(-my, mx, 0); // 2. 물체를 회전 방향으로 회전시킨다.


    }
}


