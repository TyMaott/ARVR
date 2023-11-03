using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager GM;
    private int m_score;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI gameOverText;
    [SerializeField]
    TextMeshProUGUI playerLivesText;

    public GameObject startButton;

    public GameObject screenFlashHit;
    public GameObject screenFlashHeal;
    
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        scoreText.text = "Score: " + 0;
        playerLivesText.text = "Lives :\n<3 \n<3 \n<3";
        gameOverText.gameObject.SetActive(false);
        startButton.SetActive(false);
        screenFlashHit.SetActive(false);
        screenFlashHeal.SetActive(false);
    }

    // Update is called once per frame
    public void UpdateScore(int playerScore, int remaining)
    {
        if(remaining > 0){
            scoreText.text = "Score: " + playerScore + "\nRemaining Coins: " + remaining;
        }else{
            if (GM.isTuto){
                startButton.SetActive(true);
            }else{
                GameOver();
            }
        }
    }

    public void hideButton()
    {
        startButton.SetActive(false);
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

    public void hitFlash()
    {
        StartCoroutine(ShowandHide(screenFlashHit, 0.5f));
    }

    public void HealFlash()
    {
        StartCoroutine(ShowandHide(screenFlashHeal, 0.5f));
    }

    IEnumerator ShowandHide(GameObject sf, float delay)
    {
        sf.SetActive(true);
        yield return new WaitForSeconds(delay);
        sf.SetActive(false);
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
