using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaPadre : MonoBehaviour
{
    [SerializeField]
    private VerificadorZona verificador;
    [SerializeField]
    private GameObject puerta;
    private bool zonaTerminada;
    [SerializeField]
    private GameObject trofeo;
    [SerializeField]
    private GameObject acertijo;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private Collider2D interaccion;
    [SerializeField]
    private GameObject capa;

    private bool entro = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!zonaTerminada && verificador.zonaResuelta)
        {
            acertijo.gameObject.SetActive(true);
            interaccion.enabled = true;
            zonaTerminada = true;
        }
        if (entro && Input.GetKeyDown(KeyCode.E))
        {
            entro = false;
            puerta.SetActive(false);
            capa.GetComponent<LlenarLobby>().llenarPadre();
            interaccion.enabled = false;
            trofeo.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canvas.gameObject.SetActive(true);
        entro = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.gameObject.SetActive(false);
        entro = false;
    }
}
