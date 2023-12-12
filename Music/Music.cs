using NAudio.Wave;
using Spectre.Console;

class Music
{
    private static WaveOutEvent waveOutEvent;

    static Music()
    {
        waveOutEvent = new WaveOutEvent();
    }

    public static void PlayErrorSound()
    {
        PlayAudio("C:\\Users\\LKFD\\Desktop\\LORDKENT\\College - 2nd Year\\Assignments\\Object Oriented Programming 1\\Project CPE, Engineering Data Analysis Calculator\\Engineering Data Analysis Calculator\\Music\\Error.wav"); // REMEMBER TO REPLACE THIS
    }

    public static void PlaySelectSound()
    {
        PlayAudio("C:\\Users\\LKFD\\Desktop\\LORDKENT\\College - 2nd Year\\Assignments\\Object Oriented Programming 1\\Project CPE, Engineering Data Analysis Calculator\\Engineering Data Analysis Calculator\\Music\\Select.wav"); // REMEMBER TO REPLACE THIS
    }

    public static void PlaySuccessSound()
    {
        PlayAudio("C:\\Users\\LKFD\\Desktop\\LORDKENT\\College - 2nd Year\\Assignments\\Object Oriented Programming 1\\Project CPE, Engineering Data Analysis Calculator\\Engineering Data Analysis Calculator\\Music\\Success.wav"); // REMEMBER TO REPLACE THIS
    }

    public static void PlayLoginSound()
    {
        PlayAudio("C:\\Users\\LKFD\\Desktop\\LORDKENT\\College - 2nd Year\\Assignments\\Object Oriented Programming 1\\Project CPE, Engineering Data Analysis Calculator\\Engineering Data Analysis Calculator\\Music\\Login.wav"); // REMEMBER TO REPLACE THIS
    }
    public static void PlayCancelSound()
    {
        PlayAudio("C:\\Users\\LKFD\\Desktop\\LORDKENT\\College - 2nd Year\\Assignments\\Object Oriented Programming 1\\Project CPE, Engineering Data Analysis Calculator\\Engineering Data Analysis Calculator\\Music\\Cancel.wav"); // REMEMBER TO REPLACE THIS
    }

    public static void PlayIntroductionSound()
    {
        PlayAudio("C:\\Users\\LKFD\\Desktop\\LORDKENT\\College - 2nd Year\\Assignments\\Object Oriented Programming 1\\Project CPE, Engineering Data Analysis Calculator\\Engineering Data Analysis Calculator\\Music\\Introduction.wav"); // REMEMBER TO REPLACE THIS
    }

    public static void PlayAboutMeSound()
    {
        PlayAudio("C:\\Users\\LKFD\\Desktop\\LORDKENT\\College - 2nd Year\\Assignments\\Object Oriented Programming 1\\Project CPE, Engineering Data Analysis Calculator\\Engineering Data Analysis Calculator\\Music\\AboutMe.wav"); // REMEMBER TO REPLACE THIS
    }
  

    public static void StopPlayback()
    {
        if (waveOutEvent.PlaybackState == PlaybackState.Playing)
        {
            waveOutEvent.Stop();
        }
    }
    private static void PlayAudio(string filePath)
    {
        try
        {
            StopPlayback(); // Stop playback before playing a new sound
            var audioFileReader = new AudioFileReader(filePath);
            waveOutEvent.Init(audioFileReader);
            waveOutEvent.Play();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while playing audio: {ex.Message}");
            // Optionally, log the exception or take other appropriate actions
        }
    }


}
