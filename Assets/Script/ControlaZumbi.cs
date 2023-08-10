using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour
{
    public GameObject Player;
    public float Velocidade = 5;
    
    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Player.transform.position);

        Vector3 direcaoJogador = Player.transform.position - transform.position;
        Quaternion novaRotacao = Quaternion.LookRotation(direcaoJogador);
        GetComponent<Rigidbody>().MoveRotation(novaRotacao);

        if(distancia > 0.2)
        {
             Vector3 direcao = Player.transform.position - transform.position;
            GetComponent<Rigidbody>().MovePosition
            (GetComponent<Rigidbody>().position + 
            (direcao.normalized * Velocidade * Time.deltaTime));
            GetComponent<Animator>().SetBool("Ataque", false); 
        }
        else
        {
            GetComponent<Animator>().SetBool("Ataque", true);
        }
       
    }
}
