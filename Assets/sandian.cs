using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandian : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnEnable()
    {
        StartCoroutine(nameof(Sandian));
    }
    IEnumerator Sandian()
    {
        yield return new WaitForSeconds(Random.Range(4, 6));
        GameManager.Instance.StartCoroutine(GameManager.Instance.star(this.gameObject));
        this.gameObject.SetActive(false);
    }
}
