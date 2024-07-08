public class Music
{
    public int duration {
        get;
        set;
    }
    public string genre {
        get;
        set;
    }

    public Music()
    {
        duration = 0;
        genre = "Unknown";
    }

    public Music(int duration, string genre)
    {
        this.duration = duration;
        this.genre = genre;
    }

    public Music(int duration, string genre, char durationType)
    {
        switch (durationType)
        {
        case 'h': // Hours to minutes
            this.duration = duration * 60;
            break;
        case 'd': // Days to minutes
            this.duration = duration * 1440;
            break;
        case 'm': // Minutes
        default:
            this.duration = duration;
            break;
        }
        this.genre = genre;
    }
}