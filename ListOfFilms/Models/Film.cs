using System.ComponentModel.DataAnnotations;

namespace ListOfFilms
{
    public class Film
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Название фильма")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Длина строки должна быть не меньше 3 символов")]
        [Display(Name = "Имя режиссёра")]
        public string? Director { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть не меньше 3 символов")]
        [Display(Name = "Жанр")]
        public string? Genre { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Range(1800, 2023, ErrorMessage = "Недопустимый год")]
        [Display(Name = "Год выпуска")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string? Poster { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(250, MinimumLength = 15, ErrorMessage = "Длина строки должна быть не меньше 15 символов")]
        [Display(Name = "Описание фильма")]
        public string? Description { get; set; }
    }
}
