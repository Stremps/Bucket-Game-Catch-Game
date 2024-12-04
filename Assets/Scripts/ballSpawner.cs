using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ballSpawner : MonoBehaviour
{
    public List<GameObject> prefabs; //Lista com as bolas em prefab
    public Vector3 originPoint = new Vector3(0, 0, 0); // Por padrão colocado no ponto de origem do espaço
    public float interval = 1f;
    private float coolDown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.isGameActive){
            return; // Trava o update aqui, não passa daqui
        }
        coolDown -= Time.deltaTime;

        if(coolDown <= 0f){
            coolDown = interval;
            SpawnBall();
        }
    }

    void SpawnBall(){
        //Get prefab
        int prefabIndex = Random.Range(0, prefabs.Count);
        GameObject prefab = prefabs[prefabIndex];
        
        // Get position
        float gameWidth = GameManager.Instance.gameWidth;
	    float xOffset = Random.Range(-gameWidth/2f, gameWidth/2f); // Como é o tamanho total, temos que dividir por 2
	    Vector3 position = originPoint + new Vector3(xOffset, 0, 0);

        // Get rotation
        Quaternion rotation = prefab.transform.rotation;

        // Spawn Ball
        Instantiate(prefab, position, rotation);
    }
}
