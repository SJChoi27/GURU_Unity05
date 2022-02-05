using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeartManager : MonoBehaviour
{
    public int hp = 3;

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public Transform other;
    public Transform other3;
    public Transform other4;
    // Use this for initialization
    void Start()
    {
        life1.GetComponent<Image>().enabled = true;
        life2.GetComponent<Image>().enabled = true;
        life3.GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (hp)
        {
            case 2:
                print("d");
                life3.GetComponent<Image>().enabled = false;
                break;
            case 1:
                print("dd");
                life2.GetComponent<Image>().enabled = false;
                break;
            case 0:
                print("dd");
                life1.GetComponent<Image>().enabled = false;
                gameover();
                break;
        }
    }
    private void gameover()
    {
        SceneManager.LoadScene(4);
        other3.gameObject.SetActive(false);
        other4.gameObject.SetActive(false);
    }
}
