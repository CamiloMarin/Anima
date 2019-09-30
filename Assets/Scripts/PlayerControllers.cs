using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour

{
    // Velocidad del personaje default
    public float speed = 2f;
    public float maxSpeed = 5f;
    public float jumpPower = 6.5f;
    public bool grounded;
    // Fuerza al objeto Rigidbody (cuanta fueza se le va aplicar al objeto)
    private Rigidbody2D rb2d;
    private bool jump;
    private Animator anim;
    private SpriteRenderer spr;

    void Start()
    {
        // detecta el componente cuando se inicia el nivel
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        // Acciona la tecla para saltar una sola vez
        if (Input.GetKeyDown(KeyCode.Space)&&grounded)
        {
            jump = true;
        }
        //asigna la velocidad en el animador y con una funcion absoluta de la libreria Math ayuda a buscar el valor positivo que siempre tendra en X
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);

    }

    

    void FixedUpdate()
    {
        // Vector horizontal, y parametros que añaden la fuerza + la velocidad + la dirección
        float h = Input.GetAxis("Horizontal");
        rb2d.AddForce(Vector2.right * speed * h);
        // mira si la velocidad en x cuando se ejecuta el juego es mayor que la velocidad maxisma
        // Acelearción y desaceleración Toma la variable de un numero y le da un filtro (max y min)
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
        // Direccion de los sprites

        if (h < 0)
        {
            spr.flipX = true;
        }

        else if (h > 0)
        {
            spr.flipX = false;
        }
        
            
            // Fuerza del salto

            if (jump)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
        
        
        

    }

   
}

