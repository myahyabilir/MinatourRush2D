using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]

    private Vector2 camOffset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate(){
        Vector3 charPosition = player.transform.position;
        Vector3 calculatedCamPosition = new Vector3(charPosition.x + camOffset.x, 0.5f /* charPosition.y + camOffset.y */, -10.0f);
        gameObject.transform.position = calculatedCamPosition;
    }
}
