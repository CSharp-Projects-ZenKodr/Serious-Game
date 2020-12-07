using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour
{

    public bool collisionEnabled;
    public string objName;

    // Start is called before the first frame update
    void Start()
    {
        // snap position to integer values
        Vector3 pos = this.transform.position;
        Vector3 newPos = new Vector3((int)(pos.x - 0.5), (int)(pos.y - 0.5), 0);
        this.transform.position = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
