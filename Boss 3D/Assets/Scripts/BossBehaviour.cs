using System.Collections;
using UnityEngine;

public enum BossAtacks 
{
    Close, Area, Renge
}


public class BossBehaviour : MonoBehaviour
{
    [SerializeField] GameObject spear;
    [SerializeField] Transform spearPos;
    [SerializeField] float life = 100;
    [SerializeField] float maxLife;
    [SerializeField] Transform player;
    float range;
    
    Animator animator;
    BossAtacks atacks;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxLife = life;
        animator = GetComponent<Animator>();
        ChangeBehaviour(BossAtacks.Close);
    }

    // Update is called once per frame
    void Update()
    {
        if(maxLife <= 0)
        {
            Destroy(gameObject);
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > range)
        {
            StartCoroutine(ChangeBehaviour(BossAtacks.Renge));
            ChangeBehaviour(BossAtacks.Renge);
        }
            

        if (distance < range)
            ChangeBehaviour(BossAtacks.Close);
    }

    IEnumerator ChangeBehaviour(BossAtacks behaviour)
    {
        switch (behaviour) 
        {
            case BossAtacks.Close:
                animator.SetFloat("Atack", range);
                break;
            case BossAtacks.Area:
                yield return null;
                break;
            case BossAtacks.Renge:
                Instantiate(spear);
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            Destroy(collision.gameObject);
    }
}
