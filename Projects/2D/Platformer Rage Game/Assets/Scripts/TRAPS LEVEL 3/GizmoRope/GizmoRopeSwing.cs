using UnityEngine;
using TMPro;
public class GizmoRopeSwing : MonoBehaviour
{
    [SerializeField] private HingeJoint2D swingJoint;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject GizmoGrapple;
    [SerializeField] private TextMeshProUGUI gizmoGrappleTimer;
    [SerializeField] private float detachCooldown = 0f;
    [SerializeField] private float swingForce = 10f;
    [SerializeField] private float jumpBoost = 300f;
    [SerializeField] private float cooldownTime = 0.5f;
    [SerializeField] private float gizmoGrappleTimerDelay;
    [SerializeField] private float gizmoGrappleDisableTimer;
    [SerializeField] private bool isSwinging = false;
    [SerializeField] private bool hasStartedTimer = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isSwinging)
        {
            float input = Input.GetAxisRaw("Horizontal");
            rb.AddForce(new Vector2(input * swingForce, 0f));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                DetachFromRope();
            }

            if (!hasStartedTimer && GizmoGrapple != null)
            {
                gizmoGrappleDisableTimer = gizmoGrappleTimerDelay;
                hasStartedTimer = true;
            }
        }

        if (detachCooldown > 0f)
        {
            detachCooldown -= Time.deltaTime;
        }

        if (hasStartedTimer && GizmoGrapple != null && gizmoGrappleDisableTimer > 0f)
        {
            gizmoGrappleDisableTimer -= Time.deltaTime;
            gizmoGrappleTimer.text = gizmoGrappleDisableTimer.ToString("F1"); 
            if (gizmoGrappleDisableTimer <= 0f)
            {
                GizmoGrapple.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isSwinging || detachCooldown > 0f) return;

        if (other.CompareTag("Player"))
        {
            Rigidbody2D ropeRb = other.GetComponent<Rigidbody2D>();
            if (ropeRb != null)
            {
                swingJoint = gameObject.AddComponent<HingeJoint2D>();
                swingJoint.connectedBody = ropeRb;
                swingJoint.autoConfigureConnectedAnchor = false;
                swingJoint.anchor = Vector2.zero;
                swingJoint.connectedAnchor = Vector2.zero;

                isSwinging = true;
                rb.gravityScale = 2f;
            }
        }
    }

    private void DetachFromRope()
    {
        if (swingJoint != null)
        {
            Destroy(swingJoint);
            swingJoint = null;
        }

        isSwinging = false;
        rb.AddForce(Vector2.up * jumpBoost);

        detachCooldown = cooldownTime;
    }
}
