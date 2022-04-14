using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    int amountOfDamage = 1;
    public float speed = 70;
    public int hitAmount = 1;
    public float aliveTimer = 7f;
    Vector3 dir;
    public void Seek(Transform _target)
    {
        target = _target;
        dir = target.position - transform.position;
        Destroy(gameObject, aliveTimer);
    }
    public void SetDamage(int _damage)
    {
        amountOfDamage = _damage;
    }
    void Update()
    {
        float distanceThisFrame = speed * Time.deltaTime;
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            HitTarget(col.gameObject.GetComponent<EnemyScript>());
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
    }
    void HitTarget(EnemyScript _hitEnemy)
    {
        _hitEnemy.loseHealth(amountOfDamage);
        hitAmount--;
        if (hitAmount <= 0)
            Destroy(gameObject);
    }
}
