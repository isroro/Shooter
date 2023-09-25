using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject botoncontroles;
    public GameObject botoncontroles1;
    public GameObject botonjuego;
    public GameObject botonfisicas;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void controles()
    {
        SceneManager.LoadScene("controles");
    }
    public void controles1()
    {
        SceneManager.LoadScene("controlesfisicas");
    }
    public void pvp()
    {
        SceneManager.LoadScene("PvP");
    }
    public void fisicas()
    {
        SceneManager.LoadScene("fisicas");
    }
}
