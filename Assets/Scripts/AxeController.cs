using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class AxeController : NetworkBehaviour {
    //   //Viskas blogai
    //   [SyncVar]
    //   public Vector2 _direction;
    //   private MoveScript _mover;
    //// Use this for initialization
    //void Start () {
    //       _direction = Vector2.zero;
    //       _mover = GetComponent<MoveScript>();
    //}

    //// Update is called once per frame
    //void Update () {
    //       if (!isServer) return;
    //       if (_direction != Vector2.zero)
    //       {
    //           _mover.Move(_direction);
    //       }
    //}

    //   public void SetDirection(Vector2 direction)
    //   {
    //       if (!isServer) return;
    //       _direction = direction;
    //       //Debug.Log("direction: " + _direction + direction);
    //   }

    //   public Vector2 GetDirection()
    //   {
    //       return _direction;
    //   }

    private Rigidbody2D _rb;

    [SyncVar]
    public NetworkInstanceId spawnedBy;
    // Set collider for all clients.
    public override void OnStartClient()
    {
        GameObject obj = ClientScene.FindLocalObject(spawnedBy);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        _rb.velocity = Vector2.zero;
        Destroy(gameObject,0.1f);
    }
}
