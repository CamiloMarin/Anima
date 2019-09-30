using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 1f;
    public float maxSpeed = 1f;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.AddForce(Vector2.right * speed);
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        //Si el enemigo esta cerca de chochar con una superfie, cambia la velocidad. Para hacer ese cambio mas inmediato
        if (rb2d.velocity.x > -0.01 && rb2d.velocity.x < 0.01f)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
    }



}
