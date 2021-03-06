using UnityEngine;

public class MinePerk : BasePerk
{
    public override string perkIcon { get { return "Mine"; } }

    [SerializeField] private GameObject _particles;

    private float _explosionRadius = 5;
    private float _explosionForce = 500000;

    public override void usePerk(GameObject perk, GameObject gameObject)
    {
        Transform carTransform = gameObject.transform;
        Instantiate(this, carTransform.position - (carTransform.forward * 4f), carTransform.rotation);
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

        GameObject explosion = Instantiate(_particles, transform.position, Quaternion.identity);
        other.GetComponentInParent<HealthController>().TakeDamage(50f);
        Destroy(explosion, 2f);
        
        Destroy(gameObject);
    }
}