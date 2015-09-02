using UnityEngine;
using System.Collections;

public class BaseTrackingHandler : MonoBehaviour,
                                            ITrackableEventHandler
{

    private TrackableBehaviour mTrackableBehaviour;

    private void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    /// <summary>
    /// Implementation of the ITrackableEventHandler function called when the
    /// tracking state changes.
    /// </summary>
    /// 
    //does not need change :P just a handler
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }



    protected virtual void OnTrackingFound()
    {
        EnableObjects(true);

        //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
    }


    protected virtual void OnTrackingLost()
    {
      
        EnableObjects(false);
      //  Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
    }
    protected virtual void EnableObjects(bool status)
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
        ParticleEmitter[] EmitterComponets = GetComponentsInChildren<ParticleEmitter>(true);
        Light[] LightComponents = GetComponentsInChildren<Light>(true);
        Animator[] AnimatorComponents = GetComponentsInChildren<Animator>(true);
        StringToModels[] StringToModelsComponents = GetComponentsInChildren<StringToModels>(true);

        // Disable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = status;
        }

        // Disable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = status;
        }

        foreach (ParticleEmitter componet in EmitterComponets)
        {
            componet.enabled = status;
        }
        foreach (Light componet in LightComponents)
        {
            componet.enabled = status;
        }
        foreach (Animator componet in AnimatorComponents)
        {
            componet.enabled = status;
        }
        foreach (StringToModels componet in StringToModelsComponents)
        {
            componet.enabled = status;
        }
    }
}
