using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        position = this.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            position.y += 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            position.y -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            position.x -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            position.x += 1;
        }

        this.GetComponent<Transform>().position = position;

    }
}
