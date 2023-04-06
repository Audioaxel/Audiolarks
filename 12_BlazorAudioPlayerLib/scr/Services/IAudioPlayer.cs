using System.Threading.Tasks;

namespace BlazorAudioPlayerLib.Services;

public interface IAudioPlayer
{
    Task PlayClick(string audioFile);
    Task PlayHover(string audioFile);
    Task PlayMusic(string audioFile);
    Task StopMusic(string audioFile);
}
