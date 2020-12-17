using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoPuzzle : MonoBehaviour
{
    public bool resuelto = false;
    private bool isEnter = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        isEnter = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnter)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                resuelto = true;
                Debug.Log("Puzzle resuelto");
            }
        }
    }
}
