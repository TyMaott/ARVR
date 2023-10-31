using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    PlayerMove playerMove;
    GameManager GM;
    float m_rotation_speed = 0.3f;
    float up_down_speed = 0.3f;
    float base_y;
    bool isAirborn;
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Coin";
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        m_Rigidbody = GetComponent<Rigidbody>();
        base_y = transform.position.y/2;
        isAirborn = (base_y >= 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, m_rotation_speed, 0);
        float y = base_y + Mathf.PingPong(Time.time * up_down_speed, 0.2f) ;
        if(isAirborn){
            y = base_y + Mathf.PingPong(Time.time * up_down_speed*10, 0.2f*10) ;
        }
        transform.position = new Vector3(1*transform.position.x, y, 1*transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            Destroy(this.gameObject);
            GM.addCoin();
        }
        
    }
}
