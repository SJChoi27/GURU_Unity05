using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject player;
    public Transform[] playerSpawnPoints;

    void Start()
    {
        RandomSelectSpawnPoint();
    }

    void RandomSelectSpawnPoint()
    {
        int number = Random.Range(0, playerSpawnPoints.Length);
        player.transform.position = playerSpawnPoints[number].transform.position;
    }

    //매 시작 시 플레이어 스폰 포인트를 랜덤하게 하나 선택
    //해당 위치를 플레이어 위치로 변경

}