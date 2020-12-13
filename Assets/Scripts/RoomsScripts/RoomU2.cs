using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomU2 : Room
{
    public Animator blueButton;
    public Animator lever;
    public MapObject doorBlocker;
    public MapObject r1DoorBlocker;
    public Animator r1Door;
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
        if (objName == "Lever")
        {
            if (!leverTriggered)
            {             
                lever.SetBool("isTrigger", true);
                leverTriggered = true;
            }
            else
            {
                lever.SetBool("isTrigger", false);
                leverTriggered = false;
            }
        }

        if(objName== "BlueButton")
        {
            if (activate)
            {
                blueButton.SetBool("isPushed", true);
                buttonPressed = true;
                if (leverTriggered)
                {
                    r1DoorBlocker.collisionEnabled = false;
                    r1Door.SetBool("isOpen", true);
                    doorBlocker.collisionEnabled = false;
                    doorAnimator.SetBool("isOpen", true);
                    doorOpen = true;
                }
            }
            else
            {
                blueButton.SetBool("isPushed", false);
                buttonPressed = false;
            }
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
        string code = "<b>IF</b>(Blue Button Pressed = <color=green>True</color> <b>AND</b> Lever Trigger = <color=green>True</color>) \n\t <b>THEN</b> Door is Open = <color=green>True</color>\n<b>END IF</b>";
        return code;
    }
}
