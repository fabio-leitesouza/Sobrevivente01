using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeZumbi : MonoBehaviour
{
    public GameObject Zumbi;
    private float contadorTempo = 0;
    public float TempoGerarZumbi = 1;
    public LayerMask LayerZumbi; // para nao gerar zumbi em cima de outro     

    void Update()
    {
        contadorTempo += Time.deltaTime;
        if (contadorTempo >= TempoGerarZumbi)
        {
            GerarNovoZumbi();
            contadorTempo = 0;
        }

    }
    void GerarNovoZumbi()
    {
        Vector3 posicaoCriarZumbi = posicionAleatoria(); // posicao aleatoria para criar zumbi
        Collider[] colisores = Physics.OverlapSphere(posicaoCriarZumbi, 1, LayerZumbi); // para nao criar zumbi em cima de outro
        if (colisores.Length > 0)
        {
            posicaoCriarZumbi = posicionAleatoria(); // posicao aleatoria para criar zumbi
            colisores = Physics.OverlapSphere(posicaoCriarZumbi, 1, LayerZumbi); // para nao criar zumbi em cima de outro
        }
        Instantiate(Zumbi, posicaoCriarZumbi, transform.rotation); // transform.rotation = rotacao do gerador de zumbi
    }
    Vector3 posicionAleatoria()
    {
        Vector3 posicao = Random.insideUnitSphere * 20; // dentro de uma esfera de raio 20
        posicao += transform.position; // posicao do gerador de zumbi
        posicao.y = transform.position.y; // para nao gerar zumbi voando
        return posicao;
    }
}
