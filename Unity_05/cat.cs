using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    public Camera getCamera;
    public GameObject other;
    int get = 0;
    // Start is called before the first frame update
    void Start()
    {
        other.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.name == "cat")
                {
                    other.gameObject.SetActive(true);
                }
                /*get++;
                if(get>1)
                {
                    other.gameObject.SetActive(true);
                }*/
                //print("get");
                //other.gameObject.SetActive(true);
            }
        }
/*        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
            if(hit.transform.gameObject.tag == "cat")
            {
                print("cat");
            }*/
    }
}
