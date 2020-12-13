using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomL1 : Room
{
    public Animator redButton;
    public MapObject doorBlocker;
    private bool buttonPressed = false;
    private bool doorOpen = false;
    private int step = 0;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        index = 4;
    }

    // Update is called once per frame
    new void Update()
    {
        
    }

    public override void Event(string objName, bool activate)
    {
        switch (step)
        {
            case 0:
                if (objName == "TrueButton")
                {
                    step++;
                    Debug.Log("true");
                }
                else
                    Debug.Log("false");
                break;

            case 1:
                if (objName == "FalseButton")
                {
                    step++;
                    Debug.Log("false");
                }
                else
                {
                    Debug.Log("true");
                    step = 0;
                }
                break;

            case 2:
                if (objName == "TrueButton")
                {
                    step++;
                    doorBlocker.collisionEnabled = false;
                    doorAnimator.SetBool("isOpen", true);
                    print("lesgobaby");
                }
                else
                    step = 0;
                break;
            case 3:
                Debug.Log("Stop pressing the button dumas");
                break;
            default:
                break;
        }

    }

    public override string GetRoomVariablesToDisplay()
    {
        string variables = "";
        variables += "Red Button Pressed = " + convertBool(buttonPressed);
        variables += "\n";
        variables += "Door is Open = " + convertBool(doorOpen);
        
        return variables;
    }

    public override string GetRoomCodeToDisplay()
    {
        string code = "<b>if</b>(Red Button Pressed = <color=green>True</color>)\n\t <b>then</b> Door is Open = <color=green>True</color>";
        return code;
    }
}
