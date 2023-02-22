using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTurn : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject bG;
    GameObject Text;


    private void OnEnable()
    {
        bG = this.gameObject.transform.GetChild(0).transform.gameObject;
        Text = bG.gameObject.transform.GetChild(0).transform.gameObject;
        StartCoroutine(nameof(fade));
    }
    IEnumerator fade()
    {
        while (bG.GetComponent<Image>().color.a > 0)
        {
            Color color = bG.GetComponent<Image>().color;
            color = new Color(color.r, color.g, color.b, color.a - 0.1f);
            bG.GetComponent<Image>().color = color;

            Color color1 = Text.GetComponent<Text>().color;
            color1 = new Color(color1.r, color1.g, color1.b, color1.a - 0.1f);
            Text.GetComponent<Text>().color = color1;
            yield return new WaitForSeconds(0.1f);
        }
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
