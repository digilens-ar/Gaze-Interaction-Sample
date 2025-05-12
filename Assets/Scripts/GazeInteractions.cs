using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeInteractions : MonoBehaviour
{
    float duration = .5f;
    Vector3 maxScale, startScale;

    // Start is called before the first frame update
    void Start()
    {
        maxScale = transform.localScale * 1.15f;
        startScale = transform.localScale;
    }

    public void StartAnimation(bool grow)
    {
        if (grow)
        {

            StartCoroutine(Grow());
        }
        else
        {
            StartCoroutine(Shrink());
        }
    }


    IEnumerator Grow()
    {
        float elapsed = 0;

        yield return new WaitUntil(() => transform.localScale == startScale);

        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, maxScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = maxScale;
    }

    IEnumerator Shrink()
    {
        float elapsed = 0;

        yield return new WaitUntil(() => transform.localScale == maxScale);

        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(maxScale, startScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = startScale;
    }

}
