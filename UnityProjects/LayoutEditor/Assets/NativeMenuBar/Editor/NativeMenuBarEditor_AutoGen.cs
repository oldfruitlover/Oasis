
//
// MACHINE-GENERATED CODE - DO NOT MODIFY BY HAND!
//
// NOTE: You definitely SHOULD commit this file to source control!!!
//
// To regenerate this file, select MenuBar component, look
// in the custom Inspector window and press the Generate Editor menu.
//

using System.Linq;

public static class NativeMenuBar_AutoGen
{

    private static NativeMenuBar.Core.MenuBar menubar = UnityEngine.Object.FindObjectOfType<NativeMenuBar.Core.MenuBar>();
    [UnityEditor.MenuItem("NativeMenuBar/File/Open _O")]
    private static void FileOpen()
    {
        menubar.MenuItems.Single(item => item.FullPath == "File/Open").Action.Invoke();
    }
    [UnityEditor.MenuItem("NativeMenuBar/File/Open _O", true)]
    private static bool FileOpenValidate()
    {
        return UnityEngine.Application.isPlaying && menubar.MenuItems.Single(item => item.FullPath == "File/Open").IsInteractable;
    }
    [UnityEditor.MenuItem("NativeMenuBar/Edit/Copy _C")]
    private static void EditCopy()
    {
        menubar.MenuItems.Single(item => item.FullPath == "Edit/Copy").Action.Invoke();
    }
    [UnityEditor.MenuItem("NativeMenuBar/Edit/Copy _C", true)]
    private static bool EditCopyValidate()
    {
        return UnityEngine.Application.isPlaying && menubar.MenuItems.Single(item => item.FullPath == "Edit/Copy").IsInteractable;
    }
    [UnityEditor.MenuItem("NativeMenuBar/Edit/Paste _V")]
    private static void EditPaste()
    {
        menubar.MenuItems.Single(item => item.FullPath == "Edit/Paste").Action.Invoke();
    }
    [UnityEditor.MenuItem("NativeMenuBar/Edit/Paste _V", true)]
    private static bool EditPasteValidate()
    {
        return UnityEngine.Application.isPlaying && menubar.MenuItems.Single(item => item.FullPath == "Edit/Paste").IsInteractable;
    }
    [UnityEditor.MenuItem("NativeMenuBar/Component/Lamp _L")]
    private static void ComponentLamp()
    {
        menubar.MenuItems.Single(item => item.FullPath == "Component/Lamp").Action.Invoke();
    }
    [UnityEditor.MenuItem("NativeMenuBar/Component/Lamp _L", true)]
    private static bool ComponentLampValidate()
    {
        return UnityEngine.Application.isPlaying && menubar.MenuItems.Single(item => item.FullPath == "Component/Lamp").IsInteractable;
    }
    [UnityEditor.MenuItem("NativeMenuBar/Emulation/Start _S")]
    private static void EmulationStart()
    {
        menubar.MenuItems.Single(item => item.FullPath == "Emulation/Start").Action.Invoke();
    }
    [UnityEditor.MenuItem("NativeMenuBar/Emulation/Start _S", true)]
    private static bool EmulationStartValidate()
    {
        return UnityEngine.Application.isPlaying && menubar.MenuItems.Single(item => item.FullPath == "Emulation/Start").IsInteractable;
    }
    [UnityEditor.MenuItem("NativeMenuBar/Help/About _ ")]
    private static void HelpAbout()
    {
        menubar.MenuItems.Single(item => item.FullPath == "Help/About").Action.Invoke();
    }
    [UnityEditor.MenuItem("NativeMenuBar/Help/About _ ", true)]
    private static bool HelpAboutValidate()
    {
        return UnityEngine.Application.isPlaying && menubar.MenuItems.Single(item => item.FullPath == "Help/About").IsInteractable;
    }

}
