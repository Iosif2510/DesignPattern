using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanCreator : MonoBehaviour
{
    public Snowman snowmanPrefab;

    private float snowmanCreationTimer = 3.0f;

    // Update is called once per frame
    void Update()
    {
        snowmanCreationTimer += Time.deltaTime;
        if (snowmanCreationTimer >= 3f)
        {
            snowmanCreationTimer -= 3f;
            var snowmanInstance = Instantiate(snowmanPrefab, new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f)), Quaternion.identity);
            snowmanInstance.transform.SetParent(transform);
        }
    }
}
