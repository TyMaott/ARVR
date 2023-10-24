using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    UIManager _UIManager;
    int m_score = 0;
    float speed = 1.0f;
    Rigidbody m_Rigidbody;

    private GameObject[] getCount;
    // Start is called before the first frame update
    void Start()
    {
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        m_Rigidbody = GetComponent<Rigidbody>();
        getCount = GameObject.FindGameObjectsWithTag("Coin");
    }

    // Update is called once per frame
    void Update()
    {
        float x_move = Input.GetAxis("Horizontal") * speed;
        float z_move = Input.GetAxis("Vertical") * speed;

        Vector3 move = new Vector3(x_move, 0, z_move);
        m_Rigidbody.AddForce(move);
        getCount = GameObject.FindGameObjectsWithTag("Coin");
    }

    public void AddScore(int s)
    {
        m_score += s;
        _UIManager.UpdateScore(m_score, getCount.Length-1);

    }
}
