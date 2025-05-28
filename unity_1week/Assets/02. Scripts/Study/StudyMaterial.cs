using UnityEngine;

public class StudyMaterial : MonoBehaviour
{

    public Material mat;
    public string hexCode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //this.GetComponent<MeshRenderer>().material = mat; // Material�� �ٲٱ� ���ؼ��� MeshRenderer�� �����ؼ� �ٲپ�� �Ѵ�. -> material ��ü�� �ٲ� ��

        //this.GetComponent<MeshRenderer>().material.color = Color.green; // Material ��ü�� ���� ���� �ٲ� ��. (���� �ÿ��� �ǵ��ƿ�.)

        //this.GetComponent<MeshRenderer>().sharedMaterial.color = Color.green; // �ش� Material�� ���� Color ���� �ٲ����. (���������� ��ü�� �ٲ������ ������ ���� �Ŀ��� ���󺹱͵��� ����.)

        //this.GetComponent<MeshRenderer>().material.color = new Color(130f/255f, 20f/255f, 70f/255f, 1); 

        mat = this.GetComponent<MeshRenderer>().material;
        Color outputColor;

        if (ColorUtility.TryParseHtmlString(hexCode, out outputColor))
        {
            mat.color = outputColor;
        }

    }


}
