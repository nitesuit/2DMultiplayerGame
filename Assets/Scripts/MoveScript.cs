using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveScript : MonoBehaviour {

    public float Speed;
    private Rigidbody2D _rb;
    private Animator _anim;
	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _anim.SetFloat("SpeedX", 0);
        _anim.SetFloat("SpeedY", -1);
    }
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(inputX, inputY).normalized;
        _rb.velocity = direction * Speed;

        if (direction == Vector2.zero) _anim.SetBool("IsMoving", false);
        else {
            _anim.SetBool("IsMoving", true);
            _anim.SetFloat("SpeedX", inputX);
            _anim.SetFloat("SpeedY", inputY);
        }
    }
}
