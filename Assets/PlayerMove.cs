using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    UIManager _UIManager;
    ToggleMode _ToggleMode;
    int m_score = 0;
    float speed = 1.0f;
    float jump_force = 300.0f;
    Rigidbody m_Rigidbody;
    int lives;
    bool mode = true; // true = keyboard, false = buttons

    private GameObject[] getCount;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Player";
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _ToggleMode = GameObject.Find("Mode").GetComponent<ToggleMode>();
        m_Rigidbody = GetComponent<Rigidbody>();
        getCount = GameObject.FindGameObjectsWithTag("Coin");
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(mode){            
            float x_move = Input.GetAxis("Horizontal") * speed;
            float z_move = Input.GetAxis("Vertical") * speed;

            Vector3 move = new Vector3(x_move, 0, z_move);
            m_Rigidbody.AddForce(move);
        }

        // Grounded Test
        if (m_Rigidbody.velocity.y == 0.0f){
            if(Input.GetKeyDown(KeyCode.Space)){
                Vector3 jump = new Vector3(0, 1*jump_force, 0);
                m_Rigidbody.AddForce(jump);
                }
            }        
        getCount = GameObject.FindGameObjectsWithTag("Coin");

    }

    public void moveMode()
    {
        mode = !mode;
        _ToggleMode.changeMode(mode);
    }

    public void LRButton(float x_move)
    {
        if(!mode){
            Vector3 move = new Vector3(x_move, 0, 0);
            m_Rigidbody.AddForce(move);
        }
    }

    public void UDButton(float z_move)
    {
        if(!mode){
            Vector3 move = new Vector3(0, 0, z_move);
            m_Rigidbody.AddForce(move);
        }
    }

    public void JumpButton(float jump_force)
    {
        // grounded test
        if (m_Rigidbody.velocity.y == 0.0f){
            Debug.Log("here");
            Vector3 jump = new Vector3(0, 1*jump_force, 0);
            m_Rigidbody.AddForce(jump);
            }
    }

    public void AddScore(int s)
    {
        m_score += s;
        _UIManager.UpdateScore(m_score, getCount.Length-1);
    }

    public void AddScoreInstanciate(int s, int r)
    {
        m_score += s;
        _UIManager.UpdateScore(m_score, r);
    }

    public void ResetScore()
    {
        m_score = 0;
        _UIManager.UpdateScore(m_score, 12);
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(0,5,0);
    }

    public void getLife(int l)
    {
        _UIManager.HealFlash();
        lives += l;
        _UIManager.UpdateLives(lives);
    }

    public void loseLife(int l)
    {
        _UIManager.hitFlash(); // screenflash
        lives -= l;
        _UIManager.UpdateLives(lives);
        
    }
}
