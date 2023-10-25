using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    UIManager _UIManager;
    ToggleMode _ToggleMode;
    int m_score = 0;
    float speed = 1.0f;
    Rigidbody m_Rigidbody;
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
}
