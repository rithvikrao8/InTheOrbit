using UnityEngine;

public class MakeTransparent : MonoBehaviour
{
    [Range(0, 1)]
    public float transparency = 0.5f; // Set the desired transparency level (0 = fully transparent, 1 = fully opaque)
    public string shaderType = "Standard"; // Default shader type to use

    void Start()
    {
        // Get the MeshRenderer component attached to this GameObject
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        if (meshRenderer != null)
        {
            // Iterate through all the materials attached to this GameObject
            foreach (Material material in meshRenderer.materials)
            {
                // Set the shader to Standard if it's not already set to something else
                if (material.shader.name != shaderType)
                {
                    material.shader = Shader.Find(shaderType);
                }

                // Set the rendering mode to transparent
                material.SetFloat("_Mode", 3);
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;

                // Set the transparency level
                Color color = material.color;
                color.a = transparency;
                material.color = color;

                // For some materials, you may need to set the "_Color" property as well
                material.SetColor("_Color", color);
            }
        }
        else
        {
            Debug.LogWarning("No MeshRenderer found on the GameObject.");
        }
    }
}