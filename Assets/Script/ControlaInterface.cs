using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaInterface : MonoBehaviour
{
    private ControlaJogador scriptControlaJogador;
    public Slider SliderVidaJogador;

    void Start()
    {
        scriptControlaJogador = GameObject.FindWithTag("Player").GetComponent<ControlaJogador>();
        SliderVidaJogador.maxValue = scriptControlaJogador.Vida;
        AtualizaSlideVidaJogador();
    }

    public void AtualizaSlideVidaJogador ()
    {
        SliderVidaJogador.value = scriptControlaJogador.Vida;
    }
}
