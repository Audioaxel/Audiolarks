using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BlazorAudioPlayerLib.Services;

public interface IAudioPlayer
{
    Task PlayClick(string audioFile);
    Task PlayHover(string audioFile);
    Task PlayMusic(string audioFile);
    Task StopMusic(string audioFile);
}
