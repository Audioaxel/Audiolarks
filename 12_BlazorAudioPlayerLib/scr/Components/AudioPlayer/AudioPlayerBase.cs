
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAudioPlayerLib.Models;
using BlazorAudioPlayerLib.Services;
using BlazorAudioPlayerLib.Services.Notifies;
using Microsoft.AspNetCore.Components;

namespace BlazorAudioPlayerLib.Components.AudioPlayer;

public class AudioPlayerBase : ComponentBase, IDisposable
{
    // Hardcoded List of Sountracks!
    private List<Soundtrack> _soundtracks = new () {
        new Soundtrack {
            Id = 001,
            Name = "IjomaTrack01",
            FilePath = "music/IjomaTrack01.mp3",
            ThumbnailPath ="images/thumbnails/test1.jpg"
        },
        new Soundtrack {
            Id = 002,
            Name = "AdventureTrack",
            FilePath = "music/Adventure.mp3",
            ThumbnailPath ="images/thumbnails/test2.jpg"
        },
        new Soundtrack {
            Id = 003,
            Name = "ElectroTrack",
            FilePath = "music/Electro.mp3",
            ThumbnailPath ="images/thumbnails/test1.jpg"
        },
        new Soundtrack {
            Id = 004,
            Name = "TechnoTrack",
            FilePath = "music/Techno.mp3",
            ThumbnailPath ="images/thumbnails/test2.jpg"
        }
    };
    internal List<Soundtrack> soundtracks = new ();

    [Inject]
    public IAudioPlayer AudioPlayer { get; set; }
    [Inject]
    public IVideoPlayerNotify VideoPlayerNotify { get; set; }

    public Soundtrack? CurrentSoundtrack { get; private set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        VideoPlayerNotify.OnVideoPlayAsync += OnVideoPlayHandle;
        VideoPlayerNotify.OnVideoStopAsync += OnVideoStopHandle;

        // Kann weg wenn liste nicht hardcoded
        soundtracks = _soundtracks;
    }

    protected async Task PlaySoundtrack(Soundtrack soundtrack)
    {
        try
        {
            await AudioPlayer.PlayMusic(soundtrack.FilePath);
            CurrentSoundtrack = soundtrack;
        }
        catch (Exception ex)
        {
            CurrentSoundtrack = null;
            throw ex;
        }
    }

    protected async Task StopSoundtrack(Soundtrack soundtrack)
    {
        await AudioPlayer.StopMusic(soundtrack.FilePath);
    }

    protected async Task PauseSoundtrack()
    {
        await AudioPlayer.PauseMusic();
    }

    private async Task OnVideoPlayHandle()
    {
        if (CurrentSoundtrack is not null)
        {
            await AudioPlayer.PauseMusic();
        }
    }

    private async Task OnVideoStopHandle()
    {
        if (CurrentSoundtrack is not null)
        {
            await AudioPlayer.ResumeMusic();
        }
    }

    public void Dispose()
    {
        VideoPlayerNotify.OnVideoPlayAsync -= OnVideoPlayHandle;
        VideoPlayerNotify.OnVideoStopAsync -= OnVideoStopHandle;
    }
}