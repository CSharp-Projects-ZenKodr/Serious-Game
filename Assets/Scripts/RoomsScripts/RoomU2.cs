using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomU2 : Room
{
    public Animator blueButton;
    public Animator lever;
    public MapObject doorBlocker;
    private bool buttonPressed = false;
    private bool leverTriggered = false;
    private bool doorOpen = false;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        index = 2;
    }

    // Update is called once per frame
    new void Update()
    {

    }

    public override void Event(string objName, bool activate)
    {
        if (activate)
        {
            doorBlocker.collisionEnabled = false;
            blueButton.SetBool("isPushed", true);
            lever.SetBool("isTrigger", true);
            doorAnimator.SetBool("isOpen", true);
            print("Bravo !");
            buttonPressed = true;
            leverTriggered = true;
            doorOpen = true;
        }
        else
        {
            blueButton.SetBool("isPushed", false);
            buttonPressed = false;
        }


    }

    public override string GetRoomVariablesToDisplay()
    {
        string variables = "";
        variables += "Blue Button Pressed = " + convertBool(buttonPressed);
        variables += "\n";
        variables += "Lever triggered = " + convertBool(leverTriggered);
        variables += "\n";
        variables += "Door is Open = " + convertBool(doorOpen);

        return variables;
    }

    public override string GetRoomCodeToDisplay()
    {
        string code = "<b>if</b>(Blue Button Pressed = <color=green>True</color>) and (Lever Trigger = <color=green>True</color>) \n\t <b>then</b> Door is Open = <color=green>True</color>";
        return code;
    }
}
