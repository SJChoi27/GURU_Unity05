using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finalbun : MonoBehaviour
{

    public GameObject other2;

    public void OnClickButton2()
    {
        other2.SetActive(false);
    }
    public void OnClickButton1()
    {
        Time.timeScale = 0;
        Application.Quit();
    }
}
