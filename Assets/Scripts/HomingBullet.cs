using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float speed = 5f;
    public float rotationSpeed = 200f;
    public string targetTag = "Animal";

    private Transform target;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        target = null;
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        FindClosestTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            FindClosestTarget();
        }
    }

    private void FixedUpdate()
    {
        if(target != null) {
            Vector3 direction = target.position - rb.position;

            if(direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
            }
        }
        rb.linearVelocity = transform.forward * speed;
    }

    void FindClosestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        float closestDistance = Mathf.Infinity;
        Transform closestTarget = null;

        foreach (GameObject potentialTarget in targets)
        {
            float distance = Vector3.Distance(transform.position, potentialTarget.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = potentialTarget.transform;
            }
        }
        target = closestTarget;
    }
}
