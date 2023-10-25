using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleMode : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    TextMeshProUGUI modeText;

    public GameObject buttonUp;
    public GameObject buttonDown;
    public GameObject buttonLeft;
    public GameObject buttonRight;

    void Start()
    {
        modeText.text = "Control mode: keyboard";
        buttonUp.SetActive(false);
        buttonDown.SetActive(false);
        buttonLeft.SetActive(false);
        buttonRight.SetActive(false);
    }

    public void changeMode(bool mode)
    {
        modeText.text = "Control mode: " + (mode ? "keyboard" : "buttons");
        buttonUp.SetActive(!mode);
        buttonDown.SetActive(!mode);
        buttonLeft.SetActive(!mode);
        buttonRight.SetActive(!mode);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}