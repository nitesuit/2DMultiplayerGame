using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(MoveScript),typeof(HealthScript),typeof(Animator))]
public class PlayerController : NetworkBehaviour {

    private Animator _anim;
    private MoveScript _mover;
    private GameObject _axeRes;
    private HealthScript _health;
    // Use this for initialization
    void Start () {
        _axeRes = Resources.Load("Battle_axe") as GameObject;
        Debug.Log(_axeRes);
        _mover = GetComponent<MoveScript>();
        _anim = GetComponent<Animator>();
        _health = GetComponent<HealthScript>();
        _anim.SetFloat("SpeedX", 0);
        _anim.SetFloat("SpeedY", -1);
    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer) return;
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(inputX, inputY).normalized;

        _mover.Move(direction);

        if (direction == Vector2.zero)
        {
            _anim.SetBool("IsMoving", false);
            direction = new Vector2(_anim.GetFloat("SpeedX"), _anim.GetFloat("SpeedY"));
        }
        else {
            _anim.SetBool("IsMoving", true);
            _anim.SetFloat("SpeedX", inputX);
            _anim.SetFloat("SpeedY", inputY);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            CmdFire(direction);
        }
    }

    [Command]
    void CmdFire(Vector2 direction)
    {
        GameObject axe = Instantiate(_axeRes, transform.position, transform.rotation) as GameObject;
        axe.GetComponent<Rigidbody2D>().velocity = direction * 6;
        axe.GetComponent<AxeController>().spawnedBy = netId;

        NetworkServer.Spawn(axe);

        Destroy(axe, 2.0f);
    }

    public void Dummy()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Hazard"))
        {
            _health.TakeDamage(1);
        }
    }
}
