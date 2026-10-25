using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Propulsor : MonoBehaviour {
    private SpriteRenderer RB;

    void Start()
    {
        RB = GetComponent<SpriteRenderer>();
        StartColor();
    }
    private void Update()
    {
        if( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            RB.color = Color.red;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            RB.color = Color.blue;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            RB.color = Color.green;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            RB.color = Color.yellow;
        }
        else
        {
            RB.color = Color.white;
        }
        
    }

    void StartColor()
    {
        RB.color = Color.gray;
    }

}
