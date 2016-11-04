using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float timeToTravel = 1;              // Time it takes to move to the target
    public float lookAheadFactor = 3;
    public float lookAheadReturnSpeed = 0.5f;
    public float lookAheadMoveThreshold = 0.1f;

    private float m_OffsetZ;
    private Vector3 m_LastTargetPosition;
    private Vector3 m_CurrentVelocity;
    private Vector3 m_LookAheadPos;
    private bool inRoom = false;
    /* To be removed
    private float[] playerPos = new float[] { -0.63f, 4.23f };
    private float[] yPos = new float[] {0, 4.87f };
    private Dictionary<float,float> yCords = new Dictionary<float, float>();
    */

    // Use this for initialization
    void Start () {
        m_LastTargetPosition = target.position;
        m_OffsetZ = (transform.position - target.position).z;
        transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {
        if (!inRoom)
        {
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
            aheadTargetPos.y = (target.position.y + 0.63f);
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, timeToTravel);

            transform.position = newPos; //new Vector3(newPos.x, target.position.y + 0.63f, newPos.z);

            m_LastTargetPosition = target.position;
        }
	}

    public void JumpToRoom(Vector3 jumpTo)
    {
        inRoom = true;
        transform.position = jumpTo;

    }

    public void JumpToHall()
    {

    }
}