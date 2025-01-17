public interface MusicControls
{
    void Play();
    void Pause();
    void Stop();
}

public class BasicPlayer : MusicControls
{
    public void Play()
    {
        Console.WriteLine("Music is playing.");
    }

    public void Pause()
    {
        Console.WriteLine("Music is paused.");
    }

    public void Stop()
    {
        Console.WriteLine("Music has stopped.");
    }
}