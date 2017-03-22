using UnityEngine;
using System.Collections;

public class C_WanderingAI : MonoBehaviour {

	public float speed = 3.0f;
	public float obstacleDistance = 5.0f;
    public float baseSpeed = 3.0f;
    bool shouldShoot = true;
	private bool alive = true;

	[SerializeField] private GameObject fireballPrefab;
	private GameObject fireball;
    void Awake()
    {
        Messenger<float>.AddListener(C_GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void OnDestroy()
    {
        Messenger<float>.RemoveListener(C_GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (alive){
		//move enemy forward
		transform.Translate (0, 0, speed * Time.deltaTime);

		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

            if (Physics.SphereCast(ray, 0.75f, out hit))
            {

                GameObject hitObj = hit.transform.gameObject;
                C_PlayerCharacter playerChar = hitObj.GetComponent<C_PlayerCharacter>();
                if (shouldShoot == true)
                {
                    if (playerChar != null)
                    {
                        //shoot player
                        if (fireball == null)
                        {
                            fireball = Instantiate(fireballPrefab) as GameObject;
                            fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                            fireball.transform.rotation = transform.rotation;

                        }
                    }
                    //Rotate enemy when almost hit wall/ obstacle
                    else if (hit.distance < obstacleDistance)
                    {
                        float angle = Random.Range(-110, 110);
                        transform.Rotate(0, angle, 0);
                    }
                    //To prevent player from instant death
                    shouldShoot = false;
                    StartCoroutine(shouldShootTimer());
                }
            }
		}
	}
    IEnumerator shouldShootTimer()
    {
        yield return new WaitForSeconds(3);
        shouldShoot = true;

    }
	public void SetAlive(bool newValue){
		alive = newValue;
	}
}
