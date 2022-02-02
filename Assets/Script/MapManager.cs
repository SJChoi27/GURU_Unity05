using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 추가

public class MapManager : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        gameObject.transform.position = GameObject.Find("원하는오브젝트").transform.position;
        if (collider.gameObject.name == "Door") // 해당 조건은 태그로 하셔도되고 원하시는 대로
        {
            gameObject.transform.position = new Vector3(0,0, 68);
        }
    }
}
