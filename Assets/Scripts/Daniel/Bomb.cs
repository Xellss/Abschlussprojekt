using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

    [SerializeField]
    private int damage = 0;
    [SerializeField]
    private float speed;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private bool animationPlayed = false;

    Animator animator;

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }


    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayAnimation()
    {
        if (!animationPlayed)
        {
            animationPlayed = true;
            animator.SetTrigger("Explosion");
        }
    }
    public void DestroyBomb()
    {
        gameObject.SetActive(false);
        transform.position = new Vector3(0, 0, 40);
    }
}
