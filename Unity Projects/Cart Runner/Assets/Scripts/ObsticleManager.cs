using UnityEngine;

public class ObsticleManager : MonoBehaviour
{
    Obsticle thisObsticle;

    private void Start()
    {
        thisObsticle = new Obsticle(gameObject.transform.position);
    }
}
