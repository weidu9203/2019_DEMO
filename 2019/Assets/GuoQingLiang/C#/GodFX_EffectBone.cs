using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GodFX_EffectBone : MonoBehaviour {

    public Vector3 EffectPostion;
    public bool isFollow = true;
    public Bone Bone;

    public static Transform GetTarget(Transform rootNode,Bone bone) {

        Transform returnValue = null;

        switch (bone)
        {
            case Bone.Spine:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine");
                break;
            case Bone.LThigh:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 L Thigh");
                break;
            case Bone.RThigh:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 R Thigh");
                break;
            case Bone.LCalf:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 L Thigh/Bip001 L Calf");
                break;
            case Bone.RCalf:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 R Thigh/Bip001 R Calf");
                break;
            case Bone.LFoot:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 L Thigh/Bip001 L Calf/Bip001 L Foot");
                break;
            case Bone.RFoot:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 R Thigh/Bip001 R Calf/Bip001 R Foot");
                break;
            case Bone.LToe0:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 L Thigh/Bip001 L Calf/Bip001 L Foot/Bip001 L Toe0");
                break;
            case Bone.RToe0:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 R Thigh/Bip001 R Calf/Bip001 R Foot/Bip001 R Toe0");
                break;
            case Bone.Neck:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Neck");
                break;
            case Bone.Head:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 Head");
                break;
            case Bone.LClavicle:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 L Clavicle");
                break;
            case Bone.RClavicle:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 R Clavicle");
                break;
            case Bone.LUpperArm:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 L Clavicle/Bip001 L UpperArm");
                break;
            case Bone.RUpperArm:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 R Clavicle/Bip001 R UpperArm");
                break;
            case Bone.LForearm:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 L Clavicle/Bip001 L UpperArm/Bip001 L Forearm");
                break;
            case Bone.RForearm:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 R Clavicle/Bip001 R UpperArm/Bip001 R Forearm");
                break;
            case Bone.LHand:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 L Clavicle/Bip001 L UpperArm/Bip001 L Forearm/Bip001 L Hand");
                break;
            case Bone.RHand:
                returnValue = rootNode.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 R Clavicle/Bip001 R UpperArm/Bip001 R Forearm/Bip001 R Hand");
                break;
        }

        return returnValue == null ? rootNode : returnValue;
    }

    public static float GetTargetHeight(Transform rootNode)
    {
        BoxCollider box = rootNode.GetComponent<BoxCollider>();

        if (box != null)
        {
            //Debug.LogError(box.size.y);
            return box.size.y;
        }
        else return 1;
    }

    public void DestroyThis()
    {

        Destroy(this.gameObject);
    }



}


public enum Bone {
    None,
    Spine,
    LThigh,
    RThigh,
    LCalf,
    RCalf,
    LFoot,
    RFoot,
    LToe0,
    RToe0,
    Neck,
    Head,
    LClavicle,
    RClavicle,
    LUpperArm,
    RUpperArm,
    LForearm,
    RForearm,
    LHand,
    RHand
}

