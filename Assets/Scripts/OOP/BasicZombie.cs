using UnityEngine;

public class BasicZombie : Enemy
{
    public override void Serang()
    {
        base.Serang();
        Debug.Log("Zombie Gigit");
    }
}
