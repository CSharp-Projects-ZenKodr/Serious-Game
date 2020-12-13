using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomL1 : Room
{
    public Animator redButton;
    public MapObject doorBlocker;
    public MapObject u1DoorBlocker;
    public Animator u1Door;
    private bool buttonPressed = false;
    private bool doorOpen = false;
    private string code = "=>\t4 == 4\t: ?\n";
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
                    code = "\t\t4 == 4\t: <color=green>TRUE</color>\n" +
                            "=>\t10 > 20\t: ?";
                    Debug.Log("true");
                }
                else
                {
                    code = "=>\t4 == 4\t: ?\n";
                    Debug.Log("false");
                }
                break;

            case 1:
                if (objName == "FalseButton")
                {
                    code = "\t\t4 == 4\t: <color=green>TRUE</color>\n" +
                           "\t\t10 > 20\t: <color=red>FALSE</color>\n" +
                           "=>\tNOT TRUE \t: ?";
                    step++;
                    //Debug.Log("false");
                }
                else
                {
                    code = "=>\t4 == 4\t: ?\n";
                    //Debug.Log("true");
                    step = 0;
                }
                break;

            case 2:
                if (objName == "FalseButton")
                {
                    code = "\t\t4 == 4\t: <color=green>TRUE</color>\n" +
                           "\t\t10 > 20\t: <color=red>FALSE</color>\n" +
                           "\t\tNOT TRUE \t: <color=red>FALSE</color>";
                    step++;
                    doorBlocker.collisionEnabled = false;
                    u1DoorBlocker.collisionEnabled = false;
                    u1Door.SetBool("isOpen", true);
                    doorAnimator.SetBool("isOpen", true);
                    //print("lesgobaby");
                }
                else
                {
                    code = "=>\t4 == 4\t: ?\n";
                    step = 0;
                }
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
        /*variables += "Red Button Pressed = " + convertBool(buttonPressed);
        variables += "\n";
        variables += "Door is Open = " + convertBool(doorOpen);*/
        
        return variables;
    }

    public override string GetRoomCodeToDisplay()
    {
        return this.code;
    }
    
}
