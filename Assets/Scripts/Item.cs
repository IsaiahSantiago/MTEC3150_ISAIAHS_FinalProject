using UnityEngine;

public class Item : MonoBehaviour
{

    private Rigidbody rb;

    //public pushForce = 5;




    void Start()
    {
        rb = GetComponent<Rigidbody>();




    }

    public void Pickup(Transform parent, Vector3 pos) //We send the HoldPoint position data to vector 3 position
    {

        //Kinematic means the object wont do anything unless the player or something else uses it 
        rb.isKinematic = true;
        transform.SetParent(parent);
        transform.position = pos;
        //transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.localRotation = Quaternion.Euler(Vector3.zero);

    }

    ////We want a force to PUSH the object forward in the relative direction the camera is facing
    public void Throw(float force, Vector3 direction)
    {

        rb.isKinematic = false;
        transform.SetParent(null);

        //Impulse force is a one time application of force
        rb.AddForce(direction * force, ForceMode.Impulse);

        print("throwing");
     







    }





}