using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �߰�

public class MapManager : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        gameObject.transform.position = GameObject.Find("���ϴ¿�����Ʈ").transform.position;
        if (collider.gameObject.name == "Door") // �ش� ������ �±׷� �ϼŵ��ǰ� ���Ͻô� ���
        {
            gameObject.transform.position = new Vector3(0,0, 68);
        }
    }
}
