﻿using Mirror.Core;
using UnityEngine;

namespace Mirror.Examples.CCU
{
    public class Player : NetworkBehaviour
    {
        public Vector3 cameraOffset = new Vector3(0, 40, -40);

        // automated movement.
        // player may switch to manual movement any time
        [Header("Automated Movement")]
        public bool autoMove = true;
        public float autoSpeed           = 2;
        public float movementProbability = 0.5f;
        public float movementDistance    = 20;
        private bool         moving;
        private Vector3      start;
        private Vector3      destination;

        [Header("Manual Movement")]
        public float manualSpeed = 10;

        // cache .transform for benchmark demo.
        // Component.get_transform shows in profiler otherwise.
        private Transform tf;

        public override void OnStartLocalPlayer()
        {
            tf = transform;
            start = tf.position;

            // make camera follow
            Camera.main.transform.SetParent(transform, false);
            Camera.main.transform.localPosition = cameraOffset;
        }

        public override void OnStopLocalPlayer()
        {
            // free the camera so we don't destroy it too
            Camera.main.transform.SetParent(null, true);
        }

        private void AutoMove()
        {
            if (moving)
            {
                if (Vector3.Distance(tf.position, destination) <= 0.01f)
                {
                    moving = false;
                }
                else
                {
                    tf.position = Vector3.MoveTowards(tf.position, destination, autoSpeed * Time.deltaTime);
                }
            }
            else
            {
                float r = Random.value;
                if (r < movementProbability * Time.deltaTime)
                {
                    // calculate a random position in a circle
                    float circleX = Mathf.Cos(Random.value * Mathf.PI);
                    float circleZ = Mathf.Sin(Random.value * Mathf.PI);
                    Vector2 circlePos = new Vector2(circleX, circleZ);
                    Vector3 dir = new Vector3(circlePos.x, 0, circlePos.y);

                    // set destination on random pos in a circle around start.
                    // (don't want to wander off)
                    destination = start + dir * movementDistance;
                    moving = true;
                }
            }
        }

        private void ManualMove()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(h, 0, v);
            transform.position += direction.normalized * (Time.deltaTime * manualSpeed);
        }

        private static bool Interrupted() =>
            Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

        private void Update()
        {
            if (!isLocalPlayer) return;

            // player may interrupt auto movement to switch to manual
            if (Interrupted()) autoMove = false;

            // move
            if (autoMove) AutoMove();
            else ManualMove();
        }
    }
}
