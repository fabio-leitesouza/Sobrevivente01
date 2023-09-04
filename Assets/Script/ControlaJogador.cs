using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlaJogador : MonoBehaviour
{
    public float Velocidade = 10; // Velocidade de movimento
    private CharacterController characterController; // Componente CharacterController
    private Vector3 direcao;
    public LayerMask MascaraChao;

    public GameObject TextoGameOver;
    public int Vida = 100;
    public ControlaInterface scriptControlaInteface;
    public AudioClip SomDeDano; // Audio de dano
    public AudioClip SomDeMorte; // Audio de morte
    
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

        if (Vida <= 0)
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
    public void TomarDano (int dano)
    {
        Vida -= dano;
        scriptControlaInteface.AtualizaSlideVidaJogador();
       
       Toca o som de dano
        if (Vida <= 0)
            {
                ControlaAudio.instance.PlayOneShot(SomDeMorte); // Toca o som de morte
                Time.timeScale = 0;
                TextoGameOver.SetActive(true);
            }
    }
}
