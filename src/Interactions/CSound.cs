using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace PolyhydraGames.MonoGame.Interactions;

public class CSound
{
    private readonly Dictionary<string, SoundEffect> _sfx = new Dictionary<string, SoundEffect>();
    private readonly Dictionary<string, Song> _music = new Dictionary<string, Song>();

    public void LoadSound(SoundEffect aud, string key)
    {
        _sfx.Add(key, aud);
    }
    public void Play(string key)
    {
        if (_sfx.ContainsKey(key)) _sfx[key].Play();

    }
    public void PlaySong(string key)
    {
        Microsoft.Xna.Framework.Media.MediaPlayer.Play(_music[key]);
        Microsoft.Xna.Framework.Media.MediaPlayer.Volume = 100;
    }
    public void LoadMusic(Song mySong, string key)
    {
        _music.Add(key, mySong);
    }

    public void StopSong() { }

}