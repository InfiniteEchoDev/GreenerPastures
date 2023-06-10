using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBehavior : MonoBehaviour
{
    public float moveSpeed = 6.0f;

    Rigidbody body;
    Camera cam;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.y));
        transform.LookAt(mousepos + Vector3.up * transform.position.y);

        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + velocity * Time.fixedDeltaTime);
    }

}
