using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditosController : MonoBehaviour
{

    public GameObject o1,o2,o3,o4;

    bool mostrando = false;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(loadCredits(8f));
       
    }
  void Update() {

    if(!mostrando){
      SceneManager.LoadScene(0);
    }
    
  }

    IEnumerator loadCredits( float transitionTime)
  {
       mostrando = true;
       
       o1.gameObject.SetActive(true);
       yield return new WaitForSeconds(5f);
       o1.gameObject.SetActive(false);
       o2.gameObject.SetActive(true);
       yield return new WaitForSeconds(5f);
       o2.gameObject.SetActive(false);
       o3.gameObject.SetActive(true);
       yield return new WaitForSeconds(transitionTime);
       o3.gameObject.SetActive(false);
       o4.gameObject.SetActive(true);
       yield return new WaitForSeconds(5f);
       o4.gameObject.SetActive(false);
       yield return new WaitForSeconds(3f);
       
       mostrando = false;
  }
}
