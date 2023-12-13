using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senkel.Unity.API;

/// <summary>
/// Represents an object that is capable of managing scenes by either loading or unloading them using an index or a string representing the scene name.
/// </summary>
public interface ISceneManager
{
    /// <summary>
    /// Loads the scene represented by the specified scene index either additively or as a new single scene.
    /// </summary>
    /// <param name="sceneIndex">The index that represents the scene.</param>
    /// <param name="additive">If the scene is loaded aside the other loaded scenes or if any other scene should be unloaded when loading this scene.</param>
    public void LoadScene(int sceneIndex, bool additive = false);

    /// <summary>
    /// Loads the scene represented by the specified scene name either additively or as a new single scene.
    /// </summary>
    /// <param name="sceneName">The name that represents the scene.</param>
    /// <param name="additive">If the scene is loaded aside the other loaded scenes or if any other scenes should be unloaded when loading this scene.</param>
    public void LoadScene(string sceneName, bool additive = false);

    /// <summary>
    /// Loads the scene represented by the specified scene index either additively or as a new single scene.
    /// </summary>
    /// <param name="sceneIndex">The index that represents the scene.</param>
    /// <param name="additive">If the scene is loaded aside the other loaded scenes or if any other scene should be unloaded when loading this scene.</param>
    /// <returns>Determines the operation of the scene loading.</returns>
    public ValueTask LoadSceneAsync(int sceneIndex, bool additive = false);
    
    /// <summary>
    /// Loads the scene represented by the specified scene name either additively or as a new single scene.
    /// </summary>
    /// <param name="sceneName">The name that represents the scene.</param>
    /// <param name="additive">If the scene is loaded aside the other loaded scenes or if any other scenes should be unloaded when loading this scene.</param>
    /// <returns>Represents the operation of the scene loading.</returns>
    public ValueTask LoadSceneAsync(string sceneName, bool additive = false);

    /// <summary>
    /// Unloads the scene represented by the specified index.
    /// </summary>
    /// <param name="sceneIndex">The index of the scene to unload.</param>
    /// <returns>Represents the operation of the scene unloading.</returns>
    public ValueTask UnloadSceneAsync(int sceneIndex);

    /// <summary>
    /// Unloads the scene represented by the specified name.
    /// </summary>
    /// <param name="sceneName">The name of the scene to unload.</param>
    /// <returns>Represents the operation of the scene unloading.</returns>
    public ValueTask UnloadSceneAsync(string sceneName);
}
