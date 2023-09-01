using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCamera : MonoBehaviour
{
    public GameObject player;
    Vector3 distanciaCameraPlayer;
    // Start is called before the first frame update
    void Start()
    {
        distanciaCameraPlayer = transform.position - player.transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + distanciaCameraPlayer;
    }
}
