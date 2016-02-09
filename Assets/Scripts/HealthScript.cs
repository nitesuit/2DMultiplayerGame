using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(Animator))]
public class HealthScript : NetworkBehaviour {
    public int MaxHealth = 100;
    public bool IsAlive = true;
    private Animator _anim;
    [SyncVar]
    public int health = 100;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        if (!isServer)
            return;
        if(health-amount > 0)
        {
            health -= amount;
        }
        else
        {
            health = 0;
            IsAlive = false;
            _anim.SetBool("IsAlive", false);
            Destroy(gameObject, 1f);
        }
    }
}
