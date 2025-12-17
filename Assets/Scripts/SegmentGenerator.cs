using System.Collections;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] segments;
    [SerializeField] private int zPos = 50;
    [SerializeField] private bool creatingSegment = false;
    [SerializeField] private int segmentNum;

    void Update()
    {
        if (!creatingSegment)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
    }

    IEnumerator SegmentGen()
    {
        segmentNum = Random.Range(0, segments.Length);
        Instantiate(segments[segmentNum], new Vector3(0f, 0f, zPos), Quaternion.identity);

        zPos += 50;
        yield return new WaitForSeconds(3f);
        creatingSegment = false;
    }
}
