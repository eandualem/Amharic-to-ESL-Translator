using UnityEngine;
using System.Collections;

public class IkSolver: MonoBehaviour
{
    public  int           ChainLength = 2;

    public  Transform     Target;
    public  Transform     Pole;

    public  int           Iterations = 10;
    public  float         Delta = 0.001f;
    public  float         SnapBackStrength = 1f;

    private float[]       BonesLength;              // Magnitude of each bones
    private float         CompleteLength;           // Total bone length
    private Transform[]   Bones;                    // joint Transform
    private Vector3[]     Pos;                      // joint Position
    private Vector3[]     DirectionOfSuccessur;     // Direction from one bone to successer
    private Quaternion[]  StartRotationBone;        // Rotation of each bone at start
    private Quaternion    StartRotationTarget;      // Rotation of target at start
    private Transform     Root;

    void Awake()
    {
        Init();
    }

    void Init()
    {
        //initial array
        Bones                   = new Transform [ChainLength + 1];
        Pos                     = new Vector3   [ChainLength + 1];
        BonesLength             = new float     [ChainLength    ];
        DirectionOfSuccessur    = new Vector3   [ChainLength + 1];
        StartRotationBone       = new Quaternion[ChainLength + 1];

        //find root
        Root = transform;
        for (var i = 0; i <= ChainLength; i++)
        {
            if (Root == null) Debug.Log("The chain value is longer than the ancestor chain!");
            Root = Root.parent;
            // Root = Root.parent.parent;

        }

        //init target
        if (Target == null)
        {
            Target = new GameObject(gameObject.name + " Target").transform;
            SetPositionRootSpace(Target, GetPositionRootSpace(transform));
        }
        StartRotationTarget = GetRotationRootSpace(Target);


        //init data
        var current = transform;
        CompleteLength = 0;
        for (var i = Bones.Length - 1; i >= 0; i--)
        {
            Bones[i] = current;
            StartRotationBone[i] = GetRotationRootSpace(current);

            if (i == Bones.Length - 1)
            {
                //leaf
                DirectionOfSuccessur[i] = GetPositionRootSpace(Target) - GetPositionRootSpace(current);
            }
            else
            {
                //mid bone
                DirectionOfSuccessur[i] = GetPositionRootSpace(Bones[i + 1]) - GetPositionRootSpace(current);
                BonesLength[i] = DirectionOfSuccessur[i].magnitude;
                CompleteLength += BonesLength[i];
            }

            current = current.parent;
            // current = current.parent.parent;

        }
    }

    void LateUpdate()
    {
        FabricConst();
    }

    private void FabricConst()
    {
        if (Target == null)
            return;

        if (BonesLength.Length != ChainLength)
            Init();


        for (int i = 0; i < Bones.Length; i++)
            Pos[i] = GetPositionRootSpace(Bones[i]);

        var targetPosition = GetPositionRootSpace(Target);
        var targetRotation = GetRotationRootSpace(Target);

        if ((targetPosition - GetPositionRootSpace(Bones[0])).sqrMagnitude >= CompleteLength * CompleteLength)
        {
            var direction = (targetPosition - Pos[0]).normalized;

            for (int i = 1; i < Pos.Length; i++)
                Pos[i] = Pos[i - 1] + direction * BonesLength[i - 1];
        }
        else
        {
            for (int i = 0; i < Pos.Length - 1; i++)
                Pos[i + 1] = Vector3.Lerp(Pos[i + 1], Pos[i] + DirectionOfSuccessur[i], SnapBackStrength);

            for (int iteration = 0; iteration < Iterations; iteration++)
            {
                for (int i = Pos.Length - 1; i > 0; i--)
                {
                    if (i == Pos.Length - 1)
                        Pos[i] = targetPosition; //set it to target
                    else
                        Pos[i] = Pos[i + 1] + (Pos[i] - Pos[i + 1]).normalized * BonesLength[i]; //set in line on distance
                }

                //forward
                for (int i = 1; i < Pos.Length; i++)
                    Pos[i] = Pos[i - 1] + (Pos[i] - Pos[i - 1]).normalized * BonesLength[i - 1];

                //close enough?
                if ((Pos[Pos.Length - 1] - targetPosition).sqrMagnitude < Delta * Delta)
                    break;
            }
        }

        //move towards pole
        if (Pole != null)
        {
            var polePosition = GetPositionRootSpace(Pole);
            for (int i = 1; i < Pos.Length - 1; i++)
            {
                var plane = new Plane(Pos[i + 1] - Pos[i - 1], Pos[i - 1]);
                var projectedPole = plane.ClosestPointOnPlane(polePosition);
                var projectedBone = plane.ClosestPointOnPlane(Pos[i]);
                var angle = Vector3.SignedAngle(projectedBone - Pos[i - 1], projectedPole - Pos[i - 1], plane.normal);
                Pos[i] = Quaternion.AngleAxis(angle, plane.normal) * (Pos[i] - Pos[i - 1]) + Pos[i - 1];
            }
        }

        //set position & rotation
        for (int i = 0; i < Pos.Length; i++)
        {
            if (i == Pos.Length - 1)
                SetRotationRootSpace(Bones[i], Quaternion.Inverse(targetRotation) * StartRotationTarget * Quaternion.Inverse(StartRotationBone[i]));
            else
                SetRotationRootSpace(Bones[i], Quaternion.FromToRotation(DirectionOfSuccessur[i], Pos[i + 1] - Pos[i]) * Quaternion.Inverse(StartRotationBone[i]));
            SetPositionRootSpace(Bones[i], Pos[i]);
        }
    }

    private Vector3 GetPositionRootSpace(Transform current)
    {
        if (Root == null)
            return current.position;
        else
            return Quaternion.Inverse(Root.rotation) * (current.position - Root.position);
    }

    private void SetPositionRootSpace(Transform current, Vector3 position)
    {
        if (Root == null)
            current.position = position;
        else
            current.position = Root.rotation * position + Root.position;
    }

    private Quaternion GetRotationRootSpace(Transform current)
    {
        if (Root == null)
            return current.rotation;
        else
            return Quaternion.Inverse(current.rotation) * Root.rotation;
    }

    private void SetRotationRootSpace(Transform current, Quaternion rotation)
    {
        if (Root == null)
            current.rotation = rotation;
        else
            current.rotation = Root.rotation * rotation;
    }

}