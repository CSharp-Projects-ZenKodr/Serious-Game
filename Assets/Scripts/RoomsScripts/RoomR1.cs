using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomR1 : Room
{
    public MapObject d1DoorBlocker;
    public Animator d1Door;
    public MapObject doorBlocker;
    private bool doorOpen = false;
    public Animator lever1;
    private bool l1=false;
    public Animator lever2;
    private bool l2 = false;
    public Animator lever3;
    private bool l3 = false;
    public Animator lever4;
    private bool l4 = false;

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
        if (objName == "Lever1")
        {
            if (l1)
            {
                lever1.SetBool("isTrigger", false);
                l1 = false;
            }
            else
            {
                lever1.SetBool("isTrigger", true);
                l1 = true;
            }  
        }
        if (objName == "Lever2")
        {
            if (l2)
            {
                lever2.SetBool("isTrigger", false);
                l2 = false;
            }
            else
            {
                lever2.SetBool("isTrigger", true);
                l2 = true;
            }
        }
        if (objName == "Lever3")
        {
            if (l3)
            {
                lever3.SetBool("isTrigger", false);
                l3 = false;
            }
            else
            {
                lever3.SetBool("isTrigger", true);
                l3 = true;
            }
        }
        if (objName == "Lever4")
        {
            if (l4)
            {
                lever4.SetBool("isTrigger", false);
                l4 = false;
            }
            else
            {
                lever4.SetBool("isTrigger", true);
                l4 = true;
            }
        }

        TestFor();

    }

    private void TestFor()
    {
        if(l1&&l2&&l3&&l4)
        {

            doorOpen = true;
            doorBlocker.collisionEnabled = false;
            doorAnimator.SetBool("isOpen", true);
            d1DoorBlocker.collisionEnabled = false;
            d1Door.SetBool("isOpen", true);
        }
    }

    public override string GetRoomVariablesToDisplay()
    {
        string variables = "";
        
        variables += "Lever 1 Activated = " + convertBool(l1);
        variables += "\n";
        variables += "Lever 2 Activated = " + convertBool(l2);
        variables += "\n";
        variables += "Lever 3 Activated = " + convertBool(l3);
        variables += "\n";
        variables += "Lever 4 Activated = " + convertBool(l4);
        variables += "\n";
        variables += "Door is Open = " + convertBool(doorOpen);
        variables += "\n";


        return variables;
    }

    public override string GetRoomCodeToDisplay()
    {
        string code = "All lever activated = <color=green>True</color>\n<b>FOR</b> i = 0 to i=4 :\n\t<b>IF</b>(Lever i activated = <color=red>False</color>)";
        code += "\n\t\t<b>THEN</b> : All lever activated = <color=red>False</color>)";
        code += "\n<b>END FOR</b>";
        code += "\n\n<b>IF</b>(All lever activated = <color=green>True</color>)";
        code += "\n\t\t<b>THEN</b> : Door is Open = <color=green>True</color>\n<b>END IF</b>";

        return code;
    }
}
