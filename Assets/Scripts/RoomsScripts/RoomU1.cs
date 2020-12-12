using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomU1 : Room
{
    public Animator redButton;
    public MapObject doorBlocker;
    private bool buttonPressed = false;
    private bool doorOpen = false;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        index = 1;
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
            redButton.SetBool("isPushed", true);
            doorAnimator.SetBool("isOpen", true);
            print("Bravo !");
            buttonPressed = true;
            doorOpen = true;
        }
        else
        {
            buttonPressed = false;
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
