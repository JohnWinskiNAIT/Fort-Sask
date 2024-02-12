using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class ObsticleManager : MonoBehaviour
{
    Obsticle thisObsticle;

    private void Start()
    {
        thisObsticle = new Obsticle(gameObject.transform.position);
    }
}
