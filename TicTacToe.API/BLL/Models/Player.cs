using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TicTacToe.API.BLL.Models;

/// <summary>
/// 
/// </summary>
public class Player
{
    public Player(string nickname, byte[] saltedPassword)
    {
        Id = Guid.NewGuid();
        Nickname = nickname;
        SaltedPassword = saltedPassword;
    }

    public static Player CreateFromNicknameAndPass(string nickname, byte[] saltedPassword)
    {
        return new Player(nickname, saltedPassword);
    }

    /// <summary>
    /// 
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// 
    /// </summary>

    public string Nickname { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonIgnore]
    public byte[] SaltedPassword { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public bool IsOnline { get; set; }
}