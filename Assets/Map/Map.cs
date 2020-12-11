using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int height;
    public int width;
    public int c, invSpeed;
    public bool moveU, moveD, moveL, moveR;
    private bool menuOpen = false;
    public GameObject player;
    public GameObject objectListFather;
    private List<GameObject> objects;
    public Animator characterAnimator;
    public Animator DoorU1Animator;
    public Animator DoorU2Animator;
    public Animator DoorU3Animator;
    public Animator DoorU4Animator;
    public Animator DoorR1Animator;
    public Animator DoorR2Animator;
    public Animator DoorR3Animator;
    public Animator DoorR4Animator;
    public Animator DoorD1Animator;
    public Animator DoorD2Animator;
    public Animator DoorD3Animator;
    public Animator DoorD4Animator;
    public Animator DoorL1Animator;
    public Animator DoorL2Animator;
    public Animator DoorL3Animator;
    public Animator DoorL4Animator;

    // Start is called before the first frame update
    void Start()
    {
        
        this.transform.localScale =  new Vector3(width,height,1); // set map scale

        //get all objects and set their position to integer values
        objects = new List<GameObject>();
        foreach (Transform child in objectListFather.transform)
        {
            if (null == child) { continue; }
            objects.Add(child.gameObject);
        }
        c = 0;
        //snap player position to integer values
        Vector3 pos = player.transform.position;
        Vector3 newPos = new Vector3((int)(pos.x - 0.5), (int)(pos.y - 0.5), 0);
        player.transform.position = newPos;

        DoorU1Animator.SetBool("isOpen", true);
        DoorR1Animator.SetBool("isOpen", true);
        DoorD1Animator.SetBool("isOpen", true);
        DoorL1Animator.SetBool("isOpen", true);
    }

    // Update is called once per frame
    void Update()
    {
        c++;
        c = c % invSpeed;
        characterAnimator.SetBool("moveU", Input.GetKey(KeyCode.UpArrow));
        characterAnimator.SetBool("moveD", Input.GetKey(KeyCode.DownArrow));
        characterAnimator.SetBool("moveL", Input.GetKey(KeyCode.LeftArrow));
        characterAnimator.SetBool("moveR", Input.GetKey(KeyCode.RightArrow));
        if(!menuOpen)
            MovePlayer();
        CallEvent();
    }





    bool canMoveTo(Vector2 newPosition)
    {
        // test boundaries
        if (newPosition.x<0 || newPosition.x >= width || newPosition.y < 0 || newPosition.y >= height)
        {
            return false;
        }
        foreach(GameObject obj in objects)
        {
            MapObject data = obj.GetComponent<MapObject>();
            if (data.collisionEnabled)
            {
                Vector3 p = obj.transform.position-this.transform.position;
                int width = (int)obj.transform.localScale.x;
                int height = (int) obj.transform.localScale.y;
                for( int i =0; i< width; ++i)
                {
                    for (int j =0; j < height; ++j)
                    {
                        if (Mathf.Abs(p.x +i - newPosition.x) < 0.01 && Mathf.Abs(p.y+j - newPosition.y) < 0.01)
                        {
                            return false;
                        }
                    }
                }

            }

        }
        return true;
    }

    void MovePlayer()
    {   
        Vector3 newPosition = player.transform.position- this.transform.position;

        if (Input.GetKey(KeyCode.UpArrow) && c == invSpeed-1)
        {
            newPosition.y += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow) && c == invSpeed-1)
        {
            newPosition.y -= 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && c == invSpeed-1)
        {
            newPosition.x -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow) && c == invSpeed-1)
        {
            newPosition.x += 1;
        }

        if (this.canMoveTo(newPosition)) {

            player.transform.position = this.transform.position + newPosition;
        }

    }

    public void TogglePlayerMovement()
    {
        menuOpen = !menuOpen;
    }

    void CallEvent()
    {
        Vector3 playerPos = player.transform.position - this.transform.position;
        foreach (GameObject obj in objects)
        {
            MapObject data = obj.GetComponent<MapObject>();

            Vector3 p = obj.transform.position - this.transform.position;
            if (Mathf.Abs(p.x - playerPos.x) < 0.01 && Mathf.Abs(p.y - playerPos.y) < 0.01)
            {
                string objName = data.objName;
                // TODO : Call event "player is on objName"
            }
            

        }
    }

}
