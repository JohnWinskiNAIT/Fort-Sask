using UnityEngine;

public class ObsticleManager : MonoBehaviour
{
    public Obsticle thisObsticle;

    private void Start()
    {
        thisObsticle = new Obsticle(gameObject.transform.position);
        transform.position = new Vector3(transform.position.x, thisObsticle.SnapPosition());
    }
}
