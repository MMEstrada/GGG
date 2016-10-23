using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public float speed;
    public float paceLength;
    public float originalXPosition;
    public bool facingRight = false;

    private int timer = 0;

    public Transform target;
    public float targetDistance;

    private Rigidbody rb;
    private Animator anim;
    private NavMeshAgent agent;


	// Use this for initialization
	void Start () {

        originalXPosition = transform.position.x;

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {

        targetDistance = Vector3.Distance(target.position, transform.position);
        if (timer == 20)
        {
            if (targetDistance > 20)
            {
                agent.enabled = false;
                Walking();
            }
            else if (targetDistance < 20)
            {
                agent.enabled = true;
                agent.updateRotation = false;
                agent.SetDestination(target.position);
            }
            else if (targetDistance < 5)
            {
                Attack();
            }
        }
        else if (timer < 20)
        {
            timer++;
            Debug.Log(timer);
        }
    }

    void Walking()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (Mathf.Abs(originalXPosition - transform.position.x) > paceLength)
        {
            speed *= -1;
            //Flip();
        }
    }

    void Attack()
    {
        
    }


    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale *= -1;
    }
}
