using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public int damage = 40;

    public GameObject effectImpact;
    public float ExplodeRadius = 0f;

    public void Seek(Transform _target)
    {
        target = _target;
    }


    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effect = Instantiate(effectImpact, target.position, target.rotation);
        Destroy(effect, 5f);
        if (ExplodeRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
        return;
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplodeRadius);
        foreach (Collider collider in colliders) 
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
        return;
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if(e != null)
        {
            e.TakeDamage(damage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplodeRadius);
    }
}
