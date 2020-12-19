using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlenarLobby : MonoBehaviour
{
    
    [SerializeField]
     GameObject danio0,danio1,danio2,danio3;
    // Start is called before the first frame update

    // Update is called once per frame

     public void limpiarLobby(){
         danio0.SetActive(false);
        danio1.SetActive(true);

    }
    public void llenarPadre(){
        danio2.SetActive(true);

    }
    public void llenarHermana(){
        danio3.SetActive(true);

    }
}
