using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IPrototype
{
    public IPrototype Clone();

    public T CloneGeneric<T>() where T : IPrototype;
}

public class CopiedObject : IPrototype
{
    public int publicFieldValue1;
    public float publicFieldValue2;

    private int privateFieldValue1;
    private float privateFieldValue2;

    public CopiedObject(int pb1, float pb2, int pv1, float pv2)
    {
        this.publicFieldValue1 = pb1;
        this.publicFieldValue2 = pb2;
        this.privateFieldValue1 = pv1;
        this.privateFieldValue2 = pv2;
    }
    
    public CopiedObject(CopiedObject copiedObject)
    {
        publicFieldValue1 = copiedObject.publicFieldValue1;
        publicFieldValue2 = copiedObject.publicFieldValue2;
        privateFieldValue1 = copiedObject.privateFieldValue1;
        privateFieldValue2 = copiedObject.privateFieldValue2;
    }

    public IPrototype Clone()
    {
        return new CopiedObject(this);
    }

    public T CloneGeneric<T>() where T : IPrototype
    {
        return (T)Clone();
    }
}

public class CopiedObject2 : IPrototype
{
    public string publicFieldValue1;
    public float publicFieldValue2;

    private int privateFieldValue1;
    private string privateFieldValue2;
    
    public CopiedObject2(string pb1, float pb2, int pv1, string pv2)
    {
        this.publicFieldValue1 = pb1;
        this.publicFieldValue2 = pb2;
        this.privateFieldValue1 = pv1;
        this.privateFieldValue2 = pv2;
    }
    
    public CopiedObject2(CopiedObject2 copiedObject)
    {
        publicFieldValue1 = copiedObject.publicFieldValue1;
        publicFieldValue2 = copiedObject.publicFieldValue2;
        privateFieldValue1 = copiedObject.privateFieldValue1;
        privateFieldValue2 = copiedObject.privateFieldValue2;
    }

    public IPrototype Clone()
    {
        return new CopiedObject2(this);
    }
    
    public T CloneGeneric<T>() where T : IPrototype
    {
        return (T)Clone();
    }
}

public class PrototypeCopier : MonoBehaviour
{
    // Creating copies of original prototype instances

    public List<IPrototype> originalObjects = new ();
    
    // Start is called before the first frame update
    void Awake()
    {
        originalObjects.Add(new CopiedObject(3, 5f, 2, 7.2f));
        originalObjects.Add(new CopiedObject2("Hello", 5f, 2, "World"));
    }

    private void Start()
    {
        CopiedObject copiedObject = originalObjects[0].CloneGeneric<CopiedObject>();
        CopiedObject2 copiedObject2 = originalObjects[1].CloneGeneric<CopiedObject2>();
        Debug.Log($"Copied object: {copiedObject.publicFieldValue1}, {copiedObject.publicFieldValue2}");
        Debug.Log($"Copied object2: {copiedObject2.publicFieldValue1}, {copiedObject2.publicFieldValue2}");
    }
}
