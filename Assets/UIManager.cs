using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int m_score;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI gameOverText;
    [SerializeField]
    TextMeshProUGUI playerLivesText;
    
    void Start()
    {
        scoreText.text = "Score: " + 0;
        playerLivesText.text = "Lives :\n<3 \n<3 \n<3";
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void UpdateScore(int playerScore, int remaining)
    {
        if(remaining > 0){
            scoreText.text = "Score: " + playerScore + "\nRemaining Coins: " + remaining;
        }else{
            GameOver();
        }
        
    }

    public void UpdateLives(int playerLives)
    {
        playerLivesText.text = "Lives :";
        for (int i = 0;i<playerLives ;i++){
            playerLivesText.text += "\n<3 ";
        }
        if (playerLives <= 0){
            gameOverText.text = "you died..";
            GameOver();
        }

    }

    public void GameOver()
    {
        scoreText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
    }

    void Update()
    {
        
    }
}
