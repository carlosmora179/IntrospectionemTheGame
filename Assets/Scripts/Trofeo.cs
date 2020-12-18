using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trofeo : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    private bool isEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnter && Input.GetKeyDown(KeyCode.E)) 
        {
            transform.position = new Vector3(0,0,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canvas.gameObject.SetActive(true);
        isEnter = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isEnter = false;
        canvas.gameObject.SetActive(false);
    }
}
