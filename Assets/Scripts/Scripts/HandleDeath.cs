using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HandleDeath : MonoBehaviour
{
    [SerializeField] private float xForce;
    [SerializeField] private float yForce;
    [SerializeField] private float zForce;

    [SerializeField] private CharacterController player;

    [SerializeField] private AudioSource polloScream;
    
    [SerializeField] private CheckChecker checker;
    [SerializeField] private GameObject playerToMove;

    [SerializeField] private CinemachineVirtualCamera cinemachineVc;
    [SerializeField] private GameObject playerToFollow;

    [SerializeField] private Image animImg;
    // Start is called before the first frame update
    void Start()
    {
        cinemachineVc = FindObjectOfType<CinemachineVirtualCamera>();
        animImg = GameObject.FindWithTag("DeathAnim").GetComponent<Image>();
        player =  playerToMove.GetComponent<CharacterController>();
    }

    public void AddForce()
    {
        Debug.Log("Force");
        polloScream.Play();
        player.Move(new Vector3(xForce, yForce, 0 + zForce));
        StartCoroutine(Respawn());
        cinemachineVc.Follow = null;
    }

    public void Die()
    {
        polloScream.Play();
        StartCoroutine(Respawn());
        cinemachineVc.Follow = null;
    }

    private IEnumerator Respawn()
    {
        float fillSpeed = 2.0f / 1.0f;

        yield return new WaitForSeconds(1);
        
        while (animImg.fillAmount < 1)
        {
            animImg.fillAmount += fillSpeed * Time.deltaTime; 
            yield return null; 
        }
    
        yield return new WaitForSeconds(0.3f);
        
        player.enabled = false;
        playerToMove.transform.position = checker.currentPointLoad.position;
        cinemachineVc.Follow = playerToFollow.transform;
        
        while (animImg.fillAmount > 0)
        {
            animImg.fillAmount -= fillSpeed * Time.deltaTime; 
            yield return null; 
        }
        
        player.enabled = true;
    }
}
