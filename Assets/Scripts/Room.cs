using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    protected int index;
    public GameObject door;
    private bool levelFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        this.transform.parent.gameObject.GetComponent<MainLogic>().setCurrentRoom(this);
        print("You enter the room number "+index);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        this.transform.parent.gameObject.GetComponent<MainLogic>().setCurrentRoom(null);
        print("You leave the room number " + index);
    }

    public virtual void Event(string objName)
    {  
        // To override
    }

    public virtual List<string> GetRoomVariablesToDisplay()
    {
        // To override
        print("aled");
        return null;
    }

    public virtual List<string> GetRoomCodeToDisplay()
    {
        // To override
        print("aled2");
        return null;
    }




}
