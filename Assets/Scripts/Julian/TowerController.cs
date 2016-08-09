﻿/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Changes by: Julian Hopp         ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField]
    shootRadius shootRadius;

    public PoolPrefab BulletPrefab;
    public Transform BulletSpawnpoint;
    public int MulitShotCount = 0;
    public bool MultitargetingItem = false;
    public float Range = 10;
    public float ShootDelay = 1;
    private Renderer myRenderer;
    private Transform myTransform;
    [SerializeField]
    private float shootSpeed = 0;

    [SerializeField]
    private int damage;

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    private bool canShoot = true;
    private bool shooting;

    public bool CanShoot
    {
        get { return canShoot; }
        set { canShoot = value; }
    }

    private void Awake()
    {
        myTransform = GetComponent<Transform>();
        myRenderer = GetComponentInChildren<Renderer>();
    }

    private void CheckRangeForEnemies()
    {
        shootRadius.CheckList();
        shooting = false;
        if (shootRadius.EnemyList.Count > 0)
        {
            if (!shooting && canShoot)
            {
                shooting = true;

                GameObject newBomb = ObjectPool.Instance.GetPooledObject(BulletPrefab);
                newBomb.transform.position = BulletSpawnpoint.position;
                newBomb.GetComponent<LaserInfos>().Damage = damage;
                if (gameObject.name == "Tower")
                {
                    newBomb.gameObject.tag = "TowerLaser";
                }
                else if (gameObject.name == "SlowTower")
                {
                    newBomb.gameObject.tag = "TowerLaserSlow";
                }
                Rigidbody laserBody = newBomb.GetComponent<Rigidbody>();
                laserBody.transform.LookAt(shootRadius.EnemyList[0].transform);
                laserBody.AddForce(laserBody.transform.forward * shootSpeed * Time.deltaTime, ForceMode.Impulse);

            }
            shootRadius.CheckList();
        }
    }

    private void ResetBullet(BulletController bullet)
    {
        bullet.transform.position = BulletSpawnpoint.position;
        bullet.gameObject.SetActive(true);
    }

    private void Start()
    {
        InvokeRepeating("CheckRangeForEnemies", 0, ShootDelay);
    }
}
