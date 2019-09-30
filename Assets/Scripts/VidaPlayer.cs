using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{

    public GameObject Animation;
    // Animation es un parametro de la animación de muerte.

    public float vida
    {


        // se asigna el valor de vida 
        get { return _vida; }
        set
        {
            _vida = value;
            if (_vida <= 0.0)
            {
                if (Animation != null)
                {
                    Instantiate(Animation, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField]

    private float _vida = 100.0f;
}
