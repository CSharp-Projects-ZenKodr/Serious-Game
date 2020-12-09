using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLogic : MonoBehaviour
{
    private Room currentRoom;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Event(string objName)
    {
        currentRoom.Event(objName);
    }

    public void setCurrentRoom(Room newRoom)
    {
        currentRoom = newRoom;
        if (currentRoom == null)
        {
            // Update UI
        }
        else {
            // Update UI
        }
    }
}
