using UnityEngine;

public class BucketHeadZombie : Enemy
{
    public bool bucket = true;
    public override void Serang()
    {
        base.Serang();
        Debug.Log("Cone Gigit");
    }
}
