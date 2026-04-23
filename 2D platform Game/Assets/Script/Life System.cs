using UnityEngine;
using System.Collections;

public class LifeSystem : MonoBehaviour
{
    public static LifeSystem instance;
    public int Life = 2;
    [SerializeField] private GameObject Shield;
    [SerializeField] private GameObject deathExplosion;
    [SerializeField] private GameObject SpaceShip;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    IEnumerator MaPause()
    {
        yield return new WaitForSeconds(2f);
        Life = 1;
        Debug.LogError("Vous avez" + Life + " vies");
    }
        void Start()
    {
        Life = 2;
        Debug.LogError("Vous avez" + Life + " vies");
        StartCoroutine(MaPause());
    }

    
    void Update()
    {
        if (Life > 2) Life = 2;

        if (Life == 2) Shield.SetActive(true);
        else Shield.SetActive(false);

        if (Life <= 0) 
        {
        deathExplosion.SetActive(true);
        SpaceShip.SetActive(false);
        }
    }
}
