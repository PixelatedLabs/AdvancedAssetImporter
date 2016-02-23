using UnityEditor;
using UnityEngine;

namespace AdvancedAssetImporter
{
	static class Utilities
	{
		public static void AddStaticEditorFlags(this GameObject gameObject, StaticEditorFlags flags)
		{
			StaticEditorFlags existing = GameObjectUtility.GetStaticEditorFlags(gameObject);
			existing |= flags;
			GameObjectUtility.SetStaticEditorFlags(gameObject, existing);
		}
	}
}