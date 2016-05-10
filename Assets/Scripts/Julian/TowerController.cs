/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;

public class TowerController : MonoBehaviour
{
    public PoolPrefab BulletPrefab;
    public Transform BulletSpawnpoint;
    public int MulitShotCount = 0;
    public bool Multitargeting = false;
    public bool MultitargetingItem = false;
    public float Range = 10;
    public float ShootDelay = 1;
    private Renderer myRenderer;
    private Transform myTransform;

    private void Awake()
    {
        myTransform = GetComponent<Transform>();
        myRenderer = GetComponentInChildren<Renderer>();
    }

    private void CheckRangeForEnemies()
    {
        Collider[] colliders = Physics.OverlapSphere(myTransform.position, Range);
        if (colliders != null)
        {
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    GameObject newBullet = ObjectPool.Instance.GetPooledObject(BulletPrefab);
                    BulletController newBulletController = newBullet.GetComponent<BulletController>();
                    newBulletController.Target = collider.transform;
                    ResetBullet(newBulletController);
                    MulitShotCount++;

                    if (!(MulitShotCount >= 5 && MultitargetingItem))
                    {
                        return;
                    }
                }
            }
            MulitShotCount = 0;
        }
    }

    private void ResetBullet(BulletController bullet)
    {
        bullet.transform.position = BulletSpawnpoint.position;
        bullet.SetColor(myRenderer.material.color);
        bullet.gameObject.SetActive(true);
    }

    private void Start()
    {
        InvokeRepeating("CheckRangeForEnemies", 0, ShootDelay);
    }
}
