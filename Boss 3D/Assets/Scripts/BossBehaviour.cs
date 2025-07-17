using UnityEngine;

public enum BossAtacks 
{
    Close, Area, Renge
}


public class BossBehaviour : MonoBehaviour
{
    [SerializeField] float life = 100;
    [SerializeField] float maxLife;
     
    BossAtacks atacks;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxLife = life;
    }

    // Update is called once per frame
    void Update()
    {
        if(maxLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
