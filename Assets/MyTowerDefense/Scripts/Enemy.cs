using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float StartSpeed = 10f;

    [HideInInspector]
    public float speed;

    private float health;
    public float  StartHealth = 100;

    public int MoneyGain = 20;

    public GameObject deathEffect;

    public Image HealthBar;

    private void Start()
    {
        speed = StartSpeed;
        health = StartHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        HealthBar.fillAmount = health / StartHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = StartSpeed * (1f - pct);

    }

    public bool isDead = false;

    void Die()
    {
        isDead = true;

        PlayerStats.Money += MoneyGain;
        WaveSpawner.EnemiesAlive--;
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

}
