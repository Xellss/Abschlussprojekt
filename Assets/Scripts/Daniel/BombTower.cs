/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///     Author: Daniel Lause & Julian Hopp    ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class BombTower : MonoBehaviour {

    [SerializeField]
    private PoolPrefab bombPrefab;
    [SerializeField]
    private float shootSpeed;
    [SerializeField]
    shootRadius shootRadius;
    public PoolPrefab BombPrefab
    {
        get { return bombPrefab; }
        set { bombPrefab = value; }
    }
    [SerializeField]
    private Transform bombSpawn;

    public Transform BombSpawn
    {
        get { return bombSpawn; }
        set { bombSpawn = value; }
    }

    [SerializeField]
    private float towerRange;

    [SerializeField]
    private float shootDelay;
    private Transform target;

    private bool shooting;
    private bool canShoot=true;

    public bool CanShoot
    {
        get { return canShoot; }
        set { canShoot = value; }
    }

    private void shoot()
    {
        //shooting = false;
        //Collider[] colliders = Physics.OverlapSphere(transform.position, towerRange);
        //if (colliders != null)
        //{
        //    foreach (var collider in colliders)
        //    {
        //        if (collider.CompareTag("Enemy") && !shooting && canShoot)
        //        {
        //            shooting = true;
        //            GameObject newBomb = ObjectPool.Instance.GetPooledObject(bombPrefab);
        //            newBomb.transform.position = bombSpawn.transform.position;
        //            Rigidbody laserBody = newBomb.GetComponent<Rigidbody>();
        //            laserBody.transform.LookAt(collider.transform);
        //            laserBody.AddForce(laserBody.transform.forward * shootSpeed * Time.deltaTime, ForceMode.Impulse);
        //        }
        //    }
        //}


        //shooting = false;
        //if (shootRadius.EnemyList.Count > 0)
        //{
        //    if (shooting && canShoot)
        //    {
        //        shooting = true;
        //        GameObject newBomb = ObjectPool.Instance.GetPooledObject(bombPrefab);
        //        newBomb.transform.position = bombSpawn.transform.position;
        //        Rigidbody laserBody = newBomb.GetComponent<Rigidbody>();
        //        laserBody.transform.LookAt(shootRadius.EnemyList[0].transform);
        //        laserBody.AddForce(laserBody.transform.forward * shootSpeed * Time.deltaTime, ForceMode.Impulse);
        //    }
        //}



        shooting = false;
        if (shootRadius.EnemyList.Count > 0)
        {
            if (!shooting && canShoot)
            {
                shooting = true;
                shootRadius.CheckList();
                GameObject newBomb = ObjectPool.Instance.GetPooledObject(bombPrefab);
                newBomb.transform.position = bombSpawn.position;
                //newBomb.GetComponent<LaserInfos>().Damage = damage;
                //newBomb.gameObject.tag = "TowerLaser";
                Rigidbody laserBody = newBomb.GetComponent<Rigidbody>();
                laserBody.transform.LookAt(shootRadius.EnemyList[0].transform);
                laserBody.AddForce(laserBody.transform.forward * shootSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
                StartCoroutine(destoyBomb(newBomb));
                shootRadius.CheckList();

            }
        }
    }

    private void ResetBullet(BulletController bullet)
    {
        bullet.transform.position = bombSpawn.position;
        //bullet.SetColor(myRenderer.material.color);
        bullet.gameObject.SetActive(true);
    }
    IEnumerator destoyBomb(GameObject bomb)
    {
        yield return new WaitForSeconds(8);
        bomb.SetActive(false);
    }
    private void Start()
    {
        //StartCoroutine(shoot());
        InvokeRepeating("shoot", 0, shootDelay);

    }

}
