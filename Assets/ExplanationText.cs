using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplanationText : MonoBehaviour
{
    public Text localText;
    // Start is called before the first frame update
    void Start()
    {
        localText.text = "Welcome to CodeLocks !\n" +
                        "This menu is here to help you, only if you need it :)\n" +
                        "Press ESCAPE or the ? button to open and close me.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IfText()
    {
        localText.text = "this kinda sucks ngl";

    }
}
