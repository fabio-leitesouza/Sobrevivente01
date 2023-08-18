using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeZumbi : MonoBehaviour
{
    public GameObject Zumbi;
    private float contadorTempo = 0;
    public float TempoGerarZumbi = 1;       

    void Update()
    {
        contadorTempo += Time.deltaTime;
        if(contadorTempo >= TempoGerarZumbi)
        {
            Instantiate(Zumbi, transform.position, transform.rotation);
            contadorTempo = 0;
        }
        
    }
}
