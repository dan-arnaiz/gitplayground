using System;

interface MediaPlayer {
  void PlayAudio();
  void PlayVideo();
}

public class MP3Player : MediaPlayer {
  public void PlayAudio() { Console.WriteLine("MP3Player playing audio."); }

  public void PlayVideo() { Console.WriteLine("MP3Player cannot play video."); }
}

public class MP4Player : MediaPlayer {
  public void PlayAudio() { Console.WriteLine("MP4Player playing audio."); }

  public void PlayVideo() { Console.WriteLine("MP4Player playing video."); }
}

public class Device {
  private MediaPlayer mediaPlayer;

  public Device(MediaPlayer mediaPlayer) { this.mediaPlayer = mediaPlayer; }

  public void PlayAudio() { mediaPlayer.PlayAudio(); }

  public void PlayVideo() { mediaPlayer.PlayVideo(); }
}