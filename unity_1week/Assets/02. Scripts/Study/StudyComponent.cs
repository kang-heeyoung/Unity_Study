using UnityEngine;

// ����������  Ŭ������ : ����Ƽ�� ������ ����� ����ִ� ��
public class StudyComponent : MonoBehaviour
{
    // private�� ���� ���, ����Ƽ �����Ϳ��� �߸� �����Ǵ� ��츦 ���� ���ؼ�
    public GameObject obj;

    public Mesh msh;
    public Material mat;

    //public Transform objTf;

    void Start()
    {

        //obj = GameObject.FindGameObjectWithTag("Player");

        //// return���� ���� ����� GameObject Ÿ��
        //objTf = GameObject.FindGameObjectWithTag("Player").transform;


        //objTf.gameObject.SetActive(false); // ������ ���ٰ����� ��� .gameObject, .transform���� ������ �� ����.

        //// MeshFilter ������Ʈ�� �����ؼ� mesh�� ����ϴ� ���
        //Debug.Log($"Mesh ������ : {obj.GetComponent<MeshFilter>().mesh}");

        //// MeshRenderer ������Ʈ�� �����ؼ� material�� ����ϴ� ���
        //Debug.Log($"Mesh ������ : {obj.GetComponent<MeshRenderer>().material}");

        //// obj�� MeshRenderer�� �����ؼ� Ȱ�����¸� ���� ��� -> ������ ����������, ���� ������ ����. (���� ��)
        //obj.GetComponent<MeshRenderer>().enabled = false;

        //// obj�� GameObject Ȱ�����¸� false(���� ���) -> �� �� �������� ����. Find�� ã�� ���� ����.
        //obj.SetActive(false);

        CreateCube();

    }
    public void CreateCube()
    {
        obj = new GameObject("Cube");

        obj.AddComponent<MeshFilter>();
        obj.GetComponent<MeshFilter>().mesh = msh;

        obj.AddComponent<MeshRenderer>();
        obj.GetComponent<MeshRenderer>().material = mat;

        obj.AddComponent<BoxCollider>();
    }

    
}
