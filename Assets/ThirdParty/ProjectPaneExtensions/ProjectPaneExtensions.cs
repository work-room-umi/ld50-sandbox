// [ProjectPaneExtensions.cs](https://gist.github.com/Tenebrous/db7f6e9087d34b73de5d45c82263d131#file-projectpaneextensions-cs)

using System.IO;
using UnityEditor;
using UnityEngine;
[InitializeOnLoad]
public static class ProjectPaneExtensions
{
    static ProjectPaneExtensions()
    {
        EditorApplication.projectWindowItemOnGUI -= Draw;
        EditorApplication.projectWindowItemOnGUI += Draw;
    }

    static GUIStyle _labelStyle;
    static void Draw( string guid, Rect selectionrect )
    {
        var path = AssetDatabase.GUIDToAssetPath( guid );

        // skip invalid names
        if( string.IsNullOrWhiteSpace( path ) )
            return;

        // don't touch the two-column layout
        if( selectionrect.height > 20 )
            return;

        if( _labelStyle == null )
            _labelStyle = new GUIStyle( EditorStyles.label );

        var filename = Path.GetFileNameWithoutExtension( path );
        var extension = Path.GetExtension( path );

        var drawRect = selectionrect;
        drawRect.x += _labelStyle.CalcSize( new GUIContent( filename ) ).x + 18;
        drawRect.y++;

        GUI.Label( drawRect, extension );
    }
}