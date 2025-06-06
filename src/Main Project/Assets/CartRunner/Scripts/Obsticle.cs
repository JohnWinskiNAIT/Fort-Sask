using UnityEngine;

public class Obsticle
{
    private LogState state;

    public Obsticle(Vector2 position)
    {
        SetState(position);
    } 

    void SetState(Vector2 position)
    {
        if (position.y >= -3.4)
        {
            state = LogState.Top;
        }
        else if(position.y < -3.4 && position.y > -3.9)
        {
            state = LogState.Center;
        }
        else
        {
            state = LogState.Bottom;
        }
    }

    public float SnapPosition(CartRunnerManager manager)
    {
        float position;

        switch (state)
        {
            case LogState.Top:
                // position = -3.3f;
				position = manager.topRowY;
                break;

            case LogState.Center:
                // position = -3.7f;
				position = manager.middleRowY;
                break;

            case LogState.Bottom:
                // position = -4.2f;
				position = manager.bottomRowY;
                break;

            default:
                position = 1;
                break;
        }

        return position;
    }

    public string GetState()
    {
        return state.ToString();
    }
}

enum LogState
{
    Top,
    Center,
    Bottom
}
