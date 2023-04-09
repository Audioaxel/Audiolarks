
using System.Collections.Generic;

namespace BlazorAudioPlayerLib.Models;

public class Soundtrack
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FilePath { get; set; }
    public string? ThumbnailPath { get; set; }
    public List<EMusicalTag>? MusicalTags { get; set; }
}