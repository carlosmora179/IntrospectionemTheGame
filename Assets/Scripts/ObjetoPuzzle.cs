using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoPuzzle : MonoBehaviour
{
    public int keyId;
    public bool resuelto = false;
    public GameObject canvas;
    public Collider2D collider;

    private Player player;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if (player.inTrigger && Input.GetKey(KeyCode.E) && !isOpen)
            {
                isOpen = true;
                canvas.SetActive(false);
                player.AbrirInventario();
            }
            int idItem = player.inventario.GetComponentInChildren<Inventario>().getSelected();
            if (isOpen && idItem == keyId)
            {
                Debug.Log("Puzzle resuelto");
                resuelto = true;
                player.inTrigger = false;
                player = null;
                canvas.gameObject.SetActive(false);
                collider.enabled = false;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canvas.gameObject.SetActive(true);
        player = collision.GetComponent<Player>();
        player.inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.gameObject.SetActive(false);
        collision.GetComponent<Player>().inTrigger = false;
        player = null;
        isOpen = false;
    }
}
