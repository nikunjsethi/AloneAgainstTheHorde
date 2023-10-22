using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent enemyNav;
    Transform player;
    public Animator zombie;
    public ParticleSystem bloodEffect;
    [Header("Audios")]
    public AudioSource _EnemyAudioSource;
    public AudioClip[] _enemyClips;


    public int hitCount;
    bool isAlive=true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyNav = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive == true)
        {
            enemyNav.SetDestination(player.position);

            if (Vector3.Distance(player.position, gameObject.transform.position) > 8)
            {
                zombie.SetBool("walk", true);
                zombie.SetBool("run", false);
                _EnemyAudioSource.clip = _enemyClips[0];
                _EnemyAudioSource.Play();
            }
            else
            {
                zombie.SetBool("walk", false);
                zombie.SetBool("run", true);
            }

            if (hitCount > 3)
            {
                zombie.SetBool("walk", false);
                zombie.SetBool("run", false);
                zombie.SetBool("injured", true);
            }

            if(Vector3.Distance(player.position, gameObject.transform.position) <= 1)
            {
                zombie.SetBool("run", false);
                zombie.SetBool("injured", false);
                zombie.SetBool("attack", true);
            }
            else
            {
                zombie.SetBool("attack", false);
            }
        }
        if (hitCount > 7)
        {
            zombie.SetBool("walk", false);
            zombie.SetBool("run", false);
            zombie.SetBool("injured", false);
            zombie.SetBool("attack", false);
            zombie.SetBool("die", true);
            enemyNav.enabled = false;
            isAlive = false;
            _EnemyAudioSource.clip = _enemyClips[2];
            _EnemyAudioSource.Play();
            this.enabled = false;   //this line will stop the update function
            Destroy(gameObject, 5);
        }
    }
}
