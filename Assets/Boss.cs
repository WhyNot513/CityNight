using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public Vector2 moveDirection;
    public float moveSpeed;
    public GameObject projext;
    public Transform Firepos;


    public GameObject vfx;
    private void Awake()
    {

    }


    protected void OnEnable()
    {
        target = (GameObject.FindGameObjectWithTag("Player"));
        StartCoroutine(nameof(fire));
    }
    void OnDisable()
    {

        vfx.SetActive(true);

    }
    IEnumerator fire()
    {
        while (target != null)
        {
            PoolManager.Release(projext, Firepos.position);
            yield return new WaitForSeconds(1f);
        }

    }
    private void Update()
    {


    }






}
