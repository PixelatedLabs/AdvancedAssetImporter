using System.Linq;

using UnityEditor;
using UnityEngine;

namespace AdvancedAssetImporter
{
	class ModelImporter : AssetPostprocessor
	{
		void OnPostprocessModel(GameObject gameObject)
		{
			foreach (GameObject child in gameObject.GetComponentsInChildren<Transform>().Where(t => t != gameObject.transform).Select(t => t.gameObject))
			{
				//Box collider
				if (child.name.Contains("COL_BOX"))
				{
					BoxCollider box = child.AddComponent<BoxCollider>();
					MeshFilter filter = child.GetComponent<MeshFilter>();
					box.center = filter.sharedMesh.bounds.center;
					box.size = filter.sharedMesh.bounds.size;
				}
				//Mesh collider
				if (child.name.Contains("COL_MSH"))
				{
					MeshCollider collider = child.AddComponent<MeshCollider>();
					MeshFilter filter = child.GetComponent<MeshFilter>();
					collider.sharedMesh = filter.sharedMesh;
				}
				//Convex mesh collider
				if (child.name.Contains("COL_CVX"))
				{
					MeshCollider collider = child.AddComponent<MeshCollider>();
					MeshFilter filter = child.GetComponent<MeshFilter>();
					collider.sharedMesh = filter.sharedMesh;
					collider.convex = true;
				}
				//Sphere collider
				if (child.name.Contains("COL_SPH"))
				{
					SphereCollider collider = child.AddComponent<SphereCollider>();
					MeshFilter filter = child.GetComponent<MeshFilter>();
					collider.radius = filter.sharedMesh.bounds.size.magnitude / 2;
				}
				//All static
				if (child.name.Contains("STC_ALL"))
				{
					child.isStatic = true;
				}
				//Lightmap static
				if (child.name.Contains("STC_LGT"))
				{
					child.AddStaticEditorFlags(StaticEditorFlags.LightmapStatic);
				}
				//Occluder static
				if (child.name.Contains("STC_OCR"))
				{
					child.AddStaticEditorFlags(StaticEditorFlags.OccluderStatic);
				}
				//Occludee static
				if (child.name.Contains("STC_OCE"))
				{
					child.AddStaticEditorFlags(StaticEditorFlags.OccludeeStatic);
				}
				//Batching static
				if (child.name.Contains("STC_BTC"))
				{
					child.AddStaticEditorFlags(StaticEditorFlags.BatchingStatic);
				}
				//Navigation static
				if (child.name.Contains("STC_NAV"))
				{
					child.AddStaticEditorFlags(StaticEditorFlags.NavigationStatic);
				}
				//Off mesh link static
				if (child.name.Contains("STC_LNK"))
				{
					child.AddStaticEditorFlags(StaticEditorFlags.OffMeshLinkGeneration);
				}
				//Reflection probe static
				if (child.name.Contains("STC_RFL"))
				{
					child.AddStaticEditorFlags(StaticEditorFlags.ReflectionProbeStatic);
				}
				//Removes mesh filter and renderer
				if (child.name.Contains("RMV_MSH"))
				{
					Object.DestroyImmediate(child.GetComponent<MeshFilter>());
					Object.DestroyImmediate(child.GetComponent<MeshRenderer>());
				}
			}
		}
	}
}