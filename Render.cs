using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_7D2D
{
	public class Render : MonoBehaviour
	{
		public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);
		private static Texture2D aaLineTex = null;
		private static Material blitMaterial = null;
		private static Material blendMaterial = null;
		private static Rect lineRect = new Rect(0, 0, 1, 1);
		public static Color Color
		{
			get { return GUI.color; }
			set { GUI.color = value; }
		}

		public static void DrawBox(Vector2 position, Vector2 size, Color color, bool centered = true)
		{
			Color = color;
			DrawBox(position, size, centered);
		}
		public static void DrawBox(Vector2 position, Vector2 size, bool centered = true)
		{
			var upperLeft = centered ? position - size / 2f : position;
			GUI.DrawTexture(new Rect(position, size), Texture2D.whiteTexture, ScaleMode.StretchToFill);
		}

		public static void DrawString(Vector2 position, string label, Color color, bool centered = true)
		{
			Color = color;
			DrawString(position, label, centered);
		}
		public static void DrawString(Vector2 position, string label, bool centered = true)
		{
			var content = new GUIContent(label);
			var size = StringStyle.CalcSize(content);
			var upperLeft = centered ? position - size / 2f : position;
			GUI.Label(new Rect(upperLeft, size), label);//
			
		}

		public static Texture2D lineTex;
		public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width)
		{
			Matrix4x4 matrix = GUI.matrix;
			if (!lineTex)
				lineTex = new Texture2D(1, 1);

			Color color2 = GUI.color;
			GUI.color = color;
			float num = Vector3.Angle(pointB - pointA, Vector2.right);

			if (pointA.y > pointB.y)
				num = -num;
			
			GUIUtility.ScaleAroundPivot(new Vector2((pointB - pointA).magnitude, width), new Vector2(pointA.x, pointA.y + 0.5f));
			GUIUtility.RotateAroundPivot(num, pointA);
			GUI.DrawTexture(new Rect(pointA.x, pointA.y, 1f, 1f), lineTex);
			GUI.matrix = matrix;
			GUI.color = color2;
		}
		
		public static void DrawBox(float x, float y, float w, float h, Color color, float thickness)
		{
			DrawLine(new Vector2(x, y), new Vector2(x + w, y), color, thickness);
			DrawLine(new Vector2(x, y), new Vector2(x, y + h), color, thickness);
			DrawLine(new Vector2(x + w, y), new Vector2(x + w, y + h), color, thickness);
			DrawLine(new Vector2(x, y + h), new Vector2(x + w, y + h), color, thickness);
		}

		public static void DrawBoxOutline(Vector2 Point, float width, float height, Color color, float thickness)
		{
			DrawLine(Point, new Vector2(Point.x + width, Point.y), color, thickness);
			DrawLine(Point, new Vector2(Point.x, Point.y + height), color, thickness);
			DrawLine(new Vector2(Point.x + width, Point.y + height), new Vector2(Point.x + width, Point.y), color, thickness);
			DrawLine(new Vector2(Point.x + width, Point.y + height), new Vector2(Point.x, Point.y + height), color, thickness);
		}

		public static void DrawCircle(Vector2 center, int radius, Color color, float width, bool antiAlias, int segmentsPerQuarter)
		{
			Color color2 = GUI.color;
			float rh = (float)radius / 2;

			Vector2 p1 = new Vector2(center.x, center.y - radius);
			Vector2 p1_tan_a = new Vector2(center.x - rh, center.y - radius);
			Vector2 p1_tan_b = new Vector2(center.x + rh, center.y - radius);

			Vector2 p2 = new Vector2(center.x + radius, center.y);
			Vector2 p2_tan_a = new Vector2(center.x + radius, center.y - rh);
			Vector2 p2_tan_b = new Vector2(center.x + radius, center.y + rh);

			Vector2 p3 = new Vector2(center.x, center.y + radius);
			Vector2 p3_tan_a = new Vector2(center.x - rh, center.y + radius);
			Vector2 p3_tan_b = new Vector2(center.x + rh, center.y + radius);

			Vector2 p4 = new Vector2(center.x - radius, center.y);
			Vector2 p4_tan_a = new Vector2(center.x - radius, center.y - rh);
			Vector2 p4_tan_b = new Vector2(center.x - radius, center.y + rh);

			DrawBezierLine(p1, p1_tan_b, p2, p2_tan_a, color, width, antiAlias, segmentsPerQuarter);
			DrawBezierLine(p2, p2_tan_b, p3, p3_tan_b, color, width, antiAlias, segmentsPerQuarter);
			DrawBezierLine(p3, p3_tan_a, p4, p4_tan_b, color, width, antiAlias, segmentsPerQuarter);
			DrawBezierLine(p4, p4_tan_a, p1, p1_tan_a, color, width, antiAlias, segmentsPerQuarter);
			GUI.color = color2;
		}

		// Other than method name, DrawBezierLine is unchanged from Linusmartensson's original implementation.
		public static void DrawBezierLine(Vector2 start, Vector2 startTangent, Vector2 end, Vector2 endTangent, Color color, float width, bool antiAlias, int segments)
		{
			Vector2 lastV = CubeBezier(start, startTangent, end, endTangent, 0);
			for (int i = 1; i < segments + 1; ++i)
			{
				Vector2 v = CubeBezier(start, startTangent, end, endTangent, i / (float)segments);
				Render.DrawLine(lastV, v, color, width, antiAlias);
				lastV = v;
			}
		}

		private static Vector2 CubeBezier(Vector2 s, Vector2 st, Vector2 e, Vector2 et, float t)
		{
			float rt = 1 - t;
			return rt * rt * rt * s + 3 * rt * rt * t * st + 3 * rt * t * t * et + t * t * t * e;
		}

		public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width, bool antiAlias)
		{
			float dx = pointB.x - pointA.x;
			float dy = pointB.y - pointA.y;
			float len = Mathf.Sqrt(dx * dx + dy * dy);

			if (len < 0.001f)
			{
				return;
			}

			Texture2D tex;
			Material mat;
			if (antiAlias)
			{
				
				width = width * 3.0f;
				tex = aaLineTex;
				mat = blendMaterial;
			}
			else
			{
				tex = lineTex;
				mat = blitMaterial;
			}

			float wdx = width * dy / len;
			float wdy = width * dx / len;

			Matrix4x4 matrix = Matrix4x4.identity;
			matrix.m00 = dx;
			matrix.m01 = -wdx;
			matrix.m03 = pointA.x + 0.5f * wdx;
			matrix.m10 = dy;
			matrix.m11 = wdy;
			matrix.m13 = pointA.y - 0.5f * wdy;

			// Use GL matrix and Graphics.DrawTexture rather than GUI.matrix and GUI.DrawTexture,
			// for better performance. (Setting GUI.matrix is slow, and GUI.DrawTexture is just a
			// wrapper on Graphics.DrawTexture.)
			GL.PushMatrix();
			GL.MultMatrix(matrix);
			//Graphics.DrawTexture(lineRect, tex, lineRect, 0, 0, 0, 0, color, mat);
			//Replaced by:
			GUI.color = color;//this and...
			GUI.DrawTexture(lineRect, tex);//this

			GL.PopMatrix();
		}
	}
}
