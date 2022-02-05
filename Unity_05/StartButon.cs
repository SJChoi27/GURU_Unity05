using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButon : MonoBehaviour
{
    public GameObject other1;
    public GameObject other2;
    public Transform other7;
    /*public Button btn;

    private void Start()
    {
        btn.onClick.AddListener(startgo);
    }*/
    // Start is called before the first frame update
    public void OnClickButton()
    {
        SceneManager.LoadScene(0);
    }
    public void OnClickButton_jump()
    {
        SceneManager.LoadScene(2);
    }
    public void OnClickButton1()
    {
        Time.timeScale = 0;
        Application.Quit();
    }
    public void OnClickButton0()
    {
        other1.gameObject.SetActive(false);
    }

    public void OnClickinfoButn()
    {
        other2.gameObject.SetActive(false);
        other7.gameObject.SetActive(true);
    }
}
