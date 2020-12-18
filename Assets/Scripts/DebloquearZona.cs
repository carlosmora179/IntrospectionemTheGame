using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebloquearZona : MonoBehaviour
{
    [SerializeField]
    private VerificadorZona verificador;
    [SerializeField]
    private Collider2D collider;
    private bool zonaTerminada;
    [SerializeField]
    private GameObject trofeo;
    // Start is called before the first frame update
    void Start()
    {
        zonaTerminada = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!zonaTerminada && verificador.zonaResuelta) {
            collider.enabled = false;
            zonaTerminada = true;
            trofeo.gameObject.SetActive(true);
        }
    }
}
