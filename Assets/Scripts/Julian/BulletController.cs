/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int DamagePoints;

    public float Speed;

    private Renderer myRenderer;

    private Transform myTransform;

    public Transform Target { get; set; }

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

    private void Awake()
    {
        myTransform = GetComponent<Transform>();
        myRenderer = GetComponentInChildren<Renderer>();
    }

    private void Update()
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
}
