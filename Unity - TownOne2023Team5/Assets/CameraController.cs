using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    // the target the camera should follow (usually the player)
    public Transform target;

    public float lookRange;
    
    // damping is the amount of time the camera should take to go to the target
    public float damping = 5.0f;
    // offset from player
    private Vector3 offset;

    private Vector2 m_Look;

    public void OnLook(InputAction.CallbackContext context)
    {
        m_Look = context.ReadValue<Vector2>();
    }

    void Start()
    {
        offset = target.position - transform.position;
    }

    public void Update()
    {
        Look(m_Look);
        transform.position = Vector3.Lerp (transform.position, target.position - offset, (Time.deltaTime * damping));
    }

    private void Look(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;
        var scaledMoveSpeed = lookRange * Time.deltaTime;
        // For simplicity's sake, we just keep movement in a single plane here. Rotate
        // direction according to world Y rotation of player.
        var move =    IsoMgr.Instance.IsoRotation.rotation * new Vector3(direction.x, 0, direction.y);

        transform.position += move * scaledMoveSpeed;
    }
}
