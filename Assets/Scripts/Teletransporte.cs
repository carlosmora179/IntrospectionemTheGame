using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransporte : MonoBehaviour
{
    public GameObject target;
    [SerializeField]
    private AudioClip nuevoSonido = null;
    private AudioSource camara;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.position = target.transform.GetChild(0).transform.position;
            if (nuevoSonido != null)
            {
                camara = Camera.main.GetComponent<AudioSource>();
                camara.Stop();
                camara.clip = nuevoSonido;
                camara.Play();
            }
        }
    }
}
