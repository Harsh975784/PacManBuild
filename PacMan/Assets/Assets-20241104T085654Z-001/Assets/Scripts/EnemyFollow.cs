using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private GameObject followPlayer;
    [SerializeField] private GameObject[] bullet;
    [SerializeField] private byte speed = 70;
    private int maxSpeed = 1;
    private int minSpeed = 0;
    private bool agentStay, agentChase;
    NavMeshAgent agent;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agentStay = true;
        agentChase = false;
        StartCoroutine(Timer(6));
    }
    private void FixedUpdate()
    {
        if (agentChase)
        {
            agent.speed = maxSpeed;
            agent.SetDestination(followPlayer.transform.position);
        }
    }
    public virtual IEnumerator Timer(int time)
    {
        agent.speed = minSpeed;
        yield return new WaitForSeconds(time);
        agentStay = false;
        agentChase = true;
    }
    public virtual void AngryAttack()
    {
        agent.speed += 1;
        spriteRenderer.color = Color.magenta;
    }
    public virtual void Shoot()
    {
     
    }
}
