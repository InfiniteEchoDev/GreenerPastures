using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int sheep;
    
    public float radius = 2.5f;
    [SerializeField] private float radius_growth_per_sheep = 0.5f;
    [SerializeField] private float radius_max_growth_rate = 2.0f;
    [SerializeField] private float minRadius = 2.5f;
    [SerializeField] private float maxRadius = 30.0f;
    public Transform radiusTransform;
	public float moveSpeed;
    private Vector2 m_Move;

	public void OnMove(InputAction.CallbackContext context)
	{
		m_Move = context.ReadValue<Vector2>();
	}

    public void Update()
    {
        Move(m_Move);
        SheepsMgr.Instance.SetAllSheepDest( transform.position, radius );
        UpdateRadius();
    }

    private void UpdateRadius()
    {
        sheep = SheepsMgr.Instance.CountSheepAroundPosition(transform.position, radius);
        Debug.Log("We have this many sheep: " + sheep);
        var newRadius = Mathf.Min(minRadius + sheep * radius_growth_per_sheep, maxRadius);
        Debug.Log("Goal radius is " + newRadius);
        radius = Mathf.MoveTowards(radius, newRadius, radius_max_growth_rate * Time.deltaTime);
        Debug.Log("Radius is now: " + radius);
        radiusTransform.localScale = new Vector3 (radius, radius, radius);
    }

    private void Move(Vector2 direction)
    {
		if (direction.sqrMagnitude < 0.01)
            return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        // For simplicity's sake, we just keep movement in a single plane here. Rotate
        // direction according to world Y rotation of player.
        // var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        var move =    IsoMgr.Instance.IsoRotation.rotation * new Vector3(direction.x, 0, direction.y);

        transform.position += move * scaledMoveSpeed;
    }
}
