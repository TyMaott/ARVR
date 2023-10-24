using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject Player;
    Vector3 difference;
    // Start is called before the first frame update
    void Start()
    {
        difference = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + difference;
    }
}
