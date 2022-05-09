using System.Collections;
using UnityEngine;

public class MissileController : MonoBehaviour
{

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
        target = GameObject.FindGameObjectWithTag("PoliceNPC");
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Instantiate(_explosion, transform.position + new Vector3(0, 0, 5), Quaternion.identity);
            Destroy(gameObject);
        }

        if (homing && target != null)
        {
            Vector3 pointToTarget = transform.position - target.transform.position;
            pointToTarget.Normalize();

            float value = Vector3.Cross(pointToTarget, transform.up).y;

            rb.angularVelocity = 5f * value * Vector3.up;
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

        Instantiate(_explosion, transform.position + new Vector3(0, 0, 5), Quaternion.identity);
        Destroy(gameObject);
    }

}
