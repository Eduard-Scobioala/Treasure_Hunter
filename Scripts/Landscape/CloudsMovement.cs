using UnityEngine;

public class CloudsMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;
    [SerializeField] private GameObject[] cloudsArray;

    private float firstPosition;
    void Start()
    {
        firstPosition = cloudsArray[cloudsArray.Length-1].transform.position.x;
    }

    void Update()
    {
        for (int i = 0; i < cloudsArray.Length; i++)
        {
            cloudsArray[i].transform.Translate(Vector3.left * (Time.deltaTime * speed));

            if (cloudsArray[i].transform.position.x+6 < endPosition.position.x)
            {
                cloudsArray[i].transform.position = new Vector3(firstPosition-0.02f,
                    cloudsArray[i].transform.position.y, cloudsArray[i].transform.position.z);
            }
        }
    }
}
