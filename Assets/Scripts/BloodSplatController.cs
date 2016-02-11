using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BloodSplatController : NetworkBehaviour {

    public void DestroyAfterAnimation()
    {
        Destroy(gameObject);
    }
}
