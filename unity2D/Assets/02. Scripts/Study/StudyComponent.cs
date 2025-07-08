using UnityEngine;

// 접근제한자  클래스명 : 유니티의 유용한 기능이 들어있는 곳
public class StudyComponent : MonoBehaviour
{
    // private로 보통 사용, 유니티 에디터에서 잘못 설정되는 경우를 막기 위해서
    public GameObject obj;

    public Mesh msh;
    public Material mat;

    //public Transform objTf;

    void Start()
    {

        //obj = GameObject.FindGameObjectWithTag("Player");

        //// return으로 나온 결과가 GameObject 타입
        //objTf = GameObject.FindGameObjectWithTag("Player").transform;


        //objTf.gameObject.SetActive(false); // 무조건 접근가능할 경우 .gameObject, .transform으로 접근할 수 있음.

        //// MeshFilter 컴포넌트에 접근해서 mesh를 출력하는 기능
        //Debug.Log($"Mesh 데이터 : {obj.GetComponent<MeshFilter>().mesh}");

        //// MeshRenderer 컴포넌트에 접근해서 material을 출력하는 기능
        //Debug.Log($"Mesh 데이터 : {obj.GetComponent<MeshRenderer>().material}");

        //// obj의 MeshRenderer에 접근해서 활성상태를 끄는 기능 -> 씬에는 존재하지만, 눈에 보이지 않음. (투명 벽)
        //obj.GetComponent<MeshRenderer>().enabled = false;

        //// obj의 GameObject 활성상태를 false(끄는 기능) -> 씬 상에 존재하지 않음. Find로 찾을 수도 없음.
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
