using UnityEngine;

public class Frog : EnemyNameSpace.Enemy
{
    protected override void Attack()
    {
        Debug.Log("Jump");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Hp = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
