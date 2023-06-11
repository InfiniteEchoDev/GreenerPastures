using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder {

    // This is the blackboard container shared between all nodes.
    // Use this to store temporary data that multiple nodes need read and write access to.
    // Add other properties here that make sense for your specific use case.
    [System.Serializable]
    public class Blackboard 
    {

        public Vector3 moveToPosition;
        public bool sheepInRange = false;

        public float difficultyRating = 1.0f;
        public float distBeforeCloseTolerance = 0.25f;
    }
}