using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLogic : MonoBehaviour
{
    private Room currentRoom;
    public Text varText;
    public Text codeText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Event(string objName, bool activate)
    {
        currentRoom.Event(objName, activate);
        // update potential variable change
        varText.text = currentRoom.GetRoomVariablesToDisplay();

    }

    public void setCurrentRoom(Room newRoom)
    {
        currentRoom = newRoom;
        if (currentRoom != null)
        {
            // Update UI
            varText.text = currentRoom.GetRoomVariablesToDisplay();
            codeText.text = currentRoom.GetRoomCodeToDisplay();

        }
    }
}
