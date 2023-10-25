using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public UIManager UI;
    
    private int playerScore = 0;

    public GameObject Collectible;

    public Transform[] spawnpoints;

    PlayerMove playerMove;
  
    
    // Start is called before the first frame update
    void Awake()
    {
        //Instantiation
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        // for (int i = 0 ; i < spawnpoints.Length; i++)
        //     {
        //         spawnpoints[i].position += Vector3.down * 2.0f;
        //     }
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        Instantiate(Collectible, spawnpoints[0].position, Quaternion.identity);
        Debug.Log(spawnpoints[0].position);
        
    }

    public void addCoin()
    {
        Instantiate(Collectible, spawnpoints[(++playerScore)%spawnpoints.Length].position, Quaternion.identity);
        playerMove.AddScoreInstanciate(1, 12-playerScore);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}