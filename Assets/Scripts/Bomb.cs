using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class Bomb : MonoBehaviour
{
    [SerializeField] int gridOffset;
    [SerializeField] int spawnHeight;
    [Header("Explotion Cast")]
    [SerializeField] float sphereCastRad;
    [SerializeField] LayerMask layerMask;

    [Header("Bomb Stats")]
    [SerializeField] int range;
    [SerializeField] float explosionTimer;
    float spawnTime;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        spawnTime = Time.time;
        Vector2 spawnPos = new Vector2(transform.position.x, transform.position.z);
        //x
        int divMain = (int)Mathf.Floor(spawnPos.x / gridOffset); ;
        float module = spawnPos.x % gridOffset;
        if (module > gridOffset / 2) divMain++;
        spawnPos.x = divMain * gridOffset;
        //y (z)
        divMain = (int)Mathf.Floor(Mathf.Abs(spawnPos.y / gridOffset)); ;
        module = spawnPos.y % gridOffset;
        if (Mathf.Abs(module) > gridOffset / 2) divMain++;
        spawnPos.y = divMain * -gridOffset;

        transform.position = new Vector3(spawnPos.x, spawnHeight, spawnPos.y);
    }


    void Update()
    {
        if (Time.time - spawnTime >= explosionTimer)
        {
            animator.SetTrigger("Explode");
            spawnTime = Time.time;
        }
    }

    public void Explode()
    {
        ExplodeInDirection(Vector3.right);
        ExplodeInDirection(Vector3.left);
        ExplodeInDirection(Vector3.forward);
        ExplodeInDirection(Vector3.back);
    }


    void ExplodeInDirection(Vector3 direction)
    {
        Ray ray = new Ray(transform.position, direction);
        RaycastHit[] Hits = Physics.SphereCastAll(ray, sphereCastRad, range, layerMask);
        Array.Sort(Hits, (a, b) => a.distance.CompareTo(b.distance));
        if (Hits.Length > 0)
        {
            foreach (RaycastHit hit in Hits)
            {
                if (hit.transform.tag == "Unbreakable") break;
                hit.transform.gameObject.SetActive(false);
                if (hit.transform.tag == "Breakable") break;
            }
        }
    }

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }


















}