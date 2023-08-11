using SoFilmes.Domain.Enums;

namespace SoFilmes.Application.Movies.Map
{
    public static class AgeClassificationMap
    {
        public static string MapToString(this EAgeClassification ageClassification)
        {
            return ageClassification switch
            {
                EAgeClassification.Free => "Livre",
                EAgeClassification.Ten => "10 Anos",
                EAgeClassification.Twelve => "12 Anos",
                EAgeClassification.Sixteen => "16 anos",
                EAgeClassification.Eighteen => "18 anos",
                _ => "Faixa etária não reconhecida",
            };
        }
    }
}
