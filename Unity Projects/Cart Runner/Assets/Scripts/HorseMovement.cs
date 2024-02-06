using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HorseMovement : MonoBehaviour
{
    PositionState position;

    private void Awake()
    {
        position = PositionState.Center;
    }

    private void Update()
    {
        switch (position)
        {
            case PositionState.Top:
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                if(movePosition() == -1) { position = PositionState.Center; }
                break;

            case PositionState.Center:
                transform.position = new Vector3(transform.position.x, -0.7f, transform.position.z);
                if (movePosition() == 1) { position = PositionState.Top; }
                if (movePosition() == -1) { position = PositionState.Bottom; }
                break;

            case PositionState.Bottom:
                transform.position = new Vector3(transform.position.x, -1.4f, transform.position.z);
                if (movePosition() == 1) { position = PositionState.Center; }
                break;
        }
    }

    public int movePosition()
    {
        int direction = 0;

        if (Input.GetKeyDown(KeyCode.W)) { direction = 1;}
        if (Input.GetKeyDown(KeyCode.S)) { direction = -1; }

        return direction;
    }

    public enum PositionState
    {
        Bottom,
        Center,
        Top
    }
}
