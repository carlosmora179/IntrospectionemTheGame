using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Loader : MonoBehaviour
{
    // Start is called before the first frame updatepublic void LoadNextLevel(){

    public Animator transition;

    public float transitionTime = 5f;

 
    

     public void LoadLevel1(){

        if(SceneManager.GetActiveScene().buildIndex == 7){
            StartCoroutine(LoadLevel(0));

        }
        else{

            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        
         


    }
    IEnumerator LoadLevel(int levelIndex){
        //play
            transition.SetTrigger("Jugar");
        //wait
        yield return new WaitForSeconds(transitionTime );

        //load Scene
        SceneManager.LoadScene(levelIndex);


    }

}
