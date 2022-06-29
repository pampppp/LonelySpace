using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClignotengLight : MonoBehaviour
{
    public GameObject support;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ClignoteCd());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator ClignoteCd()
    {
        support.gameObject.SetActive(true);
        this.GetComponent<Light>().intensity = 2;
        yield return new WaitForSeconds(Random.Range(.5f, 2f));
        this.GetComponent<Light>().intensity = 0;
        support.gameObject.SetActive(false);
        yield return new WaitForSeconds(Random.Range(.1f, .5f));
        StartCoroutine(ClignoteCd());

    }
}
