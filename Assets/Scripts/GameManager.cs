using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;} // Segura a referência da única instância no Singleton, 
							      // static é fixa na memória, não pertence a uma instância 
							      // "{get; privateset;}" Server para permitir só leitura
    public float gameWidth = 46f; // 28 para esquerda e 28 para direita

    public bool isGameActive = true;

    [HideInInspector]
	public int score = 0;

    public int gameLifes = 3;
    
    void Awake() {
        if(Instance != null){
            Destroy(this);
        }
        else{
            Instance = this; // this refere a própria classe
        }
    }

}
