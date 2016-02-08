using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class AxeController : NetworkBehaviour {
    //Viskas blogai
    [SyncVar]
    public Vector2 _direction;
    private MoveScript _mover;
	// Use this for initialization
	void Start () {
        _direction = Vector2.zero;
        _mover = GetComponent<MoveScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isServer) return;
        if (_direction != Vector2.zero)
        {
            _mover.Move(_direction);
        }
	}

    public void SetDirection(Vector2 direction)
    {
        if (!isServer) return;
        _direction = direction;
        //Debug.Log("direction: " + _direction + direction);
    }

    public Vector2 GetDirection()
    {
        return _direction;
    }
}
