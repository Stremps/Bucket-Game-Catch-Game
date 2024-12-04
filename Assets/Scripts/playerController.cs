using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float Speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get input values
        bool isPressingLeft = Input.GetKey(KeyCode.LeftArrow); // Retorna true a tecla for apertada, e false enquanto não estiver
        bool isPressingRight = Input.GetKey(KeyCode.RightArrow);
        bool isPressingShift = Input.GetKey(KeyCode.LeftShift);
        // Debug.Log("Left: " + isPressingLeft + " Right: " + isPressingRight);

        // Abort if no keys are pressed, or both are pressed at the same time
        if(isPressingLeft == isPressingRight){
            return;
        }

        // Set the orientation
        float orientation = 1f;
        if(isPressingLeft){
            orientation*=-1f;
        }

        // Move player
        float movement = Speed * orientation * Time.deltaTime; // Movementa a velocidade de acordo com a direção e a velocidade do jogo
        
        // Set the speed, if the key left Shift is pressed goes faster
        if(isPressingShift){
            movement*=2;
        }
        // Outra abordagem
        // float movement = Speed * Time.deltaTime;
        // if(isPressingLeft){
        //      movement*=-1f;
        //}
        transform.position += new Vector3(movement, 0, 0);

        // Limit player boundaries
        float movementLimit = GameManager.Instance.gameWidth / 2;
        if(transform.position.x < -movementLimit){
            transform.position = new Vector3(-movementLimit, transform.position.y, transform.position.z);
        }
        
        if(transform.position.x > movementLimit){
            transform.position = new Vector3(movementLimit, transform.position.y, transform.position.z);
        }
    }
}
