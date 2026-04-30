using System.Collections.Generic;
using UnityEngine;

public class ProjectileObjectPool : MonoBehaviour
{
    public static ProjectileObjectPool instance;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int initialPoolSize = 10;

    private readonly List<GameObject> projectilePool = new();

    private void Awake()
    {
        // Singleton pattern
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        // Initialize the pool with inactive objects
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateNewProjectile();
        }
    }

    private GameObject CreateNewProjectile()
    {
        GameObject newProjectile = Instantiate(projectilePrefab);
        newProjectile.SetActive(false);
        projectilePool.Add(newProjectile);
        return newProjectile;
    }

    public GameObject Acquire()
    {
        // If there are no objects in the pool, create a new one
        if (projectilePool.Count == 0)
        {
            CreateNewProjectile();
        }

        // Get an object from the pool
        GameObject projectile = projectilePool[0];
        projectilePool.RemoveAt(0);
        projectile.SetActive(true);

        return projectile;
    }

    public void Return(GameObject projectile)
    {
        projectile.SetActive(false);
        projectilePool.Add(projectile);
    }
}
