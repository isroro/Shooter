using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class condisparo : MonoBehaviour
{
    public InputAction movimiento;
    public InputAction apuntar;
    public InputAction disparar;

    Rigidbody rb;
    Animator anim;

    public Transform apuntarRef;

    public float fuerzaDisparo;
    public float velocidad;
    public float velgiro;
    public float cooldown = 0;
    public float cooldownInicial = 3;
    public float giroLateral;
    public float giroVertical;
    // Start is called before the first frame update
    void Start()
    {

        apuntar.Enable();
        movimiento.Enable();
        disparar.Enable();
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("inicio");
        }
        Vector2 mimov = movimiento.ReadValue<Vector2>();
        Vector3 movfinal;
        movfinal = transform.forward * mimov.y;
        movfinal += transform.right * mimov.x;
        movfinal *= velocidad;
        movfinal.y += rb.velocity.y;
        rb.velocity = movfinal;

        giroLateral = Mouse.current.delta.x.ReadValue();
        giroVertical = Mouse.current.delta.y.ReadValue();

        giroLateral *= velgiro;
        giroVertical *= velgiro;

        transform.Rotate(0, giroLateral, 0);
        apuntarRef.transform.Rotate(-giroVertical, 0, 0);

        Debug.DrawRay(apuntarRef.position, apuntarRef.forward * 10, Color.blue);
        if(disparar.triggered /*&& cooldown <= 0*/)
        {
            cooldown = cooldownInicial;

            Ray rayo = new Ray(apuntarRef.position, apuntarRef.forward * 10);

            RaycastHit rayoimpacto;

            bool haimpactado = Physics.Raycast(rayo, out rayoimpacto);
            if (rayoimpacto.rigidbody != null && haimpactado)
            {
                rayoimpacto.rigidbody.AddForceAtPosition(apuntarRef.forward * fuerzaDisparo, rayoimpacto.point,ForceMode.Impulse);
            }
        }
        cooldown -= Time.deltaTime;
        if (cooldown < 0) cooldown = 0;
        anim.SetFloat("velocidadFrontal", mimov.y);
        anim.SetFloat("velocidadLateral", mimov.x);
    }
}
