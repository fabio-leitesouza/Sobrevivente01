using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour
{
    public GameObject Player;
    public float Velocidade = 5;
    private Vector3 posicaoAleatoria; // para o zumbi andar aleatoriamente
    private Vector3 direcao; // para o zumbi andar aleatoriamente
    private float contadorVagar; // para o zumbi andar aleatoriamente
    private float tempoNovaPosicaoAleatoria = 4; // para o zumbi andar aleatoriamente

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Player.transform.position);
        

        if (distancia > 15)
        {
            Vagar();
        }
        else
        {
            direcao = Player.transform.position - transform.position; // direcao para onde o zumbi vai andar

            Quaternion novaRotacao = Quaternion.LookRotation(direcao);
            GetComponent<Rigidbody>().MoveRotation(novaRotacao);

            Vector3 direcaoMovimento = Player.transform.position - transform.position;
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position +
                (direcaoMovimento.normalized * Velocidade * Time.deltaTime));

            if (distancia > 3.5)
            {
                GetComponent<Animator>().SetBool("Ataque", false);
            }
            else
            {
                GetComponent<Animator>().SetBool("Ataque", true);
            }
        }
        void Vagar()
        {
            contadorVagar -= Time.deltaTime;
            if (contadorVagar <= 0)
            {
                posicaoAleatoria = AleatoriarDirecao();
                contadorVagar += tempoNovaPosicaoAleatoria;
            }

            bool ficouPertoOSuficiente = Vector3.Distance(transform.position, posicaoAleatoria) <= 0.05;
            if (ficouPertoOSuficiente == false)
            {
                direcao = posicaoAleatoria - transform.position; // direcao para onde o zumbi vai andar
                GetComponent<Rigidbody>().MovePosition
                (GetComponent<Rigidbody>().position +
                (direcao.normalized * Velocidade * Time.deltaTime));
                GetComponent<Animator>().SetBool("Ataque", false);
            }
            else
            {
                contadorVagar = 0;
            }

        }
        Vector3 AleatoriarDirecao()
        {
            Vector3 posicao = Random.insideUnitSphere * 20; // dentro de uma esfera de raio 20
            posicao += transform.position; // para nao ficar dentro do zumbi
            posicao.y = transform.position.y; //mantem a altura

            return posicao; // retorna a posicao aleatoria
        }
    }
    void AtacaJogador()
    {
        int dano = Random.Range(20, 30);
        ControlaJogador playerScript = Player.GetComponent<ControlaJogador>();
        playerScript.TomarDano(dano);
    }
}
