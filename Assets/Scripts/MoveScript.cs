using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveScript : MonoBehaviour {

    private Rigidbody2D _rb;
    public float Speed = 5;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {
        _rb.velocity = direction * Speed;
    }
}
