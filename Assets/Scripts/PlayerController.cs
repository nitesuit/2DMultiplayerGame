using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(MoveScript))]
public class PlayerController : NetworkBehaviour {

    private Animator _anim;
    private MoveScript _mover;
    private GameObject _axeRes;
    // Use this for initialization
    void Start () {
        if (!isLocalPlayer) return;
        _axeRes = Resources.Load("Battle_axe") as GameObject;
        _mover = GetComponent<MoveScript>();
        _anim = GetComponent<Animator>();
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

        if (direction == Vector2.zero) _anim.SetBool("IsMoving", false);
        else {
            _anim.SetBool("IsMoving", true);
            _anim.SetFloat("SpeedX", inputX);
            _anim.SetFloat("SpeedY", inputY);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire was pressed");
            GameObject axe = Instantiate(_axeRes, transform.position, transform.rotation) as GameObject;
            (axe.GetComponent<AxeController>() as AxeController).SetDirection(direction);
            axe.transform.Rotate(Vector3.forward * -1);
        }
    }

    public void Dummy()
    {
    }
}
