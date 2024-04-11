using NAudio.Wave;

class PomodoroTimer
{
    static void Main(string[] args)
    {
        int workTime = 25;
        int breakTime = 5;
        int longBreak = 15;
        int pomodoroCounter = 0;

        Console.WriteLine("Pomodoro Timer");
        Console.WriteLine("Press enter to start the timer!");
        Console.ReadLine();

        while (true)
        {

            Console.WriteLine($"Pomodoro {++pomodoroCounter}: Work for {workTime} minutes.");
            Thread.Sleep(workTime * 60 * 1000);

            playBreakStartSound();

            if ((pomodoroCounter & 3 ) == 0)
            {
                Console.WriteLine($"Take a {longBreak}-minute break.");
                Thread.Sleep(longBreak * 60 * 1000);
            }
            else
            {
                Console.WriteLine($"Take a {breakTime}-minute break.");
                Thread.Sleep(breakTime * 60 * 1000);
            }

            playRestartingSound();

        }

        Console.WriteLine("Pomodoro session ended. Goodbye!");
    }

    static void playBreakStartSound()
    {
        string SoundFilePath = "StopBell.wav";
        FileStream Wav_file_stream = File.OpenRead(SoundFilePath);
        WaveStream ws_raw = new WaveFileReader(Wav_file_stream);
        ws_raw = WaveFormatConversionStream.CreatePcmStream(ws_raw);
        WaveOutEvent Output = new WaveOutEvent();

        Wav_file_stream.Seek(0, SeekOrigin.Begin);

        Output.Init(ws_raw);
        Output.Play();

        // Wait for the audio to finish playing
        while (Output.PlaybackState == PlaybackState.Playing)
        {
            Thread.Sleep(100); 
        }

        Wav_file_stream.Close();
        ws_raw.Close();
        Output.Dispose();
    }

    static void playRestartingSound()
    {
        string SoundFilePath = "restart.wav";
        FileStream Wav_file_stream = File.OpenRead(SoundFilePath);
        WaveStream ws_raw = new WaveFileReader(Wav_file_stream);
        ws_raw = WaveFormatConversionStream.CreatePcmStream(ws_raw);
        WaveOutEvent Output = new WaveOutEvent();

        Wav_file_stream.Seek(0, SeekOrigin.Begin);

        Output.Init(ws_raw);
        Output.Play();

        // Wait for the audio to finish playing
        while (Output.PlaybackState == PlaybackState.Playing)
        {
            Thread.Sleep(100);
        }

        Wav_file_stream.Close();
        ws_raw.Close();
        Output.Dispose();
    }
}

