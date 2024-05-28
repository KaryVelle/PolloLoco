using System.Collections;
using UnityEngine;

public class MoveFences : MonoBehaviour
{
    [SerializeField] private float moveY;
    [SerializeField] private float secs;

    private void Start()
    {
        StartCoroutine(MoveUpDown());
    }

    private IEnumerator MoveUpDown()
    {
        while (true)
        {
            transform.Translate(0, moveY, 0);
            yield return new WaitForSeconds(secs);
            
            transform.Translate(0, -moveY, 0);
            yield return new WaitForSeconds(secs);
        }
    }
}