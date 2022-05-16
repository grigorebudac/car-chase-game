using System.Collections;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    
    public LayerMask layerMask;
    private Vector3 origin;
    private Vector3 direction;
    private float sphereRadius = 20f;
    private RaycastHit hit;
    
    [SerializeField]
    private float distance = 35f;
    
    
    [Header("MISSILE SETUP")]
    [SerializeField] private GameObject _explosion;
    [SerializeField] private float timer = 5;

    [Header("SELF GUIDED")]
    [Space(5)]
    [SerializeField]
    private bool homing = false;

    [Header("MOVEMENT")]
    [Space(5)]
    [SerializeField] private float speed = 50f;

    private Rigidbody rb;
    private float _explosionRadius = 5;
    private float _explosionForce = 500000;
    private GameObject target;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.transform.Rotate(90f, 0f, 0f);
        transform.position = new Vector3(transform.position.x, 0.4f, transform.position.z);
    }

    private void Update()
    {
        if (Physics.SphereCast(transform.position, sphereRadius,  transform.position + transform.up * distance, out hit, 1000, layerMask, QueryTriggerInteraction.UseGlobal))
        {
                if (hit.transform.gameObject.tag == "Player")
                {
                    target = hit.transform.gameObject;
                } if (hit.transform.gameObject.tag == "PolicePlayer")
                {
                    target = hit.transform.gameObject;
                } if (hit.transform.gameObject.tag == "PoliceNPC")
                {
                    target = hit.transform.gameObject;
                }
        }
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            GameObject explosion = Instantiate(_explosion, transform.position + new Vector3(0, 0, 5) , Quaternion.identity);
            Destroy(explosion, 2f);
            Destroy(gameObject);
        }

        if (homing)
        {
            if (target != null)
            {
                Vector3 pointToTarget = transform.position - target.transform.position;
                pointToTarget.Normalize();
                float value = Vector3.Cross(pointToTarget, transform.up).y;

                rb.angularVelocity = 5f * value * Vector3.up;
            }
            rb.velocity = transform.up * speed * 3f;
        }
        else
        {
            rb.AddForce(transform.up * speed, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var surroundingObjects = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (var obj in surroundingObjects)
        {
            var rb = obj.GetComponent<Rigidbody>();
            if (obj.gameObject.name == "CarCollider")
            {
                rb = obj.gameObject.GetComponentInParent<Rigidbody>();
            }
            if (rb == null) continue;

            rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, 1);
        }

        GameObject explosion = Instantiate(_explosion, transform.position + new Vector3(0, 0, 5) , Quaternion.identity);
        Destroy(explosion, 2f);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {

            Gizmos.color = Color.green;
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.up * distance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireSphere(transform.position + transform.up * distance, sphereRadius);
        
    }
}
