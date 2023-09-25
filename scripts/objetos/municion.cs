using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class municion : MonoBehaviour
{
    public GameObject muni;
    public float tiemreap = 0;
    public bool activado;
    public float tiempomax = 30;
    public conperso modperso1;
    public conperso modperso2;
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
            muni.SetActive(true);
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
                    muni.SetActive(false);
                    tiemreap = tiempomax;
                    activado = false;
                    modperso1.muni = modperso1.maxmuni;
                }

                if (other.gameObject.name == "player2")
                {
                    muni.SetActive(false);
                    tiemreap = tiempomax;
                    activado = false;
                    modperso2.muni = modperso2.maxmuni;
                }
            }
        }
    }
}
