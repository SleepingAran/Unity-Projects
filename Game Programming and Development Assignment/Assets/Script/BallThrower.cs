using UnityEngine;
using System.Collections;

public class BallThrower : MonoBehaviour {
	
	public float _Spin;
	public float _Power =500;
	public float _Throw = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = gameObject.transform.position; //A variable to remember the ball position
        pos.z = Mathf.Clamp(-5.79f, -7.19f, -4.56f);
    }
	void Update () {
		if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > .1)
			return;
   
	if (Input.GetKey(KeyCode.LeftArrow))
		{
            
             Vector3 addition;
                 addition = Vector3.forward * Time.deltaTime;
                 gameObject.transform.position -= addition; //Move to the left
                 
             
		}
	if (Input.GetKey(KeyCode.RightArrow))
		{
			Vector3 addition = Vector3.forward * Time.deltaTime;
			gameObject.transform.position += addition; //Move to the right
		}
	

	if (Input.GetKey(KeyCode.Space)) 
		{
        // the force that act on the ball
            if (_Power <= 100000)
			_Power += _Throw * 1000 * Time.deltaTime; //If it wasn't 100000, keep on increasing the power
		}		
	
	if (Input.GetKeyUp(KeyCode.Space))
	{
		StartCoroutine(Throw()); //Throw the ball
	}
		
	}

	public IEnumerator Throw()
	{
		gameObject.GetComponent<ConstantForce>().force = new Vector3(_Power * -1, 0,0);
		gameObject.GetComponent<ConstantForce>().relativeForce = gameObject.GetComponent<ConstantForce>().force * .1f;
		gameObject.GetComponent<ConstantForce>().torque = new Vector3(-100, _Spin, 0);
		yield return 0;
		gameObject.GetComponent<ConstantForce>().force = Vector3.zero;
		gameObject.GetComponent<ConstantForce>().relativeForce = Vector3.zero;
		gameObject.GetComponent<ConstantForce>().torque =  Vector3.zero;
		
		yield  break;
		
	}
	
	public void Reset(object _ball)
	{
		// _ball is ignored 
		_Power = 0; //Power reinitiate to zero
		_Spin = Random.Range(-100, 100);
		gameObject.GetComponent<ConstantForce>().force =Vector3.zero;
		gameObject.GetComponent<ConstantForce>().relativeForce = Vector3.zero;
		gameObject.GetComponent<ConstantForce>().torque = Vector3.zero;
		gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		
	
	}
		
    void OnGUI()
    {

        Rect z = new Rect(Screen.width-320,50,300,20);
        GUI.Label(z, "Power: "+_Power.ToString()); //Shows the power
    }
}


