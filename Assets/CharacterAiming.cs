using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterAiming : MonoBehaviour
{
    RaycastWeapon weapon;
    public float turnSpeed = 15f;
    public float aimDuration = 0.3f;
    public Rig aimLayer;

    Camera mainCamera;
   
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        weapon = GetComponentInChildren<RaycastWeapon>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
    }

    private void LateUpdate() {
        // if(Input.GetButton("Fire2")){
        //     aimLayer.weight += Time.deltaTime / aimDuration;
        // }else{
        //     aimLayer.weight -= Time.deltaTime / aimDuration;
        // }
        
        aimLayer.weight = 1.0f;

        if (Input.GetKeyDown(KeyCode.X))
        {
            weapon.StartFiring();
        }
        if(weapon.isFiring){
            weapon.UpdateFiring(Time.deltaTime);
        }
        weapon.UpdateBullets(Time.deltaTime);
        if (Input.GetKeyUp(KeyCode.X))
        {
            weapon.StopFiring();
        }

        // if(Input.GetButtonDown(KeyCode.X)){
        //     weapon.StartFiring();
        // }
        // if(Input.GetButtonUp(KeyCode.X)){
        //     weapon.StopFiring();
        // }
    }
    
}
