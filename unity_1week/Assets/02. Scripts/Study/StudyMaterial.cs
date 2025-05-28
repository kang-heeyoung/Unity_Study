using UnityEngine;

public class StudyMaterial : MonoBehaviour
{

    public Material mat;
    public string hexCode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //this.GetComponent<MeshRenderer>().material = mat; // Material을 바꾸기 위해서는 MeshRenderer에 접근해서 바꾸어야 한다. -> material 자체를 바꾼 것

        //this.GetComponent<MeshRenderer>().material.color = Color.green; // Material 자체의 색상 값을 바꾼 것. (종료 시에는 되돌아옴.)

        //this.GetComponent<MeshRenderer>().sharedMaterial.color = Color.green; // 해당 Material의 원래 Color 색을 바꿔버림. (원본데이터 자체를 바꿔버리기 때문에 종료 후에도 원상복귀되지 않음.)

        //this.GetComponent<MeshRenderer>().material.color = new Color(130f/255f, 20f/255f, 70f/255f, 1); 

        mat = this.GetComponent<MeshRenderer>().material;
        Color outputColor;

        if (ColorUtility.TryParseHtmlString(hexCode, out outputColor))
        {
            mat.color = outputColor;
        }

    }


}
