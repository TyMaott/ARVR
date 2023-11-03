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
    public GameObject Fake;
    public GameObject Life;

    public bool isTuto;

    public Transform[] Consumable_spawnpoints;
    public Transform[] Tuto_spawnpoints;

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
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        isTuto = true;
        Instantiate(Collectible, Tuto_spawnpoints[0].position, Quaternion.identity);
    }

    public void startGame()
    {
        isTuto = false;
        playerScore = 0;
        UI.hideButton();
        Instantiate(Collectible, Consumable_spawnpoints[0].position, Quaternion.identity);
    }

    public void addTutoCoin()
    {
        playerScore++;
        playerMove.AddScoreInstanciate(1, Tuto_spawnpoints.Length-playerScore);
        if (playerScore < Tuto_spawnpoints.Length)
        {
            Vector3 pos = Tuto_spawnpoints[playerScore].position;
            Instantiate(Collectible, pos, Quaternion.identity);
        }
    }

    public void addCoin()
    {
        Vector3 pos = Consumable_spawnpoints[(++playerScore)%Consumable_spawnpoints.Length].position;
        Instantiate(Collectible, pos, Quaternion.identity);
        
        // for some coins, we also add a fake coin (which loses a life if collected)
        // and a life
        if(pos.y >= 1){
            Vector3 fake_pos = new Vector3(pos.x, 0.5f, pos.z); 
            Instantiate(Fake, fake_pos, Quaternion.identity);
            
            // Vector3 life_pos = new Vector3(pos.x/2, 0.5f, pos.z);
            // Instantiate(Life, life_pos, Quaternion.identity);
        }

        playerMove.AddScoreInstanciate(1, 12-playerScore);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}