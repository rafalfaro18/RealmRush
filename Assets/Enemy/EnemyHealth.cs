using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] //auto imports Enemy component when importing EnemyHealth comp.
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;
    
    Enemy enemy;
    
    void Start(){
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitPoints--;
        if (currentHitPoints <= 0){
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
