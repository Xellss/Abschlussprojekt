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
    private EnemyTypes enemyType;
    [SerializeField]
    private bool canShot;
    [SerializeField]
    private int damage;
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
    private Transform waypointArray;
    private Transform[] waypointObjects;
    private EnemyHP enemyHP;
    private bool carrierTrigger;

    [SerializeField]
    private float tankRange;

    [SerializeField]
    private string wayPointContainerName;
    GameObject sun;
    [SerializeField]
    private Transform target;

    private Vector3[] waypoints;
    Tween t;
    private void Awake()
    {
        waypointArray = GameObject.Find(wayPointContainerName).transform;
        waypointObjects = waypointArray.Cast<Transform>().ToArray();
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

    private void Start()
    {
        enemyHP = GetComponent<EnemyHP>();
        setPath();
        laserSpeed = laserSpeed * 1000;
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
                //StartCoroutine(carrierShotWithDelay());
                carrierTrigger = false;
            }
            shotNow = false;
        }
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
    }
}
