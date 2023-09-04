using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaBala : MonoBehaviour
{
    public GameObject Bala;
    public GameObject CanoDaArma;
    public AudioClip SomDeTiro; // Audio de tiro
    // Start is called before the first frame update
    
    void Update()
    {
        if (Input.GetButtonDown ("Fire1"))
        {
            Instantiate(Bala, CanoDaArma.transform.position, CanoDaArma.transform.rotation);
            ControlaAudio.instance.PlayOneShot(SomDeTiro); // Toca o som de tiro
        }
    }
}
