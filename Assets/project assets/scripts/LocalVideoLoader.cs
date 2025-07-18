using UnityEngine;
using UnityEngine.Video;

public class LocalVideoLoader : MonoBehaviour
{
    [Header("Video Settings")]
    [Tooltip("Name of the video file placed in persistentDataPath")]
    public string videoFileName = "myVideo.mp4"; // Set in Inspector

    [Tooltip("Material on your inverted sphere that will display the video")]
    public Material sphereMaterial;

    private VideoPlayer videoPlayer;
    private RenderTexture renderTexture;

    void Start()
    {
        // Prepare render texture for the video
        renderTexture = new RenderTexture(2048, 1024, 0);
        renderTexture.Create();

        // Assign RenderTexture to the material
        if (sphereMaterial != null)
        {
            sphereMaterial.mainTexture = renderTexture;
            GetComponent<Renderer>().material = sphereMaterial;
        }

        // Add and configure VideoPlayer
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.isLooping = true;
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = renderTexture;

        // Compose full file path
        string videoPath = System.IO.Path.Combine(Application.persistentDataPath, videoFileName);

        Debug.Log("Loading video from path: " + videoPath);

        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = videoPath;

        // Prepare and play when ready
        videoPlayer.prepareCompleted += (vp) => videoPlayer.Play();
        videoPlayer.Prepare();
    }
}
