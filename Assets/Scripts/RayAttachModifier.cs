using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;

namespace UnityEngine.XR.Content.Interaction
{
    public class RayAttachModifier : MonoBehaviour
    {
        IXRSelectInteractable m_SelectInteractable;

        [SerializeField] AudioSource cockedSound;

        protected void OnEnable()
        {
            m_SelectInteractable = GetComponent<IXRSelectInteractable>();
            if (m_SelectInteractable as Object == null)
            {
                Debug.LogError($"Ray Attach Modifier missing required Select Interactable on {name}", this);
                return;
            }

            m_SelectInteractable.selectEntered.AddListener(OnSelectEntered);
        }

        protected void OnDisable()
        {
            if (m_SelectInteractable as Object != null)
                m_SelectInteractable.selectEntered.RemoveListener(OnSelectEntered);
        }

        void OnSelectEntered(SelectEnterEventArgs args)
        {
            if (!(args.interactorObject is XRRayInteractor))
                return;

            var attachTransform = args.interactorObject.GetAttachTransform(m_SelectInteractable);
            var originalAttachPose = args.interactorObject.GetLocalAttachPoseOnSelect(m_SelectInteractable);
            attachTransform.SetLocalPose(originalAttachPose);

            cockedSound.Play();
        }
    }
}
