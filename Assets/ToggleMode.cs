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

    public GameObject buttonJump;

    void Start()
    {
        modeText.text = "Control mode: \nkeyboard";
        buttonUp.SetActive(false);
        buttonDown.SetActive(false);
        buttonLeft.SetActive(false);
        buttonRight.SetActive(false);
        buttonJump.SetActive(false);
    }

    public void changeMode(bool mode)
    {
        modeText.text = "Control mode: \n" + (mode ? "keyboard" : "buttons");
        buttonUp.SetActive(!mode);
        buttonDown.SetActive(!mode);
        buttonLeft.SetActive(!mode);
        buttonRight.SetActive(!mode);
        buttonJump.SetActive(!mode);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
