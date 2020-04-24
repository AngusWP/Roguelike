using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public GameObject projectile;
    public float minDamage, maxDamage;
    public float projectileForce;
    
    public float cooldownRangeMin;
    public float cooldownRangeMax;

    public Transform player;

    private Vector2 direction;

    void Start() {
        StartCoroutine(shootPlayer());
    }

    IEnumerator shootPlayer() {
        yield return new WaitForSeconds(Random.Range(cooldownRangeMin, cooldownRangeMax));

        if (player != null) {
                GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
                Vector2 characterPos = transform.position;
                Vector2 targetPos = player.position;
                Vector2 direction = (targetPos - characterPos).normalized;
                spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
                spell.GetComponent<EnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
                StartCoroutine(shootPlayer());
        }
    }

    void Update() {

    }
}
