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
    invisible,
}

public class EnemyKi : MonoBehaviour
{
    EnemyInfo enemyInfo = new EnemyInfo();

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

    public int FlySpeed
    {
        get { return FlySpeed; }
        set { FlySpeed = value; }
    }


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

    [SerializeField]
    GameObject particleFlyEffect;
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

    Rigidbody myRigid;

    private bool canFly = true;

    public bool CanFly
    {
        get { return canFly; }
        set { canFly = value; }
    }


    bool fly = false;

    [SerializeField]
    GameObject visibleModel;

    [SerializeField]
    GameObject invisibleModel;

    [SerializeField]
    float invisibleDuration;

    [SerializeField]
    float invisibleDelay;
    public bool radarTowerDetect = false;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BaseShield")
        {
            sun.GetComponent<BuildingHealth>().RemoveHealth(damage);
            enemyHP.Decrease(enemyHP.CurrentHealth);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.tag == "ShootRadius")
        //{
        //    shootRadius = other.GetComponent<shootRadius>();
        //    shootRadius.EnemyList.Add(transform);
        //}
    }

    public void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "CarrierTrigger")
        //{
        //    GameObject sun = GameObject.Find("Sun").gameObject;
        //    newLaser = ObjectPool.Instance.GetPooledObject(laserBullet);
        //    newLaser.GetComponent<LaserInfos>().Damage = damage;
        //    newLaser.transform.position = laserSpawnPosition.transform.position;
        //    Rigidbody laserBody = newLaser.GetComponent<Rigidbody>();
        //    laserBody.transform.LookAt(sun.transform);
        //    laserBody.AddForce(laserBody.transform.forward * laserSpeed * Time.deltaTime, ForceMode.Impulse);
        //}

        if (other.gameObject.tag == "TowerLaser")
        {
            LaserInfos laserinfo = other.GetComponent<LaserInfos>();
            enemyHP.Decrease(laserinfo.Damage);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "TowerTesla")
        {
            LaserInfos laserinfo = other.GetComponent<LaserInfos>();
            enemyHP.Decrease(laserinfo.Damage);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "TowerLaserSlow")
        {
            LaserInfos laserinfo = other.GetComponent<LaserInfos>();
            enemyHP.Decrease(laserinfo.Damage);

            flySpeed /= 2;
            if (flySpeed < 100)
            {
                flySpeed = 100;
            }

            myRigid.velocity = Vector3.zero;
            myRigid.AddForce(transform.forward * flySpeed * Time.fixedDeltaTime, ForceMode.Impulse);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "ShootRadius")
        {
            shootRadius = other.GetComponent<shootRadius>();
            shootRadius.EnemyList.Add(enemyInfo);
        }
        if (other.gameObject.tag == "EMP")
        {
            shootRadius = other.GetComponent<shootRadius>();
            shootRadius.EnemyList.Add(enemyInfo);
        }
        if (other.gameObject.tag == "Radar")
        {
            radarTowerDetect = true;
            if (enemyType == EnemyTypes.invisible)
            {
                invisibleModel.SetActive(false);
                visibleModel.SetActive(true);
                gameObject.tag = "Enemy";
                gameObject.layer = LayerMask.NameToLayer("Enemy");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ShootRadius")
        {
            shootRadius = other.GetComponent<shootRadius>();
            shootRadius.EnemyList.Remove(enemyInfo);
        }
        if (other.gameObject.tag == "Radar")
        {
            radarTowerDetect = false;
            if (enemyType == EnemyTypes.invisible)
            {
                StartCoroutine(invisibleEnemyDelay());
            }
        }
    }

    private void Awake()
    {
        //waypointArray = GameObject.Find(wayPointContainerName).transform;
        //waypointObjects = waypointArray.Cast<Transform>().ToArray();

    }


    private void setPath()
    {
        //waypoints = new Vector3[waypointObjects.Length];
        //for (int i = 0; i < waypointObjects.Length; i++)
        //{
        //    waypoints[i] = waypointObjects[i].position;
        //}
        //t = transform.DOPath(waypoints, flySpeed, pathType)
        //   .SetOptions(false)
        //   .SetAutoKill(false)
        //   .SetEase(Ease.Linear).SetLoops(0)
        //   .SetLookAt(0.001f);


        sun = GameObject.Find("Sun");
        var direction = sun.transform.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);

        myRigid.AddForce(transform.forward * flySpeed * Time.fixedDeltaTime, ForceMode.Impulse);
        fly = true;
        particleFlyEffect.SetActive(true);

    }

    private void Start()
    {
        enemyHP = GetComponent<EnemyHP>();
        myRigid = GetComponent<Rigidbody>();
        setPath();
        laserSpeed = laserSpeed * 1000;

        enemyInfo = new EnemyInfo() { transform = this.transform, enemyhp = this.enemyHP };

        if (enemyType == EnemyTypes.invisible)
            StartCoroutine(invisibleDurationTime());
    }

    void Update()
    {
        if (!canFly)
        {
            myRigid.velocity = Vector3.zero;
            particleFlyEffect.SetActive(false);
            fly = false;
        }
        else
        {
            if (!fly)
                setPath();
        }
    }

    IEnumerator invisibleDurationTime()
    {
        if (!radarTowerDetect)
        {
            //if (enemyHP.CurrentHealth > 0)
            //{
                visibleModel.SetActive(false);
                invisibleModel.SetActive(true);
                gameObject.tag = "InvisibleEnemy";
                gameObject.layer = LayerMask.NameToLayer("InvisibleEnemy");
                yield return new WaitForSeconds(invisibleDuration);
                invisibleModel.SetActive(false);
                visibleModel.SetActive(true);
                gameObject.tag = "Enemy";
                gameObject.layer = LayerMask.NameToLayer("Enemy");
                StartCoroutine(invisibleEnemyDelay());
            //}
        }
        else
            StartCoroutine(invisibleEnemyDelay());
    }

    IEnumerator invisibleEnemyDelay()
    {
        yield return new WaitForSeconds(invisibleDelay);
        StartCoroutine(invisibleDurationTime());
    }
    //private IEnumerator tankShotWithDelay()
    //{
    //    if (canShot)
    //    {
    //        if (target != null && target.gameObject.tag == "Building")
    //        {
    //            newLaser = ObjectPool.Instance.GetPooledObject(laserBullet);
    //            newLaser.GetComponent<LaserInfos>().Damage = damage;
    //            newLaser.transform.position = laserSpawnPosition.transform.position;
    //            Rigidbody laserBody = newLaser.GetComponent<Rigidbody>();
    //            laserBody.transform.LookAt(target);
    //            laserBody.AddForce(laserBody.transform.forward * laserSpeed * Time.deltaTime, ForceMode.Impulse);
    //            yield return new WaitForSeconds(shotDelay);
    //        }
    //        else
    //        {
    //            Collider[] collider = Physics.OverlapSphere(transform.position, tankRange);
    //            foreach (var coll in collider)
    //            {
    //                if (coll.gameObject.tag == "Building")
    //                {
    //                    target = coll.transform;
    //                }
    //            }
    //            yield return null;
    //        }
    //        StartCoroutine(tankShotWithDelay());
    //    }
    //}

    //private IEnumerator carrierShotWithDelay()
    //{
    //    if (canShot)
    //    {
    //        GameObject sun = GameObject.Find("Sun");
    //        newLaser = ObjectPool.Instance.GetPooledObject(laserBullet);
    //        newLaser.GetComponent<LaserInfos>().Damage = damage;
    //        newLaser.transform.position = laserSpawnPosition.transform.position;
    //        Rigidbody laserBody = newLaser.GetComponent<Rigidbody>();
    //        laserBody.transform.LookAt(sun.transform);
    //        laserBody.AddForce(transform.forward * laserSpeed * Time.deltaTime, ForceMode.Impulse);
    //        yield return new WaitForSeconds(0);
    //    }
    //}

    //private IEnumerator normalShotWithDelay()
    //{
    //    if (canShot)
    //    {
    //        Ray ray = new Ray(laserSpawnPosition.transform.position, transform.forward);
    //        Physics.Raycast(ray, out hit);
    //        if (hit.collider != null && hit.collider.gameObject.tag == "Building")
    //        {
    //            newLaser = ObjectPool.Instance.GetPooledObject(laserBullet);
    //            newLaser.GetComponent<LaserInfos>().Damage = damage;
    //            newLaser.transform.position = laserSpawnPosition.transform.position;
    //            Rigidbody laserBody = newLaser.GetComponent<Rigidbody>();
    //            laserBody.transform.LookAt(transform.forward);
    //            laserBody.AddForce(transform.forward * laserSpeed * Time.deltaTime, ForceMode.Impulse);
    //            yield return new WaitForSeconds(shotDelay);
    //        }
    //        else
    //            yield return new WaitForSeconds(0);
    //        StartCoroutine(normalShotWithDelay());
    //    }
    //}


    //private void Update()
    //{
    //    //if (!t.IsPlaying() && enemyType != EnemyTypes.Carrier)
    //    //{
    //    //    for (int i = 0; i < waypointObjects.Length; i++)
    //    //    {
    //    //        waypoints[i] = waypointObjects[i].position;
    //    //    }
    //    //    t = transform.DOPath(waypoints, flySpeed, pathType)
    //    //       .SetOptions(true)
    //    //       .SetLookAt(0.001f);

    //    //    t.SetEase(Ease.Linear).SetLoops(-1);
    //    //}
    //    //else if (!t.IsPlaying() && enemyType == EnemyTypes.Carrier)
    //    //{
    //    //    t.Kill();
    //    //    enemyHP.Decrease(enemyHP.CurrentHealth);
    //    //}
    //    //if (shotNow)
    //    //{
    //    //    if (enemyType == EnemyTypes.Normal)
    //    //        StartCoroutine(normalShotWithDelay());
    //    //    else if (enemyType == EnemyTypes.Tank)
    //    //        StartCoroutine(tankShotWithDelay());
    //    //    else if (enemyType == EnemyTypes.Carrier && carrierTrigger)
    //    //    {
    //    //        carrierTrigger = false;
    //    //    }
    //    //    shotNow = false;
    //    //}
    //}


}
