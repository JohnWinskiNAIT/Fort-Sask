using UnityEngine;

public class Obsticle
{
    private ObsticleState state;

    public Obsticle(Vector2 position)
    {
        SetState(position);
    } 

    void SetState(Vector2 position)
    {
        Debug.Log(position);
        if (position.y >= -3.4)
        {
            state = ObsticleState.Top;
        }
        else if(position.y < -3.4 && position.y > -3.9)
        {
            state = ObsticleState.Center;
        }
        else
        {
            state = ObsticleState.Bottom;
        }
    }

    public float SnapPosition()
    {
        float position;

        switch (state)
        {
            case ObsticleState.Top:
                position = -3.3f;
                break;

            case ObsticleState.Center:
                position = -3.7f;
                break;

            case ObsticleState.Bottom:
                position = -4.2f;
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

enum ObsticleState
{
    Top,
    Center,
    Bottom
}
