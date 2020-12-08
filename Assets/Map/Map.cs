using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int height;
    public int width;
    public GameObject player;
    public GameObject objectListFather;
    private List<GameObject> objects;

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

        //snap player position to integer values
        Vector3 pos = player.transform.position;
        Vector3 newPos = new Vector3((int)(pos.x - 0.5), (int)(pos.y - 0.5), 0);
        player.transform.position = newPos;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            newPosition.y += 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            newPosition.y -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            newPosition.x -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            newPosition.x += 1;
        }

        if (this.canMoveTo(newPosition)) {

            player.transform.position = this.transform.position + newPosition;
        }

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
