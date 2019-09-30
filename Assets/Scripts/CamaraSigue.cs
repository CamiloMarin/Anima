using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSigue : MonoBehaviour
{
    public Transform objetivo;
    public float suavizado = 5f;
    Vector3 desface;

    void Start()
    {
        // se crea un desface que lo que hace es restarle la posicion de la camara a la posicion del objeto 
        desface = transform.position - objetivo.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 posicionOBjetivo = objetivo.position + desface;
        transform.position = Vector3.Lerp(transform.position, posicionOBjetivo, suavizado * Time.deltaTime);
    }
}
