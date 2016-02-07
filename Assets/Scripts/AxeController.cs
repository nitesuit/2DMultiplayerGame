using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class AxeController : NetworkBehaviour {
    [SyncVar]
    private Vector2 _direction;
    private MoveScript _mover;
	// Use this for initialization
	void Start () {
        _direction = Vector2.zero;
        _mover = GetComponent<MoveScript>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("the direction: " + _direction);
        if (_direction != Vector2.zero)
        {
            _mover.Move(_direction);
        }
	}

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
}
