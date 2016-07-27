/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using DG.Tweening;
using System.Collections;
using System.Linq;
using UnityEngine;

public enum EnemyTypes
{
    Normal,
    Tank,
    Carrier,
}

public class EnemyKi : MonoBehaviour
{
    [SerializeField]
    private bool canShot;
    private bool carrierTrigger;
    [SerializeField]
    private int damage;
    private EnemyHP enemyHP;
    [SerializeField]
    private EnemyTypes enemyType;

    [SerializeField, Tooltip("lower = faster")]
    private int flySpeed = 0;

    private RaycastHit hit;

    [SerializeField]
    private PoolPrefab laserBullet;

    [SerializeField]
    private GameObject laserSpawnPosition;

    [SerializeField]
    private float laserSpeed;

    private GameObject newLaser;

    [SerializeField]
    private PathType pathType = PathType.CatmullRom;

    [SerializeField]
    private float shotDelay;

    [SerializeField]
    private bool shotNow;

    private GameObject sun;

    private Tween t;

    [SerializeField]
    private float tankRange;

    [SerializeField]
    private Transform target;

    shootRadius shootRadius;
    private Transform waypointArray;

    [SerializeField]
    private string wayPointContainerName;

    private Transform[] waypointObjects;

    private Vector3[] waypoints;

    public EnemyTypes EnemyType
    {
        get { return enemyType; }
        set { enemyType = value; }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarrierTrigger")
        {
            GameObject sun = GameObject.Find("Sun").gameObject;
            newLaser = ObjectPool.Instance.GetPooledObject(laserBullet);
            newLaser.GetComponent<LaserInfos>().Damage = damage;
            newLaser.transform.position = laserSpawnPosition.transform.position;
            Rigidbody laserBody = newLaser.GetComponent<Rigidbody>();
            laserBody.transform.LookAt(sun.transform);
            laserBody.AddForce(laserBody.transform.forward * laserSpeed * Time.deltaTime, ForceMode.Impulse);
        }

        if (other.gameObject.tag == "TowerLaser")
        {
            LaserInfos laserinfo = other.GetComponent<LaserInfos>();
            enemyHP.Decrease(laserinfo.Damage);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "ShootRadius")
        {
            shootRadius = other.GetComponent<shootRadius>();
            shootRadius.EnemyList.Add(transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ShootRadius")
        {
            shootRadius = other.GetComponent<shootRadius>();
            shootRadius.EnemyList.Remove(transform);
        }
    }

    private void Awake()
    {
        waypointArray = GameObject.Find(wayPointContainerName).transform;
        waypointObjects = waypointArray.Cast<Transform>().ToArray();
    }

    private IEnumerator carrierShotWithDelay()
    {
        if (canShot)
        {
            GameObject sun = GameObject.Find("Sun");
            newLaser = ObjectPool.Instance.GetPooledObject(laserBullet);
            newLaser.GetComponent<LaserInfos>().Damage = damage;
            newLaser.transform.position = laserSpawnPosition.transform.position;
            Rigidbody laserBody = newLaser.GetComponent<Rigidbody>();
            laserBody.transform.LookAt(sun.transform);
            laserBody.AddForce(transform.forward * laserSpeed * Time.deltaTime, ForceMode.Impulse);
            yield return new WaitForSeconds(0);
        }
    }

    private IEnumerator normalShotWithDelay()
    {
        if (canShot)
        {
            Ray ray = new Ray(laserSpawnPosition.transform.position, transform.forward);
            Physics.Raycast(ray, out hit);
            if (hit.collider != null && hit.collider.gameObject.tag == "Building")
            {
                newLaser = ObjectPool.Instance.GetPooledObject(laserBullet);
                newLaser.GetComponent<LaserInfos>().Damage = damage;
                newLaser.transform.position = laserSpawnPosition.transform.position;
                Rigidbody laserBody = newLaser.GetComponent<Rigidbody>();
                laserBody.transform.LookAt(transform.forward);
                laserBody.AddForce(transform.forward * laserSpeed * Time.deltaTime, ForceMode.Impulse);
                yield return new WaitForSeconds(shotDelay);
            }
            else
                yield return new WaitForSeconds(0);
            StartCoroutine(normalShotWithDelay());
        }
    }

    private void setPath()
    {
        waypoints = new Vector3[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            waypoints[i] = waypointObjects[i].position;
        }
        t = transform.DOPath(waypoints, flySpeed, pathType)
           .SetOptions(false)
           .SetAutoKill(false)
           .SetEase(Ease.Linear).SetLoops(0)
           .SetLookAt(0.001f);
    }

    private void Start()
    {
        enemyHP = GetComponent<EnemyHP>();
        setPath();
        laserSpeed = laserSpeed * 1000;
    }

    private IEnumerator tankShotWithDelay()
    {
        if (canShot)
        {
            if (target != null && target.gameObject.tag == "Building")
            {
                newLaser = ObjectPool.Instance.GetPooledObject(laserBullet);
                newLaser.GetComponent<LaserInfos>().Damage = damage;
                newLaser.transform.position = laserSpawnPosition.transform.position;
                Rigidbody laserBody = newLaser.GetComponent<Rigidbody>();
                laserBody.transform.LookAt(target);
                laserBody.AddForce(laserBody.transform.forward * laserSpeed * Time.deltaTime, ForceMode.Impulse);
                yield return new WaitForSeconds(shotDelay);
            }
            else
            {
                Collider[] collider = Physics.OverlapSphere(transform.position, tankRange);
                foreach (var coll in collider)
                {
                    if (coll.gameObject.tag == "Building")
                    {
                        target = coll.transform;
                    }
                }
                yield return null;
            }
            StartCoroutine(tankShotWithDelay());
        }
    }

    private void Update()
    {
        if (!t.IsPlaying() && enemyType != EnemyTypes.Carrier)
        {
            for (int i = 0; i < waypointObjects.Length; i++)
            {
                waypoints[i] = waypointObjects[i].position;
            }
            t = transform.DOPath(waypoints, flySpeed, pathType)
               .SetOptions(true)
               .SetLookAt(0.001f);

            t.SetEase(Ease.Linear).SetLoops(-1);
        }
        else if (!t.IsPlaying() && enemyType == EnemyTypes.Carrier)
        {
            t.Kill();
            enemyHP.Decrease(enemyHP.CurrentHealth);
        }
        if (shotNow)
        {
            if (enemyType == EnemyTypes.Normal)
                StartCoroutine(normalShotWithDelay());
            else if (enemyType == EnemyTypes.Tank)
                StartCoroutine(tankShotWithDelay());
            else if (enemyType == EnemyTypes.Carrier && carrierTrigger)
            {
                carrierTrigger = false;
            }
            shotNow = false;
        }
    }

    public void OnDisable()
    {
        if (shootRadius != null)
        {

        shootRadius.EnemyList.Remove(transform);
        }
        t.Kill(true);
    }
}
