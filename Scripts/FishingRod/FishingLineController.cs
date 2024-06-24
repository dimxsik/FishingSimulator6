using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FishingLineController : MonoBehaviour 
{
    public Transform whatTheRopeIsConnectedTo;
    public Transform whatIsHangingFromTheRope;
    
    private LineRenderer lineRenderer;
    
    public List<Vector3> allRopeSections = new List<Vector3>();
    
    private float ropeLength = 1f;
    [SerializeField] private float readyRopelength = 1f;
    [SerializeField] float minRopeLength = 1f;
    [SerializeField] private float maxRopeLength = 20f;
    private float loadMass = 3f;
    float winchSpeed = 2f;

    [SerializeField] private bool isFloaterFishingRod;

    private List<RopeSegment> ropeSegments = new List<RopeSegment>();
    private float ropeSegmentLength = 0.25f;
    private int segmentCount = 20;
    private float lineWidth = 0.01f;

    
    private SpringJoint springJoint;
    private Rigidbody rbWhatIsHangingFromTheRope;
    private Rigidbody rbCast;

    private bool isCastFishingRod = false;
    private Buoyancy buoyancyController = null;
    private bool isReadyFishingRod = true;

    void Start()
    {
        ropeLength = readyRopelength;

        rbWhatIsHangingFromTheRope = whatIsHangingFromTheRope.GetComponentInParent<Rigidbody>();
        
        springJoint = whatTheRopeIsConnectedTo.GetComponentInParent<SpringJoint>();
        springJoint.anchor = whatTheRopeIsConnectedTo.localPosition;
        springJoint.connectedAnchor = whatIsHangingFromTheRope.localPosition;

        buoyancyController = whatIsHangingFromTheRope.GetComponentInParent<Buoyancy>();
        rbCast = rbWhatIsHangingFromTheRope;

        if (isFloaterFishingRod)
        {
            rbCast = whatIsHangingFromTheRope.gameObject.GetComponentInParent<FishingLineController>().
                whatIsHangingFromTheRope.gameObject.GetComponentInParent<Rigidbody>();

            buoyancyController = rbCast.gameObject.GetComponent<Buoyancy>();
        }
        
        lineRenderer = GetComponentInParent<LineRenderer>();

        Vector3 ropeStartPoint = Vector3.zero;
        segmentCount = (int)(ropeLength * (1 / ropeSegmentLength)) + 1;
        for (int i = 0; i < segmentCount; i++)
        {
            ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y += ropeSegmentLength;
        }
        
        UpdateSpring();
        
        rbWhatIsHangingFromTheRope.mass = loadMass;
    }
	
	void Update()
    {
        if (isReadyFishingRod)
        {
            if (rbWhatIsHangingFromTheRope.velocity.magnitude > 5f)
                rbWhatIsHangingFromTheRope.drag = 0.5f;
            else
                rbWhatIsHangingFromTheRope.drag = 0f;
        }

        if (buoyancyController != null && buoyancyController.GetIsUnderWater() && isCastFishingRod)
        {
            isCastFishingRod = false;

            float distance = Vector3.Distance(whatTheRopeIsConnectedTo.position, whatIsHangingFromTheRope.position);

            ropeLength = distance + 1f;
            ropeLength = Mathf.Clamp(ropeLength, minRopeLength, maxRopeLength);
            

            UpdateSpring();
        }
        InitRope();
        DisplayRope();
    }

    private void FixedUpdate()
    {
        Simulation();
    }

    #region Rope

    private void InitRope()
    {
        float dist = ropeLength;

        int tempSegmentCount = (int)(ropeLength * (1 / ropeSegmentLength)) + 1;
        if (tempSegmentCount > ropeSegments.Count)
        {
            Vector3 ropeStartPoint = ropeSegments[ropeSegments.Count - 1].posNow;
            segmentCount = tempSegmentCount;
            ropeStartPoint.y += ropeSegmentLength;
            ropeSegments.Add(new RopeSegment(ropeStartPoint));
        }
        else if (tempSegmentCount < ropeSegments.Count)
        {
            segmentCount = tempSegmentCount;
            ropeSegments.RemoveAt(ropeSegments.Count - 1);
        }
    }

    private void Simulation()
    {
        Vector3 forceGravity = new Vector3(0f, -1f, 0f);

        for (int i = 1; i < ropeSegments.Count; i++)
        {
            RopeSegment currentSegment = ropeSegments[i];
            Vector3 velocity = currentSegment.posNow - currentSegment.posOld;
            currentSegment.posOld = currentSegment.posNow;

            RaycastHit hit;
            if (Physics.Raycast(currentSegment.posNow, -Vector3.up, out hit, 0.1f))
            {
                if (hit.collider != null)
                {
                    velocity = Vector3.zero;
                    forceGravity.y = 0f;
                }
            }
            
            currentSegment.posNow += velocity;
            currentSegment.posNow += forceGravity * Time.fixedDeltaTime;
            ropeSegments[i] = currentSegment;
        }

        for (int i = 0; i < 20; i++)
        {
            ApplySegment();
        }
    }

    private void ApplySegment()
    {
        RopeSegment firstSegment = ropeSegments[0];
        firstSegment.posNow = whatTheRopeIsConnectedTo.position;
        ropeSegments[0] = firstSegment;

        RopeSegment endSegment = ropeSegments[ropeSegments.Count - 1];
        endSegment.posNow = whatIsHangingFromTheRope.position;
        ropeSegments[ropeSegments.Count - 1] = endSegment;

        for (int i = 0; i < ropeSegments.Count - 1; i++)
        {
            RopeSegment firstSeg = ropeSegments[i];
            RopeSegment secondSeg = ropeSegments[i + 1];

            float dist = (firstSeg.posNow - secondSeg.posNow).magnitude;
            float error = Mathf.Abs(dist - ropeSegmentLength);
            Vector3 changeDir = Vector3.zero;

            if (dist > ropeSegmentLength)
            {
                changeDir = (firstSeg.posNow - secondSeg.posNow).normalized;
            }
            else if (dist < ropeSegmentLength)
            {
                changeDir = (secondSeg.posNow - firstSeg.posNow).normalized;
            }

            Vector3 changeAmount = changeDir * error;
            if (i != 0)
            {
                firstSeg.posNow -= changeAmount * 0.5f;
                ropeSegments[i] = firstSeg;
                secondSeg.posNow += changeAmount * 0.5f;
                ropeSegments[i + 1] = secondSeg;
            }
            else
            {
                secondSeg.posNow += changeAmount;
                ropeSegments[i + 1] = secondSeg;
            }
        }
    }

    private void DisplayRope()
    {
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePosition = new Vector3[ropeSegments.Count];
        for (int i = 0; i < ropeSegments.Count; i++)
        {
            ropePosition[i] = ropeSegments[i].posNow;
        }

        lineRenderer.positionCount = ropePosition.Length;
        lineRenderer.SetPositions(ropePosition);
    }


    private void UpdateSpring()
    {
        float density = 7750f;
        float radius = 0.02f;

        float volume = Mathf.PI * radius * radius * ropeLength;

        float ropeMass = volume * density;

        ropeMass += loadMass;
        
        float ropeForce = ropeMass * 9.81f;
        
        float kRope = 1000f;
        
        springJoint.spring = kRope * 1.0f;
        springJoint.damper = kRope * 0.05f;
        
        springJoint.maxDistance = ropeLength;
    }

    #endregion

    
    
    public void UpdateWinch(bool invert)
    {
        
        bool hasChangedRope = false;
        
        if (invert && ropeLength < maxRopeLength)
        {
            ropeLength += winchSpeed * Time.deltaTime;
            
            InitRope();
            
            rbWhatIsHangingFromTheRope.WakeUp();

            hasChangedRope = true;
        }
        else if (!invert && ropeLength > minRopeLength)
        {
            ropeLength -= winchSpeed * Time.deltaTime;
            
            rbWhatIsHangingFromTheRope.WakeUp();

            hasChangedRope = true;
        }


        if (hasChangedRope)
        {
            ropeLength = Mathf.Clamp(ropeLength, minRopeLength, maxRopeLength);

            UpdateSpring();
        }
    }

    public void CastFishingRod(float percentCast, Vector3 vec)
    {
        if (isCastFishingRod)
            return;
        
        float castPower = 10000f;
        float currentCastPower = castPower * (percentCast / 100f);

        float maxCastLength = 50f;
        ropeLength = maxCastLength * percentCast / 100f;
        ropeLength = Mathf.Clamp(ropeLength, minRopeLength, maxRopeLength);
        InitRope();
        UpdateSpring();
        
        rbCast.AddForce(vec * currentCastPower);

        isCastFishingRod = true;
    }

    public bool GetIsReady()
    {
        if (isFloaterFishingRod)
        {
            if (ropeLength + rbWhatIsHangingFromTheRope.gameObject.GetComponent<FishingLineController>()
                    .GetRopeLength() <= readyRopelength)
                return true;
            return false;
        }
        if (ropeLength <= readyRopelength)
            return true;
        return false;
    }

    public void SetIsReadyFishingRod(bool isReady)
    {
        isReadyFishingRod = isReady;
    }

    #region Floater

    public float GetRopeLength()
    {
        return ropeLength;
    }

    public void SetFishingRodFloaterDepth(float val)
    {
        ropeLength = readyRopelength - val;
        InitRope();
        UpdateSpring();
    }

    public void UpdateBobberDepth(bool isUp)
    {
        
        bool hasChangedRope = false;

        //More rope
        if (isUp && ropeLength < maxRopeLength)
        {
            ropeLength += winchSpeed * Time.deltaTime;
            
            InitRope();
            
            rbWhatIsHangingFromTheRope.WakeUp();

            hasChangedRope = true;
        }
        else if (!isUp && ropeLength > minRopeLength)
        {
            ropeLength -= winchSpeed * Time.deltaTime;
            
            rbWhatIsHangingFromTheRope.WakeUp();

            hasChangedRope = true;
        }


        if (hasChangedRope)
        {
            ropeLength = Mathf.Clamp(ropeLength, minRopeLength, maxRopeLength);

            UpdateSpring();
        }
    }
    

    #endregion

    

    public struct RopeSegment
    {
        public Vector3 posNow;
        public Vector3 posOld;

        public RopeSegment(Vector3 pos)
        {
            posNow = pos;
            posOld = pos;
        }
    }
}