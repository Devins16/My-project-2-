using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RopeController : MonoBehaviour
{
    public Transform hook; 
    public Transform fishingRod;  
    public GameObject ropeSegmentPrefab;  
    public int initialSegmentCount = 10;  
    public float segmentLength = 0.5f;  
    public float lineWidth = 0.05f;  
    public float maxSegmentDistance = 2.0f;  
    public float delayBeforeAttach = 1.0f;  

    private List<GameObject> ropeSegments = new List<GameObject>();
    private LineRenderer lineRenderer;

    void Start()
    {
        StartCoroutine(DelayedCreateRope());
        InitializeLineRenderer();
    }

    IEnumerator DelayedCreateRope()
    {
       
        yield return new WaitForSeconds(delayBeforeAttach);
       
        CreateInitialRope();
    }

    void CreateInitialRope()
    {
        Vector3 segmentPosition = fishingRod.position;
        Rigidbody2D previousRB = fishingRod.GetComponent<Rigidbody2D>();

        for (int i = 0; i < initialSegmentCount; i++)
        {
            GameObject segment = Instantiate(ropeSegmentPrefab, segmentPosition, Quaternion.identity);
            ropeSegments.Add(segment);

            HingeJoint2D joint = segment.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;
            joint.autoConfigureConnectedAnchor = false;
            joint.anchor = new Vector2(0, -segmentLength / 2);
            joint.connectedAnchor = new Vector2(0, segmentLength / 2);

            segmentPosition.y -= segmentLength;
            previousRB = segment.GetComponent<Rigidbody2D>();
        }

        HingeJoint2D hookJoint = hook.gameObject.AddComponent<HingeJoint2D>();
        hookJoint.connectedBody = previousRB;
        hookJoint.autoConfigureConnectedAnchor = false;
        hookJoint.anchor = Vector2.zero;
        hookJoint.connectedAnchor = new Vector2(0, segmentLength / 2);

       
    }

    void InitializeLineRenderer()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = initialSegmentCount + 2;  
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
    }

    void Update()
    {
        UpdateLineRenderer();
        CheckAndAddSegment();
    }

    void UpdateLineRenderer()
    {
        if (ropeSegments.Count == 0) return;

        lineRenderer.positionCount = ropeSegments.Count + 2;
        lineRenderer.SetPosition(0, fishingRod.position);

        for (int i = 0; i < ropeSegments.Count; i++)
        {
            lineRenderer.SetPosition(i + 1, ropeSegments[i].transform.position);
        }

        lineRenderer.SetPosition(ropeSegments.Count + 1, hook.position);
    }

    void CheckAndAddSegment()
    {
        if (ropeSegments.Count == 0) return;

        GameObject lastSegment = ropeSegments[ropeSegments.Count - 1];
        float distanceToHook = Vector3.Distance(lastSegment.transform.position, hook.position);

        if (distanceToHook > maxSegmentDistance)
        {
            AddSegment();
        }
    }

    void AddSegment()
    {
        GameObject lastSegment = ropeSegments[ropeSegments.Count - 1];
        Vector3 newSegmentPosition = lastSegment.transform.position - new Vector3(0, segmentLength, 0);

        GameObject newSegment = Instantiate(ropeSegmentPrefab, newSegmentPosition, Quaternion.identity);
        ropeSegments.Add(newSegment);

        HingeJoint2D joint = newSegment.GetComponent<HingeJoint2D>();
        joint.connectedBody = lastSegment.GetComponent<Rigidbody2D>();
        joint.autoConfigureConnectedAnchor = false;
        joint.anchor = new Vector2(0, -segmentLength / 2);
        joint.connectedAnchor = new Vector2(0, segmentLength / 2);

        HingeJoint2D hookJoint = hook.GetComponent<HingeJoint2D>();
        hookJoint.connectedBody = newSegment.GetComponent<Rigidbody2D>();

        
    }
}
