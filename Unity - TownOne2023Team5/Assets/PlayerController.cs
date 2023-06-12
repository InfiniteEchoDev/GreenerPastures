using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int sheep;

    public float radius = 2.5f;
    [SerializeField] private float radius_growth_per_sheep = 0.5f;
    [SerializeField] private float radius_max_growth_rate = 5.0f;
    [SerializeField] private float minRadius = 2.5f;
    [SerializeField] private float maxRadius = 10.0f;
    public Transform radiusTransform;
    public float moveSpeed;
    private float followerSpeed;
    private Vector2 m_Move;

    private bool rolling = false;
    public List<Sheep> followers;

    private AI_FOV playerFOV;

    public delegate void OnUpdateFollowerCountDelegate( float followerCount );
    public event OnUpdateFollowerCountDelegate OnUpdateFollowerCount;

    public void Start()
    {
        playerFOV = GetComponent<AI_FOV>();
        SheepsMgr.sheepKilled += removeFollower;
        followerSpeed = moveSpeed * 2.5f;
    }

    IEnumerator roll()
    {
        updateFollowerSpeed(4.0f, 2.0f);
        
        yield return new WaitForSeconds(1.0f);

        updateFollowerSpeed(.25f, .5f);
        rolling = false;
    }

    private void updateFollowerSpeed(float speedMult = 5.0f, float dmgMult = 2.0f) 
    {
        foreach (Sheep sheep in followers)
        {
            if (!sheep.gameObject.activeSelf)
                continue;

            sheep.agent.speed *= speedMult;
            sheep.agent.acceleration *= speedMult;
            sheep.damage *= dmgMult;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
	{
		m_Move = context.ReadValue<Vector2>();
	}

    public void OnRoll(InputAction.CallbackContext context)
    {
        if (rolling)
            return;

        StartCoroutine(roll());
        rolling = true;
    }

    public void Update()
    {
        Move(m_Move);
        UpdateFollowerPositions();
        UpdateRadius();
    }

    private void UpdateRadius()
    {

        foreach (Transform visibleTarget in playerFOV.visibleTargets)
        {
            if (visibleTarget.GetComponent<Sheep>() != null)
            {
                Sheep sheep = visibleTarget.GetComponent<Sheep>();
                visibleTarget.gameObject.tag = "Influenced";

                sheep.agent.speed = moveSpeed;

                if (followers.Contains(sheep))
                    continue;

                followers.Add(sheep);
                OnUpdateFollowerCount?.Invoke( followers.Count );
                sheep.playerPosition = this.transform;
                sheep.updateSheepHordeDamage(followers.Count, radius);
            }
        }

        //Debug.Log("[PlayerCtrl] We have this many sheep: " + sheep);
        float newRadius = Mathf.Min(minRadius + followers.Count * radius_growth_per_sheep, maxRadius);
        radius = Mathf.MoveTowards(radius, newRadius, radius_max_growth_rate * Time.deltaTime);
        //Debug.Log("[PlayerCtrl] Goal radius is " + newRadius);
        //Debug.Log("[PlayerCtrl] Radius is now: " + radius);

        if (radius > maxRadius)
            radius = maxRadius;

        playerFOV.viewRadius = radius / 2;
        radiusTransform.localScale = new Vector3 (radius, radius, radius);


    }

    private void UpdateFollowerPositions() 
    {
        foreach (Sheep sheep in followers)
        {
            if (!sheep.gameObject.activeSelf)
                continue;

            sheep.playerPosition = this.transform;
            /*if (sheep.agent.enabled == false)
            {
                sheep.transform.position = this.transform.position;
                continue;
            }*/

            /*if (sheep.agent.remainingDistance < sheep.agent.stoppingDistance)
            {
                sheep.agent.enabled = false;
                continue;
            }*/

            sheep.SetMoveTarget(this.transform.position);

        }

    }

    void removeFollower(Sheep sheep)
    {
        //Debug.Log("Follower Killed :(");
        followers.Remove(sheep);
        OnUpdateFollowerCount?.Invoke( followers.Count );
    }

    private void Move(Vector2 direction)
    {
		if (direction.sqrMagnitude < 0.01)
            return;
        float scaledMoveSpeed = moveSpeed * Time.deltaTime;
        // For simplicity's sake, we just keep movement in a single plane here. Rotate
        // direction according to world Y rotation of player.
        // var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        Vector3 move =    IsoMgr.Instance.IsoRotation.rotation * new Vector3(direction.x, 0, direction.y);

        transform.position += move * scaledMoveSpeed;
    }
}
