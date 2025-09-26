using System.ComponentModel.DataAnnotations;

namespace Soluction4Fleet.API.Domain.Enum
{
    public enum StatusCarro
    {
        [Display(Name = "DISPONIVEL")]
        DISPONIVEL = 1,

        [Display(Name = "TRANSFERIDO")]
        TRANSFERIDO = 2,

        [Display(Name = "ROUBADO")]
        ROUBADO = 3,

        [Display(Name = "SINISTRO_TOTAL")]
        SINISTRO_TOTAL = 4,

        [Display(Name = "VENDIDO")]
        VENDIDO = 5,
    }
}
