using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{
    //public GameObject Target;
    float rotSpeed = 4f;
    // Update is called once per frame
    void Update()
    {
        //Quaternion targetRot = Quaternion.LookRotation(Target.transform.position);

        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * 5);
        //transform.LookAt(Target.transform);
        float MouseX = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up * rotSpeed * MouseX);
    }
}
