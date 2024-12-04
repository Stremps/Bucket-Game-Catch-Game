using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    
    void OnCollisionEnter(Collision other) {
        // Ensure game is active
        if(!GameManager.Instance.isGameActive){
            Destroy(other.gameObject);
            return; // Trava o update aqui, não passa daqui
        }
        
        if(other.gameObject.CompareTag("Ball")){
            Destroy(other.gameObject);
            return;
        }

        if(other.gameObject.CompareTag("life Ball")){	
            // Decreases player life
            GameManager.Instance.gameLifes--;

            Debug.Log("You lost life!\nLife: "+ GameManager.Instance.gameLifes);

            // Destroy object
            Destroy(other.gameObject);
            
            // Verify if the game life is zero
            if( GameManager.Instance.gameLifes <= 0){
                // End Game
                GameManager.Instance.isGameActive  = false;

                // End Game message
                Debug.Log("Game Over! :(");
            }
        }
    }
}
