using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// este script nos sirve para solucionar un problema con el piso 
// o las plataformas del juego, dado que el objeto personaje podia saltar indefinidamente.
// Este script nos ayuda a detectar con una chapa o un tag si lo que esta tocando es un suelo o no,
// si no está tocando un suelo, la funsion de la tecla de salto es falsa. Y si el jugador si esta tocando el suelo entonces la 
//funsion de la tecla de salto será verdadera...


public class CheckGround : MonoBehaviour
{
    private PlayerControllers player;
    void Start()
    {
        player = GetComponentInParent<PlayerControllers>();

    }

    // Update is called once per frame
    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "grounded")
        {
          player.grounded = true;
        }
        
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "grounded")
        {
            player.grounded = false;
        }
        
    }

}
