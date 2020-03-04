

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Allows a joint to follow another joint
/// </summary>
public class JointFollowAnimRot : MonoBehaviour
{

	public bool invert;                         // Do we follow regularly, or oppositely?

	public float torqueForce;                   // How strongly to follow
	public float angularDamping;                // How much smoothing to apply
	public float maxForce;                      // Max force we can exert to follow
	public float springForce;                   // If we want to limit the activity of the springs
	public float springDamping;                 // If we want to limit the springs' speed

	public Vector3 targetVel;                   // If we want to set this to another direction

	public Transform target;                    // What we want to follow
	private GameObject limb;                    // ???
	private JointDrive drive;                   // ???
	private SoftJointLimitSpring spring;        // OUR spring to use
	private ConfigurableJoint joint;            // OUR joint to move
	private Quaternion startingRotation;        // What rotation do we start with?

    private bool doFollow;                      // Are we active or not?

	void Start ()
    {
		torqueForce = 500f;
		angularDamping = 0.0f;
		maxForce = 500f;

		springForce = 0f;
		springDamping = 0f;

		targetVel = new Vector3(0f, 0f, 0f);

		drive.positionSpring = torqueForce;
		drive.positionDamper = angularDamping;
		drive.maximumForce = maxForce;

		spring.spring = springForce;
		spring.damper = springDamping;

		joint = gameObject.GetComponent<ConfigurableJoint>();

		joint.slerpDrive = drive;

		joint.linearLimitSpring = spring;
		joint.rotationDriveMode = RotationDriveMode.Slerp;
		joint.projectionMode = JointProjectionMode.None;
		joint.targetAngularVelocity = targetVel;
		joint.configuredInWorldSpace = false;
		joint.swapBodies = true;

		joint.angularXMotion = ConfigurableJointMotion.Free;
		joint.angularYMotion = ConfigurableJointMotion.Free;
		joint.angularZMotion = ConfigurableJointMotion.Free;
		joint.xMotion = ConfigurableJointMotion.Locked;
		joint.yMotion = ConfigurableJointMotion.Locked;
		joint.zMotion = ConfigurableJointMotion.Locked;

		startingRotation = Quaternion.Inverse(target.localRotation);

        doFollow = true;
	}


    /// <summary>
    /// 
    /// </summary>
	void LateUpdate ()
    {
        // If we are actively tring to follow the target
        if (doFollow)
        {
            // If we are following the inverse of the target
		    if (invert)
            {
			    joint.targetRotation = Quaternion.Inverse(target.localRotation * startingRotation);
            }
            // If we are following the target regularly
            else
            {
			    joint.targetRotation = target.localRotation * startingRotation;
            }
        }
    }


    /// <summary>
    /// Activates this Joint to Follow the Animator Joint
    /// </summary>
    public void DoFollow()
    {
        doFollow = true;
    }


    /// <summary>
    /// Deactivates this Joint to Follow the Animator Joint
    /// </summary>
    public void StopFollow()
    {
        doFollow = false;
    }


}