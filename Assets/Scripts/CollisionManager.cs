using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if(!GameManager.Instance.isGameActive){
            return; // Trava o update aqui, não passa daqui
        }

        if(other.gameObject.CompareTag("life Ball")){
            GameManager.Instance.score+=2; // Instance por conta de ser um singleton
            Debug.Log("Score: " + GameManager.Instance.score);

            //Destroy the other object
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Ball")){
            // Increment score
            GameManager.Instance.score+=1; // Instance por conta de ser um singleton
            Debug.Log("Score: " + GameManager.Instance.score);
            
            //Destroy the other object
            Destroy(other.gameObject);
            // Debug.Log("Colisão com a bolinha!");
        } 

        // Debug.Log("Detectado colisão com " + other.gameObject.name);
    }
}
