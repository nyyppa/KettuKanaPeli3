﻿using UnityEngine;
using System.Collections;

namespace Kettukanapeli
{
    public class PlayerMovement : MonoBehaviour
    {

        float speed = 6.0f;
        float runSpeed = 9.0f;
        [SerializeField]
        float rotateSpeed = 90f;
        Animator _animator;

        private Vector3 movement;
        private Rigidbody playerRigidBody;

        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        void Awake()
        {
            // print ("alku" + transform.position);
            playerRigidBody = GetComponent<Rigidbody>();
            gameObject.tag = "Fox";
        }

        void Update()
        {
            float lh = Input.GetAxisRaw("Horizontal");
            float lv = Input.GetAxisRaw("Vertical");

            if (lh != 0 || lv != 0)
            {
                Move(lh, lv);
            }
            else
            {
                _animator.SetBool("isWalking", false);
                _animator.SetBool("isRunning", false);
            }
        }

        void Move(float lh, float lv)
        {
            movement.Set(lh, 0f, lv);
            movement = Camera.main.transform.TransformDirection(movement);
            movement = new Vector3(movement.x, 0, movement.z);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _animator.SetBool("isRunning", true);
                movement = movement.normalized * runSpeed * Time.deltaTime;
            }
            else
            {
                movement = movement.normalized * speed * Time.deltaTime;
                _animator.SetBool("isWalking", true);
                _animator.SetBool("isRunning", false);
            }

            playerRigidBody.MovePosition(transform.position + movement);
            // print (transform.position);
            if (lh != 0f || lv != 0f)
            {
                Rotating(lh, lv);
            }
        }

        void Rotating(float lh, float lv)
        {
            Vector3 targetDirection = new Vector3(lh, 0f, lv);
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            Quaternion newRotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, targetRotation,
                                         rotateSpeed * Time.deltaTime);
            GetComponent<Rigidbody>().MoveRotation(newRotation);
        }
    }
}
