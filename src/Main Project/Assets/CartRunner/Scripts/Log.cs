using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Log : MonoBehaviour
{
    public float logSpeed = 3;
    private LogObjState state;
    GameObject cam;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        SetState(transform.position);
        transform.position = new Vector2(transform.position.x, SnapPosition());
    }

    void Update()
    {
        if (transform.position.x - cam.transform.position.x < 14)
        {
            MoveLog();
        }
    }

    void SetState(Vector2 position)
    {
        if (position.y >= -3.7)
        {
            state = LogObjState.Top;
        }
        else
        {
            state = LogObjState.Bottom;
        }
    }

    public float SnapPosition()
    {
        float position;

        switch (state)
        {
            case LogObjState.Top:
                position = -3.54f;
                break;

            case LogObjState.Bottom:
                position = -4.337f;
                break;

            default:
                position = 1;
                break;
        }

        return position;
    }

    void MoveLog()
    {
        transform.position -= new Vector3(logSpeed, 0, 0) * Time.deltaTime;
    }

    public string GetState()
    {
        return state.ToString();
    }
}

enum LogObjState
{
    Top,
    Bottom
}

