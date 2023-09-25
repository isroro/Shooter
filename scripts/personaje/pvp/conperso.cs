using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class conperso : MonoBehaviour
{
    public InputAction movimiento;    //vector2
    public InputAction giro;          //1d neg and pos
    public InputAction disparar;      //blend
    public InputAction salto;         //blend

    Rigidbody rb;
    Animator anim;

    public Transform apuntarRef;      //posicion rayo disparo
    public Transform saltoRef;        //posicion rayo salto
    public conperso persomodenem;     //referencia al script del enemigo

    //variables
    //public float fuerzasalto;        
    public float velocidad;
    public float velgiro;
    public float cooldown = 0;
    public float cooldownInicial = 2;
    public float disp = 0;
    public float dispInicial = 0.25f;
    public int vida;
    public int maxvida = 100;
    public int muni;
    public int maxmuni = 20;
    public int puntos = 0;

    //variables para gui
    public TMP_Text municion;
    public TMP_Text canvida;
    public TMP_Text canpuntos;
    public Slider barravida;

    // Start is called before the first frame update
    void Start()
    {
        vida = maxvida;
        muni = maxmuni;
        giro.Enable();
        movimiento.Enable();
        disparar.Enable();
        //salto.Enable();
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //revivir
        if (vida <= 0)
        {
            vida = maxvida;
            persomodenem.puntos += 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("inicio");
        }
        //Movimiento
        float migiro = giro.ReadValue<float>();
        migiro *= velgiro;
        transform.Rotate(0, migiro, 0);
        Vector2 mimov = movimiento.ReadValue<Vector2>();
        Vector3 movfinal;
        movfinal = transform.forward * mimov.y;
        movfinal += transform.right * mimov.x;
        movfinal *= velocidad;
        movfinal.y += rb.velocity.y;
        rb.velocity = movfinal;

        

        //Disparo
        Debug.DrawRay(apuntarRef.position, apuntarRef.forward * 40, Color.blue);
        
        if (disparar.triggered && cooldown <= 0 && muni>0)
        {
            cooldown = cooldownInicial;

            disp = dispInicial;

            muni--;

            Ray rayo = new Ray(apuntarRef.position, apuntarRef.forward * 40);

            RaycastHit rayoimpacto;

            bool haimpactado = Physics.Raycast(rayo, out rayoimpacto);
            if(haimpactado==true && rayoimpacto.rigidbody != null)
            {
                persomodenem.vida -= 20;
            }
        }
        if (disp > 0)
        {
            cooldown -= Time.deltaTime;
            anim.SetBool("disparo", false);
        }

        if (disp <= 0)
        {
            cooldown = 0;
            anim.SetBool("disparo", true);
        }

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            anim.SetBool("tiempo", false);
        }
        
        if (cooldown <= 0) 
        { 
            cooldown = 0;
            anim.SetBool("tiempo", true);
        }

        //Salto
        /*Debug.DrawRay(saltoRef.position, saltoRef.forward * 10, Color.red);
        if (salto.triggered)
        {
            Ray rayosalto = new Ray(saltoRef.position, saltoRef.forward * 10);

            RaycastHit rayoimpacto;

            bool haimpactado = Physics.Raycast(rayosalto, out rayoimpacto);
            if (rayoimpacto.distance<=0.1)
            {
                rb.AddForce(0, fuerzasalto, 0, ForceMode.Impulse);
            }
        }
        */

        //Animaciones
        anim.SetFloat("velocidadFrontal", mimov.y);
        anim.SetFloat("velocidadLateral", mimov.x);
        //anim.SetBool("disparo", disparar.triggered);

        //GUI
        municion.text = muni + "/" + maxmuni;
        canvida.text = vida + "/" + maxvida;
        canpuntos.text = puntos + " bajas";
        barravida.value = vida;
    }
}
