using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleEspada : MonoBehaviour
{
    public GameObject Espada;
    public GameObject Mao;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown ("Fire1"))
        {
            Instantiate(Espada, Mao.transform.position, Mao.transform.rotation);
        }
    }
}
