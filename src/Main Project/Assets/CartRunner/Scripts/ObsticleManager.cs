using UnityEngine;

public class ObsticleManager : MonoBehaviour
{
    public Obsticle thisObsticle;
	CartRunnerManager manager;

    private void Start()
    {
		manager = FindAnyObjectByType<CartRunnerManager>();
        thisObsticle = new Obsticle(gameObject.transform.position);
        transform.position = new Vector3(transform.position.x, thisObsticle.SnapPosition(manager));
    }
}
