using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPointBoxController : MonoBehaviour
{
    [SerializeField]
    private float angularSpeed = 1200;
    [SerializeField]
    private float speed = 900;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var body = GetComponent<Rigidbody2D>();
        var dir = (Vector2)PlayerController.Instance.transform.position - (Vector2)transform.position;
        dir.Normalize();

        float rot = Vector3.Cross(dir, transform.up).z;
        body.angularVelocity = -angularSpeed * rot;
        body.velocity = transform.up * speed;
    }
}
