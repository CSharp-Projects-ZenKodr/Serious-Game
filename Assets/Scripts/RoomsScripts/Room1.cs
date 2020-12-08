using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1 : Room
{
    private bool hasKey = false;
    // Start is called before the first frame update
    void Start()
    {
        index = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Event(string objName)
    {
        print("You just walked on"+objName);

    }

    public override List<string> GetRoomVariablesToDisplay()
    {
        List<string> variables = new List<string>();
        variables.Add("hasKey");
        variables.Add(hasKey.ToString());
        return variables;
    }

    public override List<string> GetRoomCodeToDisplay()
    {
        List<string> code = new List<string>();
        code.Add("if(hasKey is true)");
        code.Add("  then : doorIsOpen");
        return code;
    }
}
