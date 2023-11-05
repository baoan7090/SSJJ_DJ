using UnityEngine;

internal struct Struct22
{
	public Struct22(float float_1 = 0.2f)
	{
		GameObject gameObject = new GameObject("LineObj");
		lineRenderer_0 = gameObject.AddComponent<LineRenderer>();
		lineRenderer_0.material = new Material(Shader.Find("Hidden/Internal-Colored"));
		float_0 = float_1;
	}

	void method_0(float float_1 = 0.2f)
	{
		if (lineRenderer_0 == null)
		{
			GameObject gameObject = new GameObject("LineObj");
			lineRenderer_0 = gameObject.AddComponent<LineRenderer>();
			Renderer renderer = lineRenderer_0;
			renderer.material = new Material(Shader.Find("Hidden/Internal-Colored"));
			float_0 = float_1;
		}
	}

	public void method_1(Vector3 vector3_0, Vector3 vector3_1, Color color_0)
	{
		if (lineRenderer_0 == null)
		{
			method_0(0.2f);
		}
		lineRenderer_0.startColor = color_0;
		lineRenderer_0.endColor = color_0;
		lineRenderer_0.startWidth = float_0;
		lineRenderer_0.endWidth = float_0;
		lineRenderer_0.positionCount = 2;
		lineRenderer_0.SetPosition(0, vector3_0);
		lineRenderer_0.SetPosition(1, vector3_1);
	}

	public void method_2()
	{
		if (lineRenderer_0 != null)
		{
			UnityEngine.Object.Destroy(lineRenderer_0.gameObject);
		}
	}

	LineRenderer lineRenderer_0;

	float float_0;
}
