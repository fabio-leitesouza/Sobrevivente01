using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviourScript : MonoBehaviour
{
    public float Velocidade = 10;
    CharacterController characterController;
    Vector3 direcao;
    public LayerMask MascaraChao;

    public GameObject TextoGameOver;
    public bool Vivo = true;
    public int Vida = 10;

    void Start()
    {
        Time.timeScale = 1;
        TextoGameOver.SetActive(false);
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        if (direcao != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("Movendo", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Movendo", false);
        }

        if (!Vivo)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("game");
            }
        }
    }

    void FixedUpdate()
    {
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;
        if (Physics.Raycast(raio, out impacto, 100, MascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            // posicaoMiraJogador.y = transform.position.y;
            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);
            transform.rotation = novaRotacao;
        }

        // Mova o jogador usando o CharacterController
        Vector3 movimento = direcao * Velocidade * Time.fixedDeltaTime;
        characterController.Move(movimento);
    }
}
