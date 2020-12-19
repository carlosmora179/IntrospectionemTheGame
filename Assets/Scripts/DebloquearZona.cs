using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebloquearZona : MonoBehaviour
{
    [SerializeField]
    private VerificadorZona verificador;
    [SerializeField]
    private GameObject puerta;
    private bool zonaTerminada;
    [SerializeField]
    private GameObject trofeo;
    [SerializeField]
    private GameObject capa;
    // Start is called before the first frame update
    void Start()
    {
        zonaTerminada = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!zonaTerminada && verificador.zonaResuelta) {
            puerta.SetActive(false);
            zonaTerminada = true;
            trofeo.gameObject.SetActive(true);
            capa.GetComponent<LlenarLobby>().limpiarLobby();
        }
    }
}
