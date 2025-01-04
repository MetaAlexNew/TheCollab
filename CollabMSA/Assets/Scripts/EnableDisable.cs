using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    [Header("Script Made By Koko Dont Claim")]
    public GameObject[] ObjectToEnable;
    public GameObject[] ObjectToDisable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandTag") || other.CompareTag("Player"))
        {
            foreach (GameObject obj in ObjectToDisable)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in ObjectToEnable)
            {
                obj.SetActive(true);
            }
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
