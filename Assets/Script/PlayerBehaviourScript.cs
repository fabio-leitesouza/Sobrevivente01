using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    public float Velocidade = 8;
    Vector3 direcao;

    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        if(direcao != Vector3.zero){
            GetComponent<Animator>().SetBool("Correndo", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Correndo", false);
        }    
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition
            (GetComponent<Rigidbody>().position + 
            (direcao * Time.deltaTime * Velocidade));
    }
}
