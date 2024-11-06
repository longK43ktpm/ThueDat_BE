using System.ComponentModel.DataAnnotations;

namespace ThueDat.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}