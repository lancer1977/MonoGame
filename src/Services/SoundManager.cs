using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace PolyhydraGames.MonoGame.Services;

public class SoundManager
{
    private readonly Dictionary<Enum, SoundEffect> _soundEffects = new Dictionary<Enum, SoundEffect>();
    private readonly Dictionary<string, Song> _music = new Dictionary<string, Song>();
    public string SongCount => _music.Count.ToString();

    private void LoadSound(SoundEffect aud, Enum key)
    {
        _soundEffects.Add(key, aud);
    }

    public void Play(Enum key)
    {
        if (!_soundEffects.ContainsKey(key)) return;
        var item = _soundEffects[key];
        item.Play();
    }
    public void PlaySong(string key)
    {
        if (!_music.ContainsKey(key)) return;
        MediaPlayer.Play(_music[key]);
        MediaPlayer.Volume = 100;
    }
    private void LoadMusic(Song mySong, string key) => _music.Add(key, mySong);

    public void StopSong()
    {
        MediaPlayer.Stop();
    }

    public SoundManager(ContentManager content)
    {
        // content.RootDirectory = @"Content/DefaultContent";

        //LoadSound(content.Load<SoundEffect>("Sounds/kick"), 1);
        //LoadSound(content.Load<SoundEffect>("Sounds/brick"), 2);
        //LoadSound(content.Load<SoundEffect>("Sounds/echo"), 3);
        //LoadSound(content.Load<SoundEffect>("Sounds/power"), 4);
        //LoadSound(content.Load<SoundEffect>("Sounds/laser"), 5);
        //LoadMusic(content.Load<Song>("Sounds/blobby"), "song1");
        //LoadMusic(content.Load<Song>("Sounds/music1"), "song2");
        //LoadMusic(content.Load<Song>("Sounds/spongebob"), "song3");


    }



    // internal void LoadMusicExternal(string filename, string tag)
    // {
    //     var ctor = typeof(Song).GetConstructor(
    //BindingFlags.NonPublic | BindingFlags.Instance, null,
    //new[] { typeof(string), typeof(string), typeof(int) }, null);
    //     var song = (Song)ctor.Invoke(new object[] { tag, filename, 0 });
    //     _music.Add(tag, song);
    // }

    //public bool GetSong(string filename, Uri imageAddress)
    //{
    //string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

    //string localPath = Path.Combine(documentsPath, filename);
    //var fileReader = new WebClient(); 
    //fileReader.DownloadFile(imageAddress, filename);
    //LoadSong(localPath, filename);
    //PlaySong(filename);
    //   fileReader.DownloadFile()

    // t1.ContinueWith(antecendent => { 

    // });
    // t1.Start();
    //fileReader.DownloadFileAsync(imageAddress, localPath);
    //fileReader.
    //fileReader.DownloadFileCompleted += (s, e) => LoadSong(localPath,filename);
    //fileReader.
    //    return true;

    //}

}