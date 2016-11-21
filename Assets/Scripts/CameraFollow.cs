using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PlayerLocation
{
    hall1,hall2,hall3,kitchen,bathroom,livingRoom
}

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
    private Camera self;
    private GameObject leftBorder, rightBorder;
    private Vector3[] HallEdges = new Vector3[] { new Vector3(-11.72f,0,0), new Vector3(2.343f,0,0) };
    private Vector3 newPos;
    /* To be removed
    private float[] playerPos = new float[] { -0.63f, 4.23f };
    private float[] yPos = new float[] {0, 4.87f };
    private Dictionary<float,float> yCords = new Dictionary<float, float>();
    */

    // Use this for initialization
    void Start () {
        m_LastTargetPosition = target.position;
        //m_OffsetZ = (transform.position - target.position).z;
        transform.parent = null;
        self = GetComponent<Camera>();
        leftBorder = GameObject.Find("LeftBorder");
        rightBorder = GameObject.Find("RightBorder");
	}
	
	// Update is called once per frame
	void Update () {
        float xMoveDelta = (target.position - m_LastTargetPosition).x;
        newPos = new Vector3(transform.position.x + xMoveDelta, target.position.y + 0.63f, -10);

        leftBorder.transform.position = self.ScreenToWorldPoint(new Vector3(0, self.pixelHeight / 2, self.nearClipPlane));
        rightBorder.transform.position = self.ScreenToWorldPoint(new Vector3(self.pixelWidth, self.pixelHeight / 2, self.nearClipPlane));

        // Trying out an alternative method of consantly snapping to the player's location to address the issue of the camera sliding off towards nowhere.
        if (!inRoom)
        {
            /*
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
            */
            transform.position = new Vector3(target.position.x, target.position.y + 0.63f, -10);
        }
        //m_LastTargetPosition = target.position;
    }

    bool canMove()
    {
        Vector3 rEdge, lEdge;
        Vector3 futurePos = self.WorldToScreenPoint(newPos),
                rBorder = new Vector3(futurePos.x + (self.pixelWidth / 2), futurePos.y, 0),
                lBorder = new Vector3(futurePos.x - (self.pixelWidth / 2), futurePos.y, 0);

        if (inRoom) {return false;}

        if (target.gameObject.GetComponent<Interact>().location == PlayerLocation.hall1)
        {
            lEdge = self.WorldToScreenPoint(HallEdges[0]);
            rEdge = self.WorldToScreenPoint(HallEdges[1]);

            if ((Mathf.Abs(Vector3.Distance(futurePos, rEdge)) <= self.pixelWidth / 2) || (Mathf.Abs(Vector3.Distance(futurePos, lEdge)) <= self.pixelWidth / 2))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (target.gameObject.GetComponent<Interact>().location == PlayerLocation.hall2)
        {
            return true;
        }
        else
        {
            return true;
        }
    }

    public void JumpToRoom(Vector3 jumpTo)
    {
        inRoom = true;
        transform.position = jumpTo;

    }

    public void JumpToHall(Vector3 jumpTo)
    {
        inRoom = true;
        transform.position = jumpTo;
        inRoom = false;
    }
}