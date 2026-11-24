using UnityEngine;

public class ConeheadZombie : Enemy
{
    public bool cone = true;
    public override void Serang()
    {
        base.Serang();
        Debug.Log("Cone Gigit");
    }
}
