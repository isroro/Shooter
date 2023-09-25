using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botiquin : MonoBehaviour
{
    public GameObject boti;
    public conperso modperso1;
    public conperso modperso2;
    public float tiemreap = 0;
    public bool activado;
    public float tiempomax = 60;
    // Start is called before the first frame update
    void Start()
    {
        activado = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (tiemreap > 0)
        {
            tiemreap -= Time.deltaTime;
        }
        else
        {
            boti.SetActive(true);
            activado = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (activado == true)
            {
                if (other.gameObject.name == "player1")
                {
                    boti.SetActive(false);
                    tiemreap = tiempomax;
                    activado = false;
                    modperso1.vida =modperso1.maxvida;
                }
                if (other.gameObject.name == "player2")
                {
                    boti.SetActive(false);
                    tiemreap = tiempomax;
                    activado = false;
                    modperso2.vida = modperso2.maxvida;
                }
            }
        }
    }
}
