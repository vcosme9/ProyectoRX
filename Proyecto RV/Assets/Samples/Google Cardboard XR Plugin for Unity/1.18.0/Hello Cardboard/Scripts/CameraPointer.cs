//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    // Vatiable Globales
    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;
    private int layerMask;

    public GameObject puntero;

    private bool inHands = false;

    private void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("tocable");
    }
    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        //Debug.DrawLine(transform.position, transform.position + transform.forward * _maxDistance);
        puntero.transform.position = transform.position + transform.forward * _maxDistance;
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance, layerMask))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                _gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter");
                puntero.transform.GetChild(0).GetComponent<Animator>().SetTrigger("grande");

            }
 
        }
        else
        {
            if (_gazedAtObject != null)
            {
                puntero.transform.GetChild(0).GetComponent<Animator>().SetTrigger("peque");
            }
            // No GameObject detected in front of the camera.
            _gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject = null;
        }

        // Checks for screen touches.
        if (Input.GetButton("Fire1"))
        {
            _gazedAtObject?.SendMessage("OnPointerClick");

        }

        if (Input.GetButtonDown("Fire2") && !inHands && hit.transform.tag == "tornillo")
        {
            Debug.Log("Quiero cogerlo...");

            _gazedAtObject?.SendMessage("OnPointerClick");

        }

    }
}