/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    public Transform Target { get; set; }
    public float Speed;
    public int DamagePoints;

    private Transform myTransform;
    private Renderer myRenderer;

    void Awake()
    {
        myTransform = GetComponent<Transform>();
        myRenderer = GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        if (Target && Target.gameObject.activeInHierarchy)
        {
            myTransform.LookAt(Target);
            myTransform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHP>().Decrease(DamagePoints);
            gameObject.SetActive(false);
        }
    }
    public void SetColor(Color color)
    {
        myRenderer.material.color = color;
    }
}

